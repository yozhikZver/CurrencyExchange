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
    /// Логика взаимодействия для CourseControl.xaml
    /// </summary>
    public partial class CourseControl : Page
    {
        public CourseControl()
        {
            InitializeComponent();
            Update();
        }
        private bool isAdd = true;

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            textBox_Course.Text = "";
            textBox_Currency.Items.Clear();
            foreach (var item in Connect.context.TypesCurrencies)
            {
                textBox_Currency.Items.Add(item.NameCurrencie.Trim());
            }
            isAdd = true;
            if (GridAdd.Width == 0 || GridAdd.HorizontalAlignment == HorizontalAlignment.Center)
                ShowSlidePanel(GridAdd);
            else
                HideSlidePanel(GridAdd);
            Button_Сonfirm.Content = "Добавить";
            GridAdd.HorizontalAlignment = HorizontalAlignment.Left;


        }
        private void Update() {
            Connect.c = null; 
            dataGrid.ItemsSource = Connect.context.CurseCurrencie.ToList(); 
        }
        private void RmoveBtn_Click(object sender, RoutedEventArgs e)
        {
            var rows = dataGrid.SelectedItems.Cast<CurseCurrencie>().ToList();
            if (MessageBox.Show($"Удалить {rows.Count} строк из таблицы?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No) == MessageBoxResult.Yes)
                Connect.context.CurseCurrencie.RemoveRange(rows);
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
            var Row = dataGrid.SelectedItems.Cast<CurseCurrencie>().ToList();
            if (Row.Count != 1)
            {
                MessageBox.Show("Выделите одну строчку для редактирования!");
                return;
            }
            textBox_Currency.Items.Clear();
            foreach (var item in Connect.context.TypesCurrencies)
                textBox_Currency.Items.Add(item.NameCurrencie.Trim());
            SetSelectComboBox(Row[0].ID);
            textBox_Course.Text = Row[0].CourseUSD.ToString();
            Button_Сonfirm.Content = "Изменить";

            isAdd = false;
            if (GridAdd.Width == 0 || GridAdd.HorizontalAlignment == HorizontalAlignment.Left)
                ShowSlidePanel(GridAdd);
            else
                HideSlidePanel(GridAdd);
            GridAdd.HorizontalAlignment = HorizontalAlignment.Center;

        }
        private void SetSelectComboBox(int CurId)
        {
            foreach (var item in Connect.context.TypesCurrencies)
                if (item.ID == CurId)
                    textBox_Currency.SelectedItem = item.NameCurrencie.Trim();

        }
        private void Cancel_Click(object sender, RoutedEventArgs e) { HideSlidePanel(GridAdd); }
        private int SelectDatdGridId()
        {
            CurseCurrencie empl = (CurseCurrencie)dataGrid.SelectedItem;
            return empl.ID;
        }

        private int GetLastIdEmpl()
        {
            int index = 0;
            foreach (var item in Connect.context.CurseCurrencie)
                if (item.ID == index)
                    index++;
                else
                    return index;
            return index;
        }

        private void ClearTextBox()
        {
            textBox_Course.Text = "";
            textBox_Currency.Text = "";
        }
        private void AddRow()
        {
            CurseCurrencie сurseCurrencie = new CurseCurrencie()
            {
                ID = GetLastIdEmpl(),
                CourseUSD = decimal.Parse(textBox_Course.Text)
            };

            Connect.context.CurseCurrencie.Add(сurseCurrencie);

            ClearTextBox();

            try
            {
                Connect.context.SaveChanges();

            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        MessageBox.Show($"Свойство: {validationError.PropertyName} Ошибка: {validationError.ErrorMessage}");
            }
            catch (Exception dbEx)
            {
                MessageBox.Show(dbEx.Message);
            }

        }
        private string GetIdFromnComboBoxCurrencie()
        {
            foreach (var item in Connect.context.TypesCurrencies)
                if (item.NameCurrencie.Trim() == textBox_Currency.SelectedItem.ToString())
                    return item.ID.ToString();
            return null;
        }
        private void EditRow()
        {
            if (GetIdFromnComboBoxCurrencie() == null) return;
            Connect.SQLUpdate("CurseCurrencie", "ID_Currencie", GetIdFromnComboBoxCurrencie(), SelectDatdGridId());
            Connect.SQLUpdate("CurseCurrencie", "CourseUSD", textBox_Course.Text, SelectDatdGridId());
        }
        private void Button_Сonfirm_Click(object sender, RoutedEventArgs e)
        {
            if (isAdd)
                AddRow();
            else
                EditRow();
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

        private void textBox_Count_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Update();
        }
    }
}