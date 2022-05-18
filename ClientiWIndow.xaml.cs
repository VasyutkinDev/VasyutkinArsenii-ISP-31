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
    /// Interaction logic for ClientiWIndow.xaml
    /// </summary>
    public partial class ClientiWIndow : Window
    {
        public ClientiWIndow()
        {
            InitializeComponent();
            dgClients.ItemsSource = BankirBDEntities5.GetContext().Clients.ToList();
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            GlavnoeMenu glMenu = new GlavnoeMenu();
            glMenu.Show();
            clientiWindow.Close();

        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            DobavitClientaWindow dobavitClienta = new DobavitClientaWindow();
            dobavitClienta.ShowDialog();    
            
        }

        private void refreshBtn_Click(object sender, RoutedEventArgs e)
        {
            BankirBDEntities5.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            dgClients.ItemsSource = BankirBDEntities5.GetContext().Clients.ToList();
        }
    }
}
