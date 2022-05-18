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
    /// Interaction logic for GlavnoeMenu.xaml
    /// </summary>
    public partial class GlavnoeMenu : Window
    {
        public GlavnoeMenu()
        {
            InitializeComponent();
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();   
            mainWindow.Show();
            glWindow.Close();
        }

        private void clientsInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            ClientiWIndow clWindow = new ClientiWIndow();
            clWindow.Show();
            glWindow.Close();
        }

        private void operationsInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            OperationsWindow opWindow = new OperationsWindow();
            opWindow.Show();
            glWindow.Close();
        }

        private void clientAccountsBtn_Click(object sender, RoutedEventArgs e)
        {
            ClientAcountsWindow clAcWindow = new ClientAcountsWindow(); 
            clAcWindow.Show();
            glWindow.Close();
        }

        private void coursesInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            CurrencyCoursesWindow curCoursesWIndow = new CurrencyCoursesWindow();   
            curCoursesWIndow.Show();
            glWindow.Close();
        }
    }
}
