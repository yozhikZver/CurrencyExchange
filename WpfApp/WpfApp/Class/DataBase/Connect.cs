using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Xml;
using System.Data.Entity;

namespace WpfApp.Class.DataBase
{
    public static class Connect
    {
        public static CurrencyExchangeEntities1 c;
        public static CurrencyExchangeEntities1 context
        {
            get
            {
                if (c == null)
                    c = new CurrencyExchangeEntities1 ();
                return c;
            }
        }
        public static void SQLUpdate(string nameTable, string cellEdit, string dataEdit, int ID)
        {
            string connectionString = @"Data Source=.\sqlexpress;Initial Catalog=CurrencyExchange;Integrated Security=True";

            try
            {
                string sqlExpression = $"UPDATE {nameTable} SET {cellEdit}='{dataEdit.Replace(',', '.')}' WHERE ID={ID}";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                    connection.Close();
                }
            }catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
           
        }

    }
}