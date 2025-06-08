using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace mysqlProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DAL dal = new DAL();
            dal.creatAgent("162", "jo", "TLV", "Active");
        }
    }
}