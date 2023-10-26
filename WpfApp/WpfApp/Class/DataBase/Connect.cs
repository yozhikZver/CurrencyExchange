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

    }
}