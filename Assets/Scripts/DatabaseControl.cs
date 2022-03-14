using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Mono.Data.Sqlite;

public class DatabaseControl : ScriptableObject
{
    //private string dbName = "URI=file:DictDB.db";
    public void CreateDB(string database, string col1, string col2)
     {
        string dbName = "URI=file:" + database + ".db";
         using (var conn = new SqliteConnection(dbName))
         {
             conn.Open();

             using (var cmd = conn.CreateCommand())
             {
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS " + database + "('" + col1 + "' VARCHAR(20), '" + col2 + "' VARCHAR(20));";
                cmd.ExecuteNonQuery();
             }
             conn.Close();
         }
     }

     public void AddWord(string database, string col1, string col2, string attr1, string attr2)
     {
        string dbName = "URI=file:" + database + ".db";
         using (var conn = new SqliteConnection(dbName))
         {
             conn.Open();

             using (var cmd = conn.CreateCommand())
             {
                cmd.CommandText = 
                "INSERT INTO " + database + "('" + col1 + "', '" + col2 + "') VALUES (@attr1, @attr2);";

                cmd.Parameters.AddWithValue("@attr1", attr1);
                cmd.Parameters.AddWithValue("@attr2", attr2);
                cmd.ExecuteNonQuery();
             }
             conn.Close();
         }
     }


     public void DisplayDatabase(string database, string col1, string col2)
     {
        string dbName = "URI=file:" + database + ".db";
         using (var conn = new SqliteConnection(dbName))
         {
             conn.Open();

             using (var cmd = conn.CreateCommand())
             {
                 cmd.CommandText = "SELECT * FROM " + database + ";";
                 
                 using (IDataReader reader = cmd.ExecuteReader())
                 {
                    while (reader.Read())
                        Debug.Log("Name is " + reader[col1] + "\tDamage is " + reader[col2]);

                 }
                 cmd.ExecuteNonQuery();
             }
             conn.Close();
         }
     }
}
