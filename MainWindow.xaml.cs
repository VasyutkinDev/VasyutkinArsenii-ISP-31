using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace Bankir_CurrencyExchangeAccounting
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonEnter_Click(object sender, RoutedEventArgs e)
        {

            if (textBoxLogin.Text.Length > 0)
            {
                if (passBox.Password.Length > 0)
                {
                    DataTable dt_user = Select("SELECT * FROM [dbo].[Users] WHERE [login] = '" + textBoxLogin.Text + "' AND [password] = '" + passBox.Password + "'");
                    if (dt_user.Rows.Count > 0) // если такая запись существует       
                    {
                        GlavnoeMenu glMenu = new GlavnoeMenu();
                        glMenu.Show();
                        mainWindow.Close();
                    }
                    else
                    {
                        MessageBox.Show("Пользователя не найден");
                    }
                }
                else
                {
                    MessageBox.Show("Не введен пароль!");

                }
            }
            else
            {
                MessageBox.Show("Не введен логин!");
            }            
        }
        public DataTable Select(string selectSQL) // функция подключения к базе данных и обработка запросов
        {
            DataTable dataTable = new DataTable("dataBase");                // создаём таблицу в приложении
                                                                            // подключаемся к базе данных
            SqlConnection sqlConnection = new SqlConnection("server=DESKTOP-EUJ3RDU;Trusted_Connection=Yes;DataBase=BankirBD;");
            sqlConnection.Open();                                           // открываем базу данных
            SqlCommand sqlCommand = sqlConnection.CreateCommand();          // создаём команду
            sqlCommand.CommandText = selectSQL;                             // присваиваем команде текст
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand); // создаём обработчик
            sqlDataAdapter.Fill(dataTable);                                 // возращаем таблицу с результатом
            return dataTable;
        }

        private void logClearButt_Click(object sender, RoutedEventArgs e)
        {
            textBoxLogin.Clear();

        }

        private void showPass_Click(object sender, RoutedEventArgs e)
        {
            passBox2.Text = passBox.Password;
            passBox.Visibility = Visibility.Hidden;
            passBox2.Visibility = Visibility.Visible;
            showPassIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.EyeOff;
            Button btn = sender as Button;
            btn.Click -= new RoutedEventHandler(showPass_Click);
            btn.Click += new RoutedEventHandler(showPass_Click_1);
        }
        private void showPass_Click_1(object sender, RoutedEventArgs e)
        {

            passBox.Password = passBox2.Text;
            passBox.Visibility = Visibility.Visible;
            passBox2.Visibility = Visibility.Hidden;
            showPassIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.Eye;
            Button btn = sender as Button;
            btn.Click -= new RoutedEventHandler(showPass_Click_1);
            btn.Click += new RoutedEventHandler(showPass_Click);
        }
    }
}
