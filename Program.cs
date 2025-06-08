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
            //dal.creatAgent("654", "jo", "TLV", "Active");
            dal.UpdateAgentLocation(5, "boston");
            dal.makeMission(6);
            dal.GetAllAgents();
        }
    }
}