using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xaml;
using WpfApp.Class.DataBase;
using WpfApp.Pages.User;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для PageSingIn.xaml
    /// </summary>
    public partial class PageSingIn : Page
    {
        public PageSingIn()
        {
            InitializeComponent();
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            var listL =  Database.GetLogins();
            foreach (var (Login, Password, Role) in listL)
                if (TextBoxLogin.Text == Login && TextBoxLoginPassword.Password == Password)
                {
                    LabeWarning.Content = "";
                    switch (Role)
                    {
                        case "a":
                            MainWindow.Instance.MainFrame.Content = new AdminPage();
                            break;
                        case "u":
                            MainWindow.Instance.MainFrame.Content = new UserPage();
                            break;
                        default:
                            break;
                    }
                }
                else
                    LabeWarning.Content = "Неправильный логин или пароль";
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.Close();
        }
    }
}
