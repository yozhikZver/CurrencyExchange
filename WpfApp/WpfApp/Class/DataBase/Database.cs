using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            List<(string,string, string)> list = new List<(string, string, string)>();
            while (reader.Read())
            {
                list.Add((reader[0].ToString().Trim(), reader[1].ToString().Trim(), reader[2].ToString().Trim()));
            }
            reader.Close();
            connection.Close();
            return list;
        }
    }
}
