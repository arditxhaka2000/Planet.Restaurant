using MyNET.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net.Http;
using System.Text;

namespace MyNET
{
    public static class UpdateService
    {
        public static bool IsUptoDate(string appName, string version)
        {
            RestClient restClient = new RestClient(Config.RestUrl);
            var request = new RestRequest("isUptoDate/{appName}/{version}", Method.GET);

            request.AddUrlSegment("appName", appName);
            request.AddUrlSegment("version", version);

            var response = restClient.Execute<Response<bool>>(request);
            if (response.ErrorException != null)
            {
                throw new HttpRequestException(response.ErrorMessage, response.ErrorException);
            }
            string retVal = response.Content;
            if (response.Data.success)
            {
                return response.Data.data;
            }
            else
            {
                //log  error
                //error ne upate service continu with old version
                return true;
            }

        }

        public static string GetLastVerion(string appName)
        {
            RestClient restClient = new RestClient(Config.RestUrl);
            var request = new RestRequest("getlastversion/{appName}", Method.GET);

            request.AddUrlSegment("appName", appName);          

            var response = restClient.Execute<Response<string>>(request);
            if (response.ErrorException != null)
            {
                throw new HttpRequestException(response.ErrorMessage, response.ErrorException);
            }
            string retVal = response.Content;
            if (response.Data.success)
            {
                return response.Data.data;
            }
            else
            {                
                return "1.0.0.0";
            }

        }

        public static UpdateDetails GetListOfFilesToUpdate(string appName, string version)
        {
            RestClient restClient = new RestClient(Config.RestUrl);
            var request = new RestRequest("getListOfFilesToUpdate/{appName}/{version}", Method.GET);

            request.AddUrlSegment("appName", appName);
            request.AddUrlSegment("version", version);

            //request.AddJsonBody(obj);
            var response = restClient.Execute<Response<UpdateDetails>>(request);
            if (response.ErrorException != null)
            {
                throw new HttpRequestException(response.ErrorMessage, response.ErrorException);
            }
            UpdateDetails details = response.Data.data;
            return details;
        }

        public static void AddUpdate(object obj)
        {
            RestClient restClient = new RestClient(Config.RestUrl);
            var request = new RestRequest("addUpdate", Method.POST);
            //request.AddUrlSegment("version", version);

            request.AddJsonBody(obj);

            var response = restClient.Execute(request);
            if (response.ErrorException != null)
            {
                throw new HttpRequestException(response.ErrorMessage, response.ErrorException);
            }
            string file = response.Content;
            //return file;
        }

        //public static bool UploadFile(byte[] file, string appName, string version, string path)
        //{
        //    RestClient restClient = new RestClient(Config.RestUrl);
        //    var request = new RestRequest("uploadFile/{appName}/{version}/{path}", Method.POST);

        //    request.AddUrlSegment("appName", appName);
        //    request.AddUrlSegment("version", version);
        //    request.AddUrlSegment("path", path);

        //    string fileExtension = System.IO.Path.GetExtension(path);
        //    string filename = System.IO.Path.GetFileName(path);           
        //    request.AddHeader("Content-Type", "text/plain");
           
        //    string content  = Convert.ToBase64String(file);            
        //    request.AddParameter("text/plain", content, ParameterType.RequestBody);           
        //    var response = restClient.Execute<MyNET.Models.Response<bool>>(request);

        //    if (response.ErrorException != null)
        //    {
        //        throw new HttpRequestException(response.ErrorMessage, response.ErrorException);
        //    }

        //    return response.Data.success;
        //}

        public static bool UploadFileParts(byte[] file, string appName, string version, string path)
        {
            string fileExtension = System.IO.Path.GetExtension(path);
            string filename = System.IO.Path.GetFileName(path);
           

            string content = Convert.ToBase64String(file);
            int maxLength = 102400;
            int n = content.Length / maxLength;
            string tempName = "init";

            string log = "parts n=" + n;

            for (int i = 0; i < n+1; i++)
            {
                RestClient restClient = new RestClient(Config.RestUrl);
                var request = new RestRequest("uploadFileParts/{appName}/{version}/{path}/{tempName}/part/{i}/from/{n}", Method.POST);
                request.AddHeader("Content-Type", "text/plain");
                string strPath = path.Replace("/", "$");
                request.AddUrlSegment("appName", appName);
                request.AddUrlSegment("version", version);
                request.AddUrlSegment("path", strPath);
                request.AddUrlSegment("tempName", tempName);

                request.AddUrlSegment("i", i);
                request.AddUrlSegment("n", n);

                log += " i:"+ i;

                int left = content.Length - i * maxLength;
                int pula = (left > maxLength) ? maxLength : content.Length - i * maxLength;

                string part = content.Substring(i * maxLength, pula);
                request.AddParameter("text/plain", part, ParameterType.RequestBody);
                var response = restClient.Execute<MyNET.Models.Response<string>>(request);

                if (response.ErrorException != null)
                {
                    throw new HttpRequestException(response.ErrorMessage, response.ErrorException);
                }

                var robj =  response.Data;
                tempName = (robj.data == null)?  "init" : (string) robj.data;
            }

            Console.Write(log);

            return true;
        }

        //public static bool UploadFileForm(byte[] file, string appName, string version, string path)
        //{
        //    RestClient restClient = new RestClient(Config.RestUrl);
        //    var request = new RestRequest("uploadfilet/{appName}/{version}/{path}", Method.POST);

        //    request.AddUrlSegment("appName", appName);
        //    request.AddUrlSegment("version", version);
        //    request.AddUrlSegment("path", path);

        //    string fileName = System.IO.Path.GetFileName(path);


        //    request.AddHeader("cache-control", "no-cache");
        //    request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
        //    request.AddHeader("content-type", "multipart/form-data; boundary=----WebKitFormBoundary7MA4YWxkTrZu0gW");
        //    request.AddFile("upfile", file,fileName);
         
        //    IRestResponse response = restClient.Execute(request);
        //    string test = response.Content.ToString();
                                
        //    return true;
        //}

        //public static async void SendFileAsync(byte[] byteArray, string appName, string version, string path)
        //{
        //    string fileName = Path.GetFileName(path);
        //    var content = new MultipartFormDataContent();
        //    string url = string.Format("http://localhost:4000/uploadFilet/{0}/{1}/{2}", appName,version, fileName);
        //    Stream stream = new MemoryStream(byteArray);
        //    content.Add(new StreamContent(stream), "upfile");
        //   //content.
        //    //content.Add(new StreamContent(stream1), "file1.jpg");

        //    using (var httpClient = new HttpClient())
        //    {
        //        HttpResponseMessage response = await httpClient.PostAsync(url, content);
        //    }
        //}

        public static byte[] DownLoadFile(string path)
        {
            RestClient restClient = new RestClient(Config.RestUrl);
            path = path.Replace("/", "|");
            var request = new RestRequest("/downloadfile/{path}", Method.GET);

            request.AddUrlSegment("path", path);

            //request.AddJsonBody(obj);

            var response = restClient.DownloadData(request);
            //if (response.ErrorException != null)
            //{
            //    throw new HttpRequestException(response.ErrorMessage, response.ErrorException);
            //}
            //string file = response.Content;
            return response;
        }
        

    }
}
