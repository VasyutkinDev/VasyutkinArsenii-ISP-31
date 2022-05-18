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
    /// Interaction logic for OperationsWindow.xaml
    /// </summary>
    public partial class OperationsWindow : Window
    {
        public OperationsWindow()
        {
            InitializeComponent();
            dgOperations.ItemsSource = BankirBDEntities5.GetContext().Operations.ToList();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            DobavlenieOperationWindow dobavlenieOperationWindow = new DobavlenieOperationWindow();
            dobavlenieOperationWindow.ShowDialog();
        }

        private void refreshBtn_Click(object sender, RoutedEventArgs e)
        {
            BankirBDEntities5.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            dgOperations.ItemsSource = BankirBDEntities5.GetContext().Operations.ToList();
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            GlavnoeMenu glavnoeMenu = new GlavnoeMenu();
            glavnoeMenu.Show();
            operationsWindow.Close();
        }
    }
}
