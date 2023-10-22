using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfApp.Class.DataBase;

namespace WpfApp.Class.TableControl
{
    internal class Table
    {
        public string NameTable;
        public List<string> ColumnsName;
        public List<Row> rows;
        public Table(string nameTable, List<string> deletColumn)
        {
            rows = new List<Row>();
            NameTable = nameTable;
            ColumnsName = Database.SQLSet(
                @"SELECT 
           COLUMN_NAME AS [Имя столбца]
   FROM INFORMATION_SCHEMA.COLUMNS
   WHERE table_name='"+ NameTable +"'");
            foreach (var delItem in deletColumn)
                ColumnsName.Remove(delItem);

        }

        public void AddRow(List<TextBox> items)
        {
            Row row = new Row();
            foreach (TextBox item in items) row.columns.Add(item);
            rows.Add(row);
        }

        public List<TextBox> GetRow(int numberRow)
        {
            var t = rows[numberRow];
            return t.columns;
        }

    }

    internal class Row
    {
        public List<TextBox> columns = new List<TextBox>();
        public Row() { }

    }
}
