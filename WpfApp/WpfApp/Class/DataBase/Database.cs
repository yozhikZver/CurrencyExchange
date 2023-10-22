using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Xml;

namespace WpfApp.Class.DataBase
{
    public static class Database
    {

        public static List<(string, string, string)> GetLogins()
        {
            SqlConnection connection = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=CurrencyExchange;Integrated Security=True");

            SqlCommand command = new SqlCommand("SELECT Login, Password, Role FROM Employees", connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<(string, string, string)> list = new List<(string, string, string)>();
            while (reader.Read())
            {
                list.Add((reader[0].ToString().Trim(), reader[1].ToString().Trim(), reader[2].ToString().Trim()));
            }
            reader.Close();
            connection.Close();
            return list;
        }
        public static List<string> GetRow(int q)
        {
            SqlConnection connection = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=CurrencyExchange;Integrated Security=True");
            string strSql;
            if (q == 0)
            {
                strSql = "SELECT * FROM Employees ";
            }
            else
            {
                strSql = "SELECT TOP " + q + " *\r\nFROM (\r\n  SELECT TOP " + (q + 1).ToString() + " * \r\n  FROM Employees\r\n  ORDER BY IdEmployee\r\n) z\r\nORDER BY IdEmployee DESC";

            }
            SqlCommand command = new SqlCommand(strSql, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<string> list = new List<string>();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    list.Add(reader[i].ToString().Trim());
                }
            }
            reader.Close();
            connection.Close();
            return list;
        }

        public static int GetLenght(string nameTable)
        {
            SqlConnection connection = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=CurrencyExchange;Integrated Security=True");

            SqlCommand command = new SqlCommand("SELECT COUNT(0) FROM " + nameTable + ";", connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            var lenght = int.Parse(reader[0].ToString().Trim());


            reader.Close();
            connection.Close();
            return lenght;
        }

        public static List<string> SQLSet(string str)
        {
            try
            {
            SqlConnection connection = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=CurrencyExchange;Integrated Security=True");

            SqlCommand command = new SqlCommand(str, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            List<string> list = new List<string>();


            
                do
                {
                    list.Add(reader[0].ToString().Trim());
                } while (reader.Read());
                reader.Close();
                connection.Close();
                return list;
            }
            catch(SqlException e)
            {
                MessageBox.Show(e.Message);
                return null;

            }
            catch (Exception)
            {
                return new List<string>();
            }




        }

    }
}