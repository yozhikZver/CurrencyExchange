using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using WpfApp.Class.DataBase;
using WpfApp.Pages.Admin;

namespace WpfApp.Class.TableControl
{
    internal class TablesControl
    {
        private StackPanel mainPanel;
        private Table table;
        public TablesControl(StackPanel _mainPanel) {
            table = new Table("Employees", new List<string>() { "IdEmployee", "Role" });
            mainPanel = _mainPanel;
        }

        private void Textbox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {

                var textBoxs = VisualTreeHelper.GetParent(textBox).GetLogicalChildCollection<TextBox>();
                foreach (var item in textBoxs)
                {
                    item.Focus();
                }
            }
        }
        private void Textbox_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                if (!textBox.IsFocused)
                {
                    textBox.IsReadOnly = true;

                   
                }
            }
        }
        private void Textbox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                textBox.IsReadOnly = false;
            }
        }

        private TextBox CreateTextBoxTable(string text, int ColumnInt)
        {
            TextBox textbox = new TextBox();
            var FE = new FrameworkElement();
            textbox.Style = UsersControl.Instance.TryFindResource("TableLabel") as System.Windows.Style;
            textbox.Text = text;
            textbox.MouseDoubleClick += Textbox_MouseDoubleClick;
            textbox.IsKeyboardFocusedChanged += Textbox_IsKeyboardFocusedChanged;
            textbox.KeyDown += Textbox_KeyDown;
            textbox.LostFocus += Textbox_LostFocus;
            textbox.MouseDown += Textbox_MouseDown;
            textbox.FontSize = 20;

            Grid.SetColumn(textbox, ColumnInt);
            return textbox;
        }

        private void Textbox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                if (!textBox.IsFocused)
                {
                    textBox.IsReadOnly = true;

                    for (int i = 0; i < table.rows.Count; i++)
                    {
                        for (int j = 0; j < table.rows[i].columns.Count; j++)
                        {
                            if ((TextBox)table.rows[i].columns[j] == textBox)
                            {
                                SendSQLData(i, j, textBox.Text);
                                return;
                            }
                        }
                    }
                }
            }
        }

        private void Textbox_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (e.Key == Key.Enter) 
            {
                textBox.IsReadOnly = true;
                textBox.FontWeight = FontWeights.Normal;
                Keyboard.ClearFocus();

                for (int i = 0; i < table.rows.Count; i++)
                {
                    for (int j = 0; j < table.rows[i].columns.Count; j++)
                    {
                        if ((TextBox)table.rows[i].columns[j] == textBox)
                        {
                            SendSQLData(i, j, textBox.Text);
                            return;
                        }
                    }
                }
            }

        }

        public void AddRows()
        {
            for (int i = 0; i < Database.GetLenght("Employees"); i++)
            {
                AddRow(i);
            }
        }
        private void AddRow(int i)
        {
            //Создание грида
            var grid = new Grid();

            var columnDefinition = new ColumnDefinition();
            columnDefinition.Width = new GridLength(1, GridUnitType.Star);
            grid.ColumnDefinitions.Add(columnDefinition);

            var columnDefinition1 = new ColumnDefinition();
            columnDefinition1.Width = new GridLength(1, GridUnitType.Star);
            grid.ColumnDefinitions.Add(columnDefinition1);

            var columnDefinition2 = new ColumnDefinition();
            columnDefinition2.Width = new GridLength(0.5, GridUnitType.Star);
            grid.ColumnDefinitions.Add(columnDefinition2);

            var columnDefinition3 = new ColumnDefinition();
            columnDefinition3.Width = new GridLength(1, GridUnitType.Star);
            grid.ColumnDefinitions.Add(columnDefinition3);

            var columnDefinition4 = new ColumnDefinition();
            columnDefinition4.Width = new GridLength(1, GridUnitType.Star);
            grid.ColumnDefinitions.Add(columnDefinition4);

            mainPanel.Children.Add(grid);

            var rowT = Database.GetRow(i);

            var tx1 = CreateTextBoxTable(rowT[1], 0);
            var tx2 = CreateTextBoxTable(rowT[2], 1);
            var tx3 = CreateTextBoxTable(rowT[4], 2);
            var tx4 = CreateTextBoxTable(rowT[5], 3);
            var tx5 = CreateTextBoxTable(rowT[6], 4);

            grid.Children.Add(tx1);
            grid.Children.Add(tx2);
            grid.Children.Add(tx3);
            grid.Children.Add(tx4);
            grid.Children.Add(tx5);

            List<TextBox> textBoxes = new List<TextBox>() 
            {
            tx1,tx2,tx3,tx4, tx5
            };

            table.AddRow(textBoxes);

        }

        private void SendSQLData(int idRow, int idColumn, string str)
        {
            Database.SQLSet("UPDATE " +table.NameTable +" SET " + table.ColumnsName[idColumn] + " = " + str + " WHERE " + table.ColumnsName[idColumn+1] + "=" + table.rows[idRow].columns[idColumn+1].Text);

             //   MessageBox.Show("Столбец:" + table.ColumnsName[idColumn] + " Строка:" + idRow.ToString());

        }
    }
}

