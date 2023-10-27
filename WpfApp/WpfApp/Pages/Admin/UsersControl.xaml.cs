using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp.Class.DataBase;
using static System.Net.Mime.MediaTypeNames;

namespace WpfApp.Pages.Admin
{
    /// <summary>
    /// Логика взаимодействия для UsersControl.xaml
    /// </summary>
    public partial class UsersControl : Page
    {
        public UsersControl()
        {
            InitializeComponent();
            Update();
        }
        private bool isAdd = true;

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
                textBox_Name.Text = "";
                textBox_SurName.Text = "";
                textBox_Role.Text = "";
                textBox_Login.Text = "";
                textBox_Password.Text = "";
            textBox_Currency.Items.Clear();
            foreach (var item in Connect.context.TypesCurrencies)
            {
                textBox_Currency.Items.Add(item.NameCurrencie.Trim());
            }
                isAdd = true;
            if (GridFind.Width != 0)
                HideSlidePanel(GridFind);
            if (GridAdd.Width == 0 || GridAdd.HorizontalAlignment == HorizontalAlignment.Center)
                {
                    ShowSlidePanel(GridAdd);
                }
                else
                {
                    HideSlidePanel(GridAdd);
                }
                Button_Сonfirm.Content = "Добавить";
            GridAdd.HorizontalAlignment = HorizontalAlignment.Left;


        }
        private void Update() { dataGrid.ItemsSource = Connect.c.Employees.ToList(); }
        private void RmoveBtn_Click(object sender, RoutedEventArgs e)
        {
            var rows = dataGrid.SelectedItems.Cast<Employees>().ToList();
            if (MessageBox.Show($"Удалить {rows.Count} строк из таблицы?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No) == MessageBoxResult.Yes)
                Connect.context.Employees.RemoveRange(rows);
            try
            {
                Connect.context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Update();
        }
        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var Row = dataGrid.SelectedItems.Cast<Employees>().ToList();
            if (Row.Count != 1 )
            {
                MessageBox.Show("Выделите одну строчку для редактирования!");
                return;
            }
            textBox_Currency.Items.Clear();
            foreach (var item in Connect.context.TypesCurrencies)
            {
                textBox_Currency.Items.Add(item.NameCurrencie.Trim());
            }
            textBox_Currency.SelectedItem = Row[0].CurrencyEmployee;
            textBox_Name.Text = Row[0].NameEmployee.ToString().Trim();
            textBox_SurName.Text = Row[0].FamilyEmployee.ToString().Trim();
            textBox_Role.Text = Row[0].Role.ToString().Trim();
            textBox_Login.Text = Row[0].Login.ToString().Trim();
            textBox_Password.Text = Row[0].Password.ToString().Trim();
            Button_Сonfirm.Content = "Изменить";
            
            isAdd = false;
            if (GridFind.Width != 0)
                HideSlidePanel(GridFind);
            if (GridAdd.Width == 0 || GridAdd.HorizontalAlignment == HorizontalAlignment.Left)
            {
                ShowSlidePanel(GridAdd);
            }
            else
            {
                HideSlidePanel(GridAdd);
            }
            GridAdd.HorizontalAlignment = HorizontalAlignment.Center;

        }
        private void Cancel_ClickFind(object sender, RoutedEventArgs e)
        {
            HideSlidePanel(GridFind);
        }
        private void FindFilter()
        {
            List<Employees> list = new List<Employees>();
            foreach (var item in Connect.context.Employees)
            {

                if (
                    (
                    textBox_NameF.Text == "" &&
                    textBox_SurNameF.Text == "" &&
                    textBox_RoleF.Text == "" &&
                    textBox_CurrencyF.Text == "" &&
                    textBox_LoginF.Text == "" &&
                    textBox_PasswordF.Text == "")
                    ||
                    (
                    (item.NameEmployee.StartsWith(textBox_NameF.Text) && textBox_NameF.Text != "") ||
                    (item.FamilyEmployee.StartsWith(textBox_SurNameF.Text) && textBox_SurNameF.Text != "") ||
                    (item.Role.StartsWith(textBox_RoleF.Text) && textBox_RoleF.Text != "") ||
                    (item.CurrencyEmployee.StartsWith(textBox_CurrencyF.Text) && textBox_CurrencyF.Text != "") ||
                    (item.Login.StartsWith(textBox_LoginF.Text) && textBox_LoginF.Text != "") ||
                    (item.Password.StartsWith(textBox_PasswordF.Text) && textBox_PasswordF.Text != "")))
                {
                    list.Add(item);
                }

            }
            dataGrid.ItemsSource = list;
        }
        private void Button_СonfirmFind_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }
        private void FindBtn_Click(object sender, RoutedEventArgs e)
        {
            if (GridAdd.Width != 0)
            HideSlidePanel(GridAdd);
            if (GridFind.Width == 0)
            {
                if (GridFind.Width == 0)
                    ShowSlidePanel(GridFind);
            }
            else
            {
                HideSlidePanel(GridFind);
            }
        }
        private void Cancel_Click(object sender, RoutedEventArgs e) { HideSlidePanel(GridAdd); }
        private void Button_Сonfirm_Click(object sender, RoutedEventArgs e)
        {
            int indedx = 0;
            foreach (var item in Connect.context.Employees)
            {

                if (item.IdEmployee == indedx)
                {
                    indedx++;
                }
                else
                {
                    break;
                }
            }
            if (isAdd)
            {
                string strCurrency = "";
                foreach (var item in Connect.context.TypesCurrencies)
                {
                    if (item.NameCurrencie.Trim() == textBox_Currency.Text)
                    {
                        strCurrency = item.IDCurrencie.Trim();
                        break;
                    }
                }
                Employees employees = new Employees()
                {
                    IdEmployee = indedx,
                    NameEmployee = textBox_Name.Text,
                    FamilyEmployee = textBox_SurName.Text,
                    Role = textBox_Role.Text,
                    CurrencyEmployee = strCurrency,
                    Login = textBox_Login.Text,
                    Password = textBox_Password.Text
                };
                Connect.context.Employees.Add(employees);
                textBox_Name.Text = "";
                textBox_SurName.Text = "";
                textBox_Role.Text = "";
                textBox_Currency.SelectedItem = null;
                textBox_Login.Text = "";
                textBox_Password.Text = "";
                try
                {
                    Connect.context.SaveChanges();

                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            MessageBox.Show($"Свойство: {validationError.PropertyName} Ошибка: {validationError.ErrorMessage}");
                        }
                    }
                }
                catch (Exception dbEx)
                {
                    MessageBox.Show(dbEx.Message);
                }
            }
            else
            {
                var rows = dataGrid.SelectedItems.Cast<Employees>().ToList();
                    Connect.context.Employees.RemoveRange(rows);
                try
                {
                    Connect.context.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                string strCurrency = "";
                foreach (var item in Connect.context.TypesCurrencies)
                {
                    if (item.NameCurrencie.Trim() == textBox_Currency.Text)
                    {
                        strCurrency = item.IDCurrencie.Trim();
                        break;
                    }
                }
                Employees employees = new Employees()
                {
                    IdEmployee = indedx,
                    NameEmployee = textBox_Name.Text,
                    FamilyEmployee = textBox_SurName.Text,
                    Role = textBox_Role.Text,
                    CurrencyEmployee = strCurrency,
                    Login = textBox_Login.Text,
                    Password = textBox_Password.Text
                };
                Connect.context.Employees.Add(employees);
                textBox_Name.Text = "";
                textBox_SurName.Text = "";
                textBox_Role.Text = "";
                textBox_Currency.SelectedItem = null;
                textBox_Login.Text = "";
                textBox_Password.Text = "";
                try
                {
                    Connect.context.SaveChanges();

                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            MessageBox.Show($"Свойство: {validationError.PropertyName} Ошибка: {validationError.ErrorMessage}");
                        }
                    }
                }
                catch (Exception dbEx)
                {
                    MessageBox.Show(dbEx.Message);
                }
            }
            HideSlidePanel(GridAdd);
            Update();

        }
        private void ShowSlidePanel(Grid grid)
        {
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = 0;
            animation.To = 500;  // задайте необходимую ширину для выдвигаемой панели
            animation.Duration = new Duration(TimeSpan.FromSeconds(0.3)); // задайте необходимую продолжительность анимации

            Storyboard.SetTargetName(animation, grid.Name);
            Storyboard.SetTargetProperty(animation, new PropertyPath(Grid.WidthProperty));

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animation);

            storyboard.Begin(this);

            animation = new DoubleAnimation();

            animation.From = 0;
            animation.To = 400; // задайте необходимую ширину для выдвигаемой панели
            animation.Duration = new Duration(TimeSpan.FromSeconds(0.3)); // задайте необходимую продолжительность анимации

            Storyboard.SetTargetName(animation, grid.Name);
            Storyboard.SetTargetProperty(animation, new PropertyPath(Border.HeightProperty));

            storyboard = new Storyboard();
            storyboard.Children.Add(animation);

            storyboard.Begin(this);

        }
        private void HideSlidePanel(Grid grid)
        {
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = 500;
            animation.To = 0; // задайте необходимую ширину для выдвигаемой панели
            animation.Duration = new Duration(TimeSpan.FromSeconds(0.3)); // задайте необходимую продолжительность анимации

            Storyboard.SetTargetName(animation, grid.Name);
            Storyboard.SetTargetProperty(animation, new PropertyPath(Grid.WidthProperty));

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animation);

            storyboard.Begin(this);

            animation = new DoubleAnimation();

            animation.From = 400;
            animation.To = 0; // задайте необходимую ширину для выдвигаемой панели
            animation.Duration = new Duration(TimeSpan.FromSeconds(0.3)); // задайте необходимую продолжительность анимации

            Storyboard.SetTargetName(animation, grid.Name);
            Storyboard.SetTargetProperty(animation, new PropertyPath(Border.HeightProperty));

            storyboard = new Storyboard();
            storyboard.Children.Add(animation);

            storyboard.Begin(this);
        }
        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            FindFilter();
        }
    }
}

