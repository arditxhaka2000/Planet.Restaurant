using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Services
{
    public class RestHepler<T>
    {
        public static User ValidateLogin(string userName, string token)
        {
            RestClient restClient = new RestClient(Connection.GetActiveConnection());
            var request = new RestRequest("login/{userName}/token/{token}", Method.GET);
            request.AddUrlSegment("userName", userName);
            request.AddUrlSegment("token", token);

            var response = restClient.Execute<Response<User>>(request);
            if (response.ErrorException != null)
            {
                MessageBox.Show("Kontrolloni statusin e serverit a eshte Startuar!");
            }
            if (response.Data.success)
            {
                return response.Data.data.FirstOrDefault();
            }
            else
            {
                return null;
            }
        }

        public static T Get(string tableName, int id)
        {
            RestClient restClient = new RestClient(Connection.GetActiveConnection());
            var request = new RestRequest(tableName + "/{id}", Method.GET);
            request.AddUrlSegment("id", id.ToString());

            var response = restClient.Execute<Response<T>>(request);
            if (response.ErrorException != null)
            {
                MessageBox.Show("Kontrolloni statusin e serverit a eshte Startuar!");
            }
            if (response.Data.success)
            {
                if (response.Data.data != null)
                    return response.Data.data.FirstOrDefault();
                else
                    return default(T);
            }
            else
            {
                throw new Exception(response.Data.error.code);
            }
        }

        public static List<T> Search(string tableName, string searchParams)
        {
            RestClient restClient = new RestClient(Connection.GetActiveConnection());
            var request = new RestRequest(tableName + "/search?" + searchParams, Method.GET);

            var response = restClient.Execute<Response<T>>(request);
            if (response.ErrorException != null)
            {
                MessageBox.Show("Kontrolloni statusin e serverit a eshte Startuar!");
            }

            if (response.Data.success)
            {
                return response.Data.data;
            }
            else
            {
                throw new Exception(response.Data.error.code);
            }

        }
        //me rows mbi 10000 shkon ngadal!
        public static List<T> Select(string queryName, string queryParams)
        {
            RestClient restClient = new RestClient(Connection.GetActiveConnection());
            string resource = "select/" + queryName + "/?" + queryParams;
            var request = new RestRequest(resource, Method.GET);
            var response = restClient.Execute<Response<T>>(request);

            if (response.ErrorException != null)
            {
                MessageBox.Show("Kontrolloni statusin e serverit a eshte Startuar!");
            }

            if (response.Data.success)
            {
                return response.Data.data;
            }
            else
            {
                throw new Exception(response.Content);
            }
        }
        public static int SelectCount(string queryName, string queryParams)
        {
            RestClient restClient = new RestClient(Connection.GetActiveConnection());
            string resource = "select/" + queryName + "/?" + queryParams;
            var request = new RestRequest(resource, Method.GET);
            var response = restClient.Execute<Response<T>>(request);

            JObject jsonResponse = JObject.Parse(response.Content);
            bool success = jsonResponse["success"].Value<bool>();
            if (success)
            {
                JArray data = (JArray)jsonResponse["data"];
                if (data.Count > 0)
                {
                    JObject dataObject = (JObject)data[0];
                    int count = dataObject["Count"].Value<int>();
                    return count;
                }
                else
                {
                    throw new Exception("No data found in the response.");
                }
            }
            else
            {
                throw new Exception("Unsuccessful response from server.");
            }
        }
        public static List<T> Select50itemsOnly(string queryName, string queryParams)
        {
            RestClient restClient = new RestClient(Connection.GetActiveConnection());
            string resource = "selectSliced/" + queryName + "/?" + queryParams;
            var request = new RestRequest(resource, Method.GET);
            var response = restClient.Execute<Response<T>>(request);

            if (response.ErrorException != null)
            {
                MessageBox.Show("Kontrolloni statusin e serverit a eshte Startuar!");
            }

            if (response.Data.success)
            {
                return response.Data.data;
            }
            else
            {
                throw new Exception(response.Content);
            }
        }


        public static int Insert(string tableName, T obj)
        {
            RestClient restClient = new RestClient(Connection.GetActiveConnection());
            var request = new RestRequest(tableName, Method.POST);

            request.AddJsonBody(obj);

            var response = restClient.Execute<Response<T>>(request);
            if (response.ErrorException != null)
            {
                MessageBox.Show("Kontrolloni statusin e serverit a eshte Startuar!");
            }
            T retObj = (T)response.Data.data.FirstOrDefault();
            ((IBaseObj)obj).Id = ((IBaseObj)retObj).Id;
            return (int)response.Data.noOfRowsAffected;
        }
        public static int InsertSale(string tableName, T obj)
        {
            RestClient restClient = new RestClient(Connection.GetActiveConnection());
            var request = new RestRequest(tableName + "/savesale", Method.POST);

            request.AddJsonBody(obj);

            var response = restClient.Execute<Response<T>>(request);

            if (response.ErrorException != null)
            {
                MessageBox.Show("Kontrolloni statusin e serverit a eshte Startuar!");
            }
            T retObj = (T)response.Data.data.FirstOrDefault();
            ((IBaseObj)obj).Id = ((IBaseObj)retObj).Id;
            return (int)response.Data.noOfRowsAffected;
        }

        public static int BatchInsert(string tableName, List<T> objList)
        {
            RestClient restClient = new RestClient(Connection.GetActiveConnection());
            var request = new RestRequest(tableName + "/insertB", Method.POST);

            request.AddJsonBody(objList);

            var response = restClient.Execute<Response<T>>(request);
            if (response.ErrorException != null)
            {
                MessageBox.Show("Kontrolloni statusin e serverit a eshte Startuar!");
            }
            return (int)response.Data.noOfRowsAffected;
        }



        public static int BatchUpdate(string tableName, List<T> objList)
        {
            RestClient restClient = new RestClient(Connection.GetActiveConnection());
            var request = new RestRequest(tableName + "/updateB", Method.PUT);

            request.AddJsonBody(objList);

            var response = restClient.Execute<Response<T>>(request);
            if (response.ErrorException != null)
            {
                MessageBox.Show("Kontrolloni statusin e serverit a eshte Startuar!");
            }
            return (int)response.Data.noOfRowsAffected;
        }



        public static int Update(string tableName, T obj)
        {
            RestClient restClient = new RestClient(Connection.GetActiveConnection());
            var request = new RestRequest(tableName, Method.PUT);

            request.AddJsonBody(obj);

            var response = restClient.Execute<Response<T>>(request);
            if (response.ErrorException != null)
            {
                MessageBox.Show("Kontrolloni statusin e serverit a eshte Startuar!");
            }
            return (int)response.Data.noOfRowsAffected;
        }

        public static int Delete(string tableName,int id)
        {
            RestClient restClient = new RestClient(Connection.GetActiveConnection());
            var request = new RestRequest(tableName + "/{id}", Method.DELETE);

            request.AddUrlSegment("id", id.ToString());

            var response = restClient.Execute<Response<T>>(request);
            if (response.ErrorException != null)
            {
                MessageBox.Show("Kontrolloni statusin e serverit a eshte Startuar!");
            }

            return (int)response.Data.noOfRowsAffected;
        }
        public static int Query(string queryName, string queryParams)
        {
            RestClient restClient = new RestClient(Connection.GetActiveConnection());
            var request = new RestRequest("query/" + queryName, Method.POST);

            request.AddJsonBody(queryParams);

            var response = restClient.Execute<Response<T>>(request);
            try
            {
                if (response.ErrorException != null)
                {
                    MessageBox.Show("Kontrolloni statusin e serverit a eshte Startuar!");
                }
                return (int)response.Data.noOfRowsAffected;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public static int RestaurantQuery(string queryName, string queryParams)
        {
            RestClient restClient = new RestClient(Connection.GetActiveConnection());
            var request = new RestRequest("queryy/" + queryName, Method.POST);

            request.AddJsonBody(queryParams);

            var response = restClient.Execute<Response<T>>(request);
            try
            {
                if (response.ErrorException != null)
                {
                    MessageBox.Show("Kontrolloni statusin e serverit a eshte Startuar!");
                }
                return (int)response.Data.noOfRowsAffected;
            }
            catch (Exception)
            {
                throw;
            }

        }



    }
}
