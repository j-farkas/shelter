using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace Animal.Models
{
  public class Furballs
  {
    private string _type;
    private string _name;
    private string _date;
    private string _breed;
    private char _sex;
    private int _id;

    public Furballs()
    {

    }


    public int GetId()
    {
      return _id;
    }
    public void SetId(int id)
    {
      _id = id;
    }
    public string GetType()
    {
      return _type;
    }
    public void SetType(string type)
    {
      _type = type;
    }
    public string GetName()
    {
      return _name;
    }
    public void SetName(string name)
    {
      _name = name;
    }
    public string GetDate()
    {
      return _date;
    }
    public void SetDate(string date)
    {
      _date = date;
    }
    public string GetBreed()
    {
      return _breed;
    }
    public void SetBreed(string breed)
    {
      _breed = breed;
    }
    public char GetSex()
    {
      return _sex;
    }
    public void SetSex(char sex)
    {
     _sex = sex;
    }

    public static List<Furballs> GetAll(string sortby)
        {
          List<Furballs> allItems = new List<Furballs> {};
          MySqlConnection conn = DB.Connection();
          conn.Open();
          MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"SELECT * FROM animals order by " + sortby +" asc;";
          MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
          while(rdr.Read())
          {

            Furballs newItem = new Furballs();
            newItem.SetId(rdr.GetInt32(0));
            newItem.SetType(rdr.GetString(1));
            newItem.SetName(rdr.GetString(2));
            newItem.SetDate(rdr.GetDateTime(3).ToString("F"));
            newItem.SetBreed(rdr.GetString(4));
            newItem.SetSex(rdr.GetChar(5));
            allItems.Add(newItem);
          }
          conn.Close();
          if (conn != null)
          {
            conn.Dispose();
          }
          return allItems;
        }

        public static void AddToDB(Furballs toAdd)
            {
              MySqlConnection conn = DB.Connection();
              conn.Open();
              MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
              cmd.CommandText = @"INSERT INTO `animals` (`type`, `name`, `date_of_admittance`, `breed`, `sex`) VALUES ('"+toAdd.GetType()+"', '"+toAdd.GetName()+"', CURRENT_TIMESTAMP, '"+toAdd.GetBreed()+"', '"+toAdd.GetSex()+"');";
              cmd.ExecuteNonQuery();
              conn.Close();
              if (conn != null)
              {
                conn.Dispose();
              }
            }


  }
}
