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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Bankir_CurrencyExchangeAccounting
{
    /// <summary>
    /// Interaction logic for DobavlenieCourseWindow.xaml
    /// </summary>
    public partial class DobavlenieCourseWindow : Window
    {
        private CurrencyCours _course = new CurrencyCours();

        public DobavlenieCourseWindow()
        {
            InitializeComponent();
            _course.DateOfCourse = DateTime.Now;
            DataContext = _course;
            typeCombo.ItemsSource = BankirBDEntities5.GetContext().TypeOfCurrencies.ToList();


        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (_course.TypeOfCurrency == null)
                errors.AppendLine("Выберете тип валюты");            
            if(courseRF.Text == "") 
                errors.AppendLine("Введите курс по цб рф");
            if (courseSale.Text == "")
                errors.AppendLine("Введите курс на продажу");
            if (courseBuy.Text == "")
                errors.AppendLine("Введите курс на покупку");
            if (_course.ZaSkolko == null)
                errors.AppendLine("Выберете за сколько");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_course.id == 0)
            {
                BankirBDEntities5.GetContext().CurrencyCourses.Add(_course);
            }
            try
            {
                BankirBDEntities5.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
                dobavitCourseWindow.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void courseRF_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ".")))
                e.Handled = true;

        }

        private void courseSale_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ".")))
                e.Handled = true;
        }

        private void courseBuy_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ".")))
                e.Handled = true;
        }
    }
}
