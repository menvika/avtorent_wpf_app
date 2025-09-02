using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace interf
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class avtoriz : Window
    {
        Database database = new Database();
        choice выбор = new choice();

        public avtoriz()
        {
            InitializeComponent();
        }

        private void log(object sender, EventArgs e)
        {
            tbUser.MaxLength = 15;
            tbPass.MaxLength = 30;
        }

        
        private void Hello(object sender, RoutedEventArgs e)
        {

            var User = tbUser.Text; 
            var Password = tbPass.Password;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string QueryString = $"SELECT user_login, user_password FROM Users where user_login = '{User}' and user_password = '{Password}'" ;
            SqlCommand command = new SqlCommand(QueryString, database.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count == 1)
            {
                var rez = MessageBox.Show($"Добро пожаловать, {User}!", "AVTORENT", MessageBoxButton.OK);
                if (rez == MessageBoxResult.OK)
                {
                    выбор.Show();
                    this.Close();
                    выбор.Background = this.Background;
                }
            }
            else { 
                MessageBox.Show($"Ошибка входа! Попробуйте еще раз!", "AVTORENT");
                tbUser.Clear();
                tbPass.Clear();
            }
        }
 

        private void cancel(object sender, RoutedEventArgs e)
        {
            theme theme = new theme();
            theme.Show();
            this.Close();
            theme.Background = this.Background;
        }
        private void exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

