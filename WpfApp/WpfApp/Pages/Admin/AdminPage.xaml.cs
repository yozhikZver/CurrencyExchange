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

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        private bool isMenuPanelOpen = false;
        public AdminPage()
        {
            InitializeComponent();
        }

        private void StackPanel_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!isMenuPanelOpen)
            {
                ShowSlidePanel();
                isMenuPanelOpen=true;
            }
        }
        private void MenuGrid_MouseLeave(object sender, MouseEventArgs e)
        {
            if (isMenuPanelOpen)
            {
                HideSlidePanel();
                isMenuPanelOpen = false;
            }
        }
        private void ShowSlidePanel()
        {
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = 50;
            animation.To = 250; // задайте необходимую ширину для выдвигаемой панели
            animation.Duration = new Duration(TimeSpan.FromSeconds(0.2)); // задайте необходимую продолжительность анимации

            Storyboard.SetTargetName(animation, MenuGrid.Name);
            Storyboard.SetTargetProperty(animation, new PropertyPath(Grid.WidthProperty));

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animation);

            storyboard.Begin(this);
        }
        private void HideSlidePanel()
        {
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = 250;
            animation.To = 50; // задайте необходимую ширину для выдвигаемой панели
            animation.Duration = new Duration(TimeSpan.FromSeconds(0.2)); // задайте необходимую продолжительность анимации

            Storyboard.SetTargetName(animation, MenuGrid.Name);
            Storyboard.SetTargetProperty(animation, new PropertyPath(Grid.WidthProperty));

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animation);

            storyboard.Begin(this);
        }


    }
}
