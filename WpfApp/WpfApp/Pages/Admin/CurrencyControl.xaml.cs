using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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

namespace WpfApp.Pages.Admin
{
    /// <summary>
    /// Логика взаимодействия для CurrencyControl.xaml
    /// </summary>
    public partial class CurrencyControl : Page
    {
        public CurrencyControl()
        {
            InitializeComponent();
            Update();
        }
        private bool isAdd = true;
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            textBox_Name.Text = "";
            textBox_Count.Text = "";
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
        private void Update() { Connect.c = null; dataGrid.ItemsSource = Connect.context.TypesCurrencies.ToList(); }
        private void RmoveBtn_Click(object sender, RoutedEventArgs e)
        {
            var rows = dataGrid.SelectedItems.Cast<TypesCurrencies>().ToList();
            foreach (var item in rows)
            if(Connect.context.Employees.Any(x => x.Currencie == item.ID))
                {
                    MessageBox.Show("Данные используются в таблце \"Пользователи\"");
                    return;
                }
            if (MessageBox.Show($"Удалить {rows.Count} строк из таблицы?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No) == MessageBoxResult.Yes)
                Connect.context.TypesCurrencies.RemoveRange(rows);
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
            var Row = dataGrid.SelectedItems.Cast<TypesCurrencies>().ToList();
            if (Row.Count != 1)
            {
                MessageBox.Show("Выделите одну строчку для редактирования!");
                return;
            }
            textBox_Name.Text = Row[0].NameCurrencie.ToString().Trim();
            textBox_Count.Text = Row[0].Count.ToString().Trim();
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
            List<TypesCurrencies> list = new List<TypesCurrencies>();
            foreach (var item in Connect.context.TypesCurrencies)
            {

                if (
                    (
                    textBox_NameF.Text == "" &&
                    textBox_CountF.Text == "")
                    ||
                    (
                    (item.NameCurrencie.StartsWith(textBox_NameF.Text) && textBox_NameF.Text != "") ||
                    (item.Count==int.Parse(textBox_CountF.Text) && textBox_CountF.Text != "") 
                    ))
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

            if (isAdd)
            {
                int indedx = 0;
                foreach (var item in Connect.context.TypesCurrencies)
                {

                    if (item.ID == indedx)
                    {
                        indedx++;
                    }
                    else
                    {
                        break;
                    }
                }
                TypesCurrencies typesCurrencies = new TypesCurrencies()
                {
                    ID = indedx,
                    NameCurrencie = textBox_Name.Text,
                    Count = int.Parse(textBox_Count.Text)
                };
                Connect.context.TypesCurrencies.Add(typesCurrencies);
                textBox_Name.Text = "";
                textBox_Count.Text = "";
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
                Connect.SQLUpdate("TypesCurrencies", "NameCurrencie", textBox_Name.Text, dataGrid.SelectedIndex);
                Connect.SQLUpdate("TypesCurrencies", "Count", textBox_Count.Text, dataGrid.SelectedIndex);
                HideSlidePanel(GridAdd);
            }
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

        private void textBox_Count_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}