using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;

internal class DAL
{
    public string strCon = "server=localhost;user=root;passward=;database=eagleeyedb;";
    MySqlConnection conn;
    string query;

    public DAL()
    {
        this.conn = new MySqlConnection(this.strCon);
    }

    public void createAgent(string codeName, string realName, string location, string status)
    {
        this.query = $"INSERT INTO agents (codeName, realName, location, status, missionsCompleted) VALUES ('{codeName}', '{realName}', '{location}', '{status}', 0);";
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

    public void delAgent(int id)
    {
        try
        {
            this.conn.Open();
            this.query = $"DELETE FROM agents WHERE id = {id};";
            MySqlCommand cmd = new MySqlCommand(this.query, this.conn);
            cmd.ExecuteNonQuery();
            this.conn.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine($"error: {e}");
        }
    }

    public void UpdateAgentLocation(int id, string location)
    {
        try
        {
            this.conn.Open();
            this.query = $"UPDATE agents SET location = '{location}' WHERE id = {id};";
            MySqlCommand cmd = new MySqlCommand(this.query, this.conn);
            cmd.ExecuteNonQuery();
            this.conn.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine($"error: {e}");
        }
    }

 


    public List<agent> GetAllAgents()
    {
        List<agent> agents = new List<agent>();
        try
        {
            this.conn.Open();  
            this.query = $"SELECT * FROM agents;";
            MySqlCommand cmd = new MySqlCommand(this.query, this.conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string codeName = reader.GetString("codeName");
                string realName = reader.GetString("realName");
                string location = reader.GetString("location");   
                string status = reader.GetString("status");
                 int missionsCompleted = reader.GetInt32("missionsCompleted");
                agent a = new agent(codeName, realName, location, status);
                a.missionsCompleted = missionsCompleted;
                agents.Add(a);
                Console.WriteLine($"codeName: {codeName}. realName: {realName}. location: {location}. status: {status} .missions: {missionsCompleted}.");
            }
            this.conn.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine($"error: {e}");
        }
        return agents;
    }

    public void makeMission(int id)
    {
        int missionsCompleted = 0;
        try
        {
            this.conn.Open();
            this.query = $"SELECT missionsCompleted FROM agents WHERE id = {id};";
            MySqlCommand cmd = new MySqlCommand(this.query, this.conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                missionsCompleted = reader.GetInt32("missionsCompleted") + 1;  
            }
            this.conn.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine($"error: {e}");
        }

        try
        {
            this.conn.Open();
            this.query = $"UPDATE agents SET missionsCompleted = {missionsCompleted} WHERE id = {id};";
            MySqlCommand cmd = new MySqlCommand(this.query, this.conn);
            cmd.ExecuteNonQuery();
            this.conn.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine($"error: {e}");
        }
    }

}