using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

internal class DAL
{
    public string strCon = "server=localhost;user=root;passward=;database=eagleeyedb;";
    MySqlConnection conn;
    string query;

    public DAL()
    {
        this.conn = new MySqlConnection(this.strCon);
    }

    public void creatAgent(string codeName, string realName, string location, string status)
    {
        agent agent = new agent(codeName, realName, location, status);
        this.query = $"INSERT INTO agents (codeName, realName, location, status) VALUES ('{codeName}', '{realName}', '{location}', '{status}');";
        try
        {
            this.conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, this.conn);
            cmd.ExecuteNonQuery();
            this.conn.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine($"error: {e}");
        }
    }
    



    public List<string> sqlQuery()
    {
        string query = Console.ReadLine();
        List<string> mylist = new List<string>();
        try
        {
            
            this.conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, this.conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            
            while (reader.Read())
            {
                string str = reader.GetString(0);
                mylist.Add(str);
            }
            
        }
        catch (Exception e)
        {
            Console.WriteLine($"error: {e}");           
        }
        return mylist;
    }

}