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

    public string stringItemAmount;

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

    public void CreateInventoryDB(string database, string itemID, string itemName, string itemAmount, string itemAttribute)
    {
    string dbName = "URI=file:" + database + ".db";
        using (var conn = new SqliteConnection(dbName))
        {
            conn.Open();

            using (var cmd = conn.CreateCommand())
            {
            cmd.CommandText = "CREATE TABLE IF NOT EXISTS " + database + "('" + itemID + "' INT(20) PRIMARY KEY, '" + itemName + "' VARCHAR(20), '" + itemAmount + "' INT(20), '" + itemAttribute + "' VARCHAR(20));";
            cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
    }

    public void AddInventoryItem(string database, string itemIDCol, string itemNameCol, string itemAmountCol, string itemAttributeCol, int itemID, string itemName, int itemAmount, string itemAttribute)
    {
    string dbName = "URI=file:" + database + ".db";
        using (var conn = new SqliteConnection(dbName))
        {
            conn.Open();

            using (var cmd = conn.CreateCommand())
            {
                
                if(!ItemExists(database, itemID))
                {
                
                    cmd.CommandText = 
                    "INSERT INTO " + database + "('" + itemIDCol + "', '" + itemNameCol + "', '" + itemAmountCol + "', '" + itemAttributeCol + "') VALUES (@itemID, @itemName, @itemAmount, @itemAttribute);";

                    cmd.Parameters.AddWithValue("@itemID", itemID);
                    cmd.Parameters.AddWithValue("@itemName", itemName);
                    cmd.Parameters.AddWithValue("@itemAmount", itemAmount);
                    cmd.Parameters.AddWithValue("@itemAttribute", itemAttribute);

                    cmd.ExecuteNonQuery();
                    conn.Close();

                }
                else
                {
                    Debug.Log("CATCH");
                    cmd.CommandText = "SELECT * FROM " + database + ";";
                
                    using (IDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            stringItemAmount = "" + reader[itemAmountCol];
                            
                    }
                    cmd.ExecuteNonQuery();
                    Debug.Log(stringItemAmount);
                    int newitemAmount = 1;
                    bool parse = int.TryParse(stringItemAmount, out newitemAmount);
                    newitemAmount += 1;
                    
                    cmd.CommandText = 
                     "UPDATE " + database + " SET 'Item Amount' = " + newitemAmount + " WHERE ItemID = '" + itemID + "';";
                    //"UPDATE InventoryDB SET 'Item Amount' = 10 WHERE ItemID = 1;";
                    //"INSERT INTO " + database + " (" + itemIDCol + ") SELECT ('" + itemID + "') WHERE NOT EXISTS (SELECT 1 FROM " + database + " WHERE " + itemIDCol + " = '" + itemID + "');";

                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
                
                
            
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

    public void DisplayInventoryDatabase(string database, string itemID, string itemName, string itemAmount, string itemAttribute)
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
                    Debug.Log("Item ID is " + reader[itemID] + "\tItem Name: " + reader[itemName] + "\tItem Amount: " + reader[itemAmount] + "\tItem Attribute: " + reader[itemAttribute]);

                }
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
    }

    public bool ItemExists(string database, int itemID) 
    {
        bool exists = false;
        string dbName = "URI=file:" + database + ".db";

        using (var conn = new SqliteConnection(dbName))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                try
                {
                    cmd.CommandText = 
                    "SELECT 1 FROM " + database + " WHERE ItemID='" + itemID + "';";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    exists = true;
                }
                catch
                {
                    exists = false;
                }
            }            
        }
        return exists;
    } 
}

