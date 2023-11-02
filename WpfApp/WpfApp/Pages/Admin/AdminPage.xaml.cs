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
using WpfApp.Pages.Admin;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public UsersControl UserControl;
        public CurrencyControl CurrencyControl;
        public CourseControl CourseControl;
        private bool isMenuPanelOpen = false;
        public AdminPage(string Name, string SurName)
        {
            InitializeComponent();
            LabelNameSurName.Content = SurName + " " + Name;
            UserControl = new UsersControl();
            CurrencyControl = new CurrencyControl();
            CourseControl = new CourseControl();
            AdminFrame.Navigate(UserControl);
        }

        private void StackPanel_MouseEnter(object sender, MouseEventArgs e)
            {
                if (!isMenuPanelOpen && MenuGrid.Width == 0)
                {
                    ShowSlidePanel();
                    isMenuPanelOpen=true;
                }
            }
            private void MenuGrid_MouseLeave(object sender, MouseEventArgs e)
            {
                if (isMenuPanelOpen && MenuGrid.Width==250)
                {
                    HideSlidePanel();
                    isMenuPanelOpen = false;
                }
            }
            private void ShowSlidePanel()
            {
                DoubleAnimation animation = new DoubleAnimation();
                animation.From = 0;
                animation.To = 250; // задайте необходимую ширину для выдвигаемой панели
                animation.Duration = new Duration(TimeSpan.FromSeconds(0.2)); // задайте необходимую продолжительность анимации

                Storyboard.SetTargetName(animation, MenuGrid.Name);
                Storyboard.SetTargetProperty(animation, new PropertyPath(Grid.WidthProperty));

                Storyboard storyboard = new Storyboard();
                storyboard.Children.Add(animation);

                storyboard.Begin(this);

                animation = new DoubleAnimation();
                animation.From = 15;
                animation.To = 0; // задайте необходимую ширину для выдвигаемой панели
                animation.Duration = new Duration(TimeSpan.FromSeconds(0.1)); // задайте необходимую продолжительность анимации

                Storyboard.SetTargetName(animation, LeftBorder.Name);
                Storyboard.SetTargetProperty(animation, new PropertyPath(Border.WidthProperty));

                storyboard = new Storyboard();
                storyboard.Children.Add(animation);

                storyboard.Begin(this);

            }
            private void HideSlidePanel()
            {
                DoubleAnimation animation = new DoubleAnimation();
                animation.From = 250;
                animation.To = 0; // задайте необходимую ширину для выдвигаемой панели
                animation.Duration = new Duration(TimeSpan.FromSeconds(0.2)); // задайте необходимую продолжительность анимации

                Storyboard.SetTargetName(animation, MenuGrid.Name);
                Storyboard.SetTargetProperty(animation, new PropertyPath(Grid.WidthProperty));

                Storyboard storyboard = new Storyboard();
                storyboard.Children.Add(animation);

                storyboard.Begin(this);

                animation = new DoubleAnimation();
                animation.From = 0;
                animation.To = 15; // задайте необходимую ширину для выдвигаемой панели
                animation.Duration = new Duration(TimeSpan.FromSeconds(0.1)); // задайте необходимую продолжительность анимации

                Storyboard.SetTargetName(animation, LeftBorder.Name);
                Storyboard.SetTargetProperty(animation, new PropertyPath(Border.WidthProperty));

                storyboard = new Storyboard();
                storyboard.Children.Add(animation);

                storyboard.Begin(this);
            }

        private void ButtonCurrency_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.Navigate(CurrencyControl);
        }
        private void ButtonCuurse_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.Navigate(CourseControl);
        }
        private void ButtonUsers_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.Navigate(UserControl);
        }
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.MainFrame.Navigate(MainWindow.Instance.pageSingIn) ;
        }
    }
}
