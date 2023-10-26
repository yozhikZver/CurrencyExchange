using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для UsersControl.xaml
    /// </summary>
    public partial class UsersControl : Page
    {
        public UsersControl()
        {
            InitializeComponent();
            dataGrid.ItemsSource = Connect.c.Employees.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (GridAdd.Height == 0)
            {
                ShowSlidePanel(GridAdd);
            }
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

        private void RmoveBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FindBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            HideSlidePanel(GridAdd);
        }

        private void AddInTable_Click(object sender, RoutedEventArgs e)
        {
            Employees employees = new Employees();
            //employees.IdEmployee = Connect.context.Employees.Count();
            //employees.NameEmployee = TextBox_Name.Text;
            //employees.FamilyEmployee = TextBox_Surname.Text;
            //employees.Role = TextBox_Role.Text;
            //employees.CurrencyEmployee = TextBox_Currency.Text;
            //employees.Login = TextBox_Login.Text;
            //employees.Password = TextBox_Password.Text;
            employees.IdEmployee = 1;
            DataContext = employees;
            Connect.c.Employees.Add(employees);
            Connect.c.SaveChanges();
            dataGrid.ItemsSource = Connect.c.Employees.ToList();
        }
    }
}
