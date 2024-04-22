using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Services.Models;

namespace Services
{
    public class User : INamedObj
    {
        public int Id { get; set; }

        public string Name { get { return FirstName + " " + LastName; } set { } }
        public string TotalPrice { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int StationId { get; set; }
        public string Pos_Token { get; set; }
        public string Role { get; set; }

        public string Token { get; set; }


        public User()
        {

        }

        public static User Get(int id)
        {
            var user = Services.RestHepler<User>.Get("users", id);
            return user;
        
        }
        public static List<User> GetAll()
        {
            var user = Services.RestHepler<User>.Search("users", "");

            return user;
        }

        public static User ValidateLogin(string username, string password)
        {
            byte[] tmpSource;
            byte[] tmpHash;

            //Create a byte array from source data.
            tmpSource = ASCIIEncoding.ASCII.GetBytes(username + password);

            tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
            string strHash = BitConverter.ToString(tmpHash).Replace("-", "");

            var user = RestHepler<User>.ValidateLogin(username, strHash);

            return user;
        }

        public static List<Services.User> GetByStation(int stationId)
        {
            string searchParams = "stationId=" + stationId;
            var users = Services.RestHepler<User>.Search("users", searchParams);
            return users;
        }


        //public static List<Services.User> GetByPos_Token(int stationId,string postoken)
        //{
        //    string searchParams = "&StationId=" + stationId + "&Pos_Token="+ postoken;
        //    var users = Services.RestHepler<User>.Select("getByPosToken", searchParams);
        //    return users; 
        //}


    }
}
