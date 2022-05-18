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
    /// Interaction logic for CurrencyCoursesWindow.xaml
    /// </summary>
    public partial class CurrencyCoursesWindow : Window
    {
        public CurrencyCoursesWindow()
        {
            InitializeComponent();
            dgCourses.ItemsSource = BankirBDEntities5.GetContext().CurrencyCourses.ToList();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            DobavlenieCourseWindow dobCourseWindow = new DobavlenieCourseWindow();
            dobCourseWindow.ShowDialog();
        }

        private void refreshBtn_Click(object sender, RoutedEventArgs e)
        {
            BankirBDEntities5.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            dgCourses.ItemsSource = BankirBDEntities5.GetContext().CurrencyCourses.ToList();
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            GlavnoeMenu glMenu = new GlavnoeMenu();
            glMenu.Show();
            curCoursesWIndow.Close();
        }
    }
}
