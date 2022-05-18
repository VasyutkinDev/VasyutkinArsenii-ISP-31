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
    /// Interaction logic for DobavitClientaWindow.xaml
    /// </summary>
    public partial class SozdanieSchetaWindow : Window
    {
        private CurrencyAccount _account = new CurrencyAccount();

        public SozdanieSchetaWindow()
        {
            InitializeComponent();
            _account.OpeningDate = DateTime.Now;
            clientCombo.ItemsSource = BankirBDEntities5.GetContext().Clients.ToList();
            currencyCombo.ItemsSource= BankirBDEntities5.GetContext().TypeOfCurrencies.ToList();
            DataContext = _account;


        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_account.BIK))
                errors.AppendLine("Укажите БИК");
            if (string.IsNullOrWhiteSpace(_account.NumOfAccount))
                errors.AppendLine("Укажите номер счёта");
            if (_account.TypeOfCurrency == null)
                errors.AppendLine("Выберете тип валюты");
            if (_account.Client == null)
                errors.AppendLine("Выберете клиента");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_account.id == 0)
            {
                BankirBDEntities5.GetContext().CurrencyAccounts.Add(_account);
            }
            try
            {
                BankirBDEntities5.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
                dobavitWIndow.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
