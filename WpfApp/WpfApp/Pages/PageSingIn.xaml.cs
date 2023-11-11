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
using WpfApp.Pages.Admin;
using WpfApp.Pages.User;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для PageSingIn.xaml
    /// </summary>
    public partial class PageSingIn : Page
    {
       
        public static PageSingIn Instance { get; private set; }
        public PageSingIn()
        {
            InitializeComponent();
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            var listL =  Connect.context.Employees.ToList();
            foreach (var item in listL)
                if (TextBoxLogin.Text == item.Login.Trim() && TextBoxLoginPassword.Password == item.Password.Trim())
                {
                    LabeWarning.Content = "";
                    switch (item.Role.Trim())
                    {
                        case "admin":
                            MainWindow.Instance.MainFrame.Content = new AdminPage(item.NameEmployee.Trim(),item.FamilyEmployee.Trim());
                            MainWindow.Instance.MaxWidth = int.MaxValue;
                            MainWindow.Instance.MinWidth = 600;
                            MainWindow.Instance.MaxHeight = int.MaxValue;
                            MainWindow.Instance.MinHeight = 400;
                            return;
                        case "user":
                            MainWindow.Instance.MainFrame.Content = new UserPage(item.NameEmployee.Trim(), item.FamilyEmployee.Trim());
                            MainWindow.Instance.MaxWidth = int.MaxValue;
                            MainWindow.Instance.MinWidth = 600;
                            MainWindow.Instance.MaxHeight = int.MaxValue;
                            MainWindow.Instance.MinHeight = 400;
                            return;
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

        private void Label23_Loaded(object sender, RoutedEventArgs e)
        {
            var windows1 = MainWindow.Instance;
            
            //NavigationWindow win = (NavigationWindow)Window.GetWindow(this);
            string currentPageName = this.Title;
           
            if (currentPageName == "PageSingIn") 
            {
                windows1.MinHeight = this.MinHeight;
                windows1.MaxHeight = this.MaxHeight;
                windows1.MaxWidth = this.MaxWidth;
                windows1.MinWidth = this.MinWidth;
                
            }  

                           
        }

        

    }
}
