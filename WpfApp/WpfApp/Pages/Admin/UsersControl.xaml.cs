using System;
using System.Collections;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp.Class;
using WpfApp.Class.DataBase;
using WpfApp.Class.TableControl;

namespace WpfApp.Pages.Admin
{
    
    /// <summary>
    /// Логика взаимодействия для UsersControl.xaml
    /// </summary>
    public partial class UsersControl : Page
    {
        public static UsersControl Instance { get; set; }
        public UsersControl()
        {
            InitializeComponent();
            Instance = this;
            TablesControl tabControl = new TablesControl(mainPanel);
            tabControl.AddRows();
            
        }
       
    }    

       
}
