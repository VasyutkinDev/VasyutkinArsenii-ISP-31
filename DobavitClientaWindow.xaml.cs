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
    public partial class DobavitClientaWindow : Window
    {
        private Client _client = new Client();

        public DobavitClientaWindow()
        {
            InitializeComponent();
            _client.DateBirthday = DateTime.Now;
            DataContext = _client;
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_client.FullName))
                errors.AppendLine("Укажите ФИО");
            if (string.IsNullOrWhiteSpace(_client.NumOfPass))
                errors.AppendLine("Укажите номер пасспорта");
            if (string.IsNullOrWhiteSpace(_client.INN))
                errors.AppendLine("Укажите ИНН");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_client.id == 0)
            {
                BankirBDEntities5.GetContext().Clients.Add(_client);
            }
            try
            {
                BankirBDEntities5.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
                dobavitClientaWindow.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
    
}
