﻿using System;
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

namespace WpfApp.Pages.User
{
    /// <summary>
    /// Логика взаимодействия для MainUserPage.xaml
    /// </summary>
    public partial class MainUserPage : Page
    {
        public MainUserPage()
        {
            InitializeComponent();

        }
        private void Update()
        {
       
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            myComboBox.Text = "Выберите элемент";
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Update();
        }
    }
}
