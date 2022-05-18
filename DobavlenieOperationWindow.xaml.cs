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
    /// Interaction logic for DobavlenieOperationWindow.xaml
    /// </summary>
    public partial class DobavlenieOperationWindow : Window
    {
        private Operation _op = new Operation();   
        public DobavlenieOperationWindow()
        {
            InitializeComponent();
            _op.date = DateTime.Now;
            DataContext = _op;
            schetCombo.ItemsSource = BankirBDEntities5.GetContext().CurrencyAccounts.ToList();


        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (_op.CurrencyAccount == null)
                errors.AppendLine("Выберет счёт");
            if (typeCombo.Text == "")
                errors.AppendLine("Выберете тип операции");
            if (sumBox.Text == "")
                errors.AppendLine("Введите сумму");
            

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_op.id == 0)
            {
                BankirBDEntities5.GetContext().Operations.Add(_op);
            }
            try
            {
                BankirBDEntities5.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
                dobavitOperationWindow.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void sumBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ".")))
                e.Handled = true;
        }

    }
}
