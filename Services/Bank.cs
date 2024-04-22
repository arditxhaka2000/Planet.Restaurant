using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class Bank
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int StationId { get; set; }
        public string BankAccountNumber { get; set; }
        public int Pos { get; set; }

        public static List<Bank> Get()
        {
            return null;
        }

        public static List<Bank> Get(string pos)
        {
            //List<Bank> retList = new List<Bank>();

            //retList.Add(new Bank() { Id = 1, Name = "TEB pos" });
            //retList.Add(new Bank() { Id = 2, Name = "BKT pos" });

            string searchParams = "pos=" + pos;
            List<Bank> retList = RestHepler<Bank>.Search("banks",searchParams);

            return retList;           
        }

        public static Bank Get(int id)
        {
            return RestHepler<Bank>.Get("Banks", id);
        }
    }
}
