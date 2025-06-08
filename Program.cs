using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;

namespace mysqlProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DAL dal = new DAL();
            menue(dal);
        }

        static void menue(DAL dal)
        {
            Console.WriteLine("to create Agent enter 1.");
            Console.WriteLine("to Update Agent Location enter 2.");
            Console.WriteLine("to delete Agent enter 3.");
            Console.WriteLine("to Get All Agents enter 4.");
            Console.WriteLine("to make Mission enter 5.");
            Console.WriteLine("to exit enter 6.");
            string n = Console.ReadLine();
            int num = int.Parse(n);
            switch (num)
            {
                case 1:
                    Console.WriteLine("enter codeName");
                    string codeName = Console.ReadLine();
                    Console.WriteLine("enter realName.");
                    string realName = Console.ReadLine();
                    Console.WriteLine("enter location.");
                    string location = Console.ReadLine();
                    Console.WriteLine("enter status.");
                    string status = Console.ReadLine();
                    dal.createAgent(codeName, realName, location, status);
                    menue(dal);
                    break;
                case 2:
                    Console.WriteLine("enter Location.");
                    string Location = Console.ReadLine();
                    Console.WriteLine("enter id.");
                    int id = int.Parse(Console.ReadLine());
                    dal.UpdateAgentLocation(id, Location);
                    menue(dal);
                    break;
                case 3:
                    Console.WriteLine("enter id.");
                    int i = int.Parse(Console.ReadLine());
                    menue(dal);
                    dal.delAgent(i);
                    break;
                case 4:
                    dal.GetAllAgents();
                    menue(dal);
                    break;
                case 5:
                    Console.WriteLine("enter id.");
                    int d = int.Parse(Console.ReadLine());
                    dal.makeMission(d);
                    menue(dal);
                    break;
                case 6:
                    break;
                default:
                    Console.WriteLine("invalid choise.");
                    menue(dal);
                    break;
            }
        }
    }
}