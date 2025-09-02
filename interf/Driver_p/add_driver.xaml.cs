using Guna.UI2.WinForms.Suite;
using interf.Orders_p;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace interf.Driver_p
{
    /// <summary>
    /// Логика взаимодействия для add_driver.xaml
    /// </summary>
    public partial class add_driver : Window
    {
        Database database = new Database();
        public add_driver()
        {
            InitializeComponent();
            database.OpenConnection();
        }

        private void cl_add(object sender, RoutedEventArgs e)
        {
            try
            {
                var Name = textbox_Name.Text;
                var Phone = textbox_Phone.Text;
                var Pass = textbox_Pass.Text;
                var query = $"INSERT INTO Drivers (ФИО,[Номер телефона],[Паспортные данные]) values ('{Name}', '{Phone}', '{Pass}')";

                driver водители = new driver();
                var rez = MessageBox.Show($"Добавить водителя?", "AVTORENT", MessageBoxButton.YesNo);
                if (rez == MessageBoxResult.Yes)
                {
                    SqlCommand createCommand = new SqlCommand(query, database.sqlConnection);
                    createCommand.ExecuteNonQuery();
                    rez = MessageBox.Show($"Водитель добавлен. Добавить еще один?", "AVTORENT", MessageBoxButton.YesNo);
                    if (rez == MessageBoxResult.No) { водители.Show(); this.Close(); водители.Background = this.Background; }
                    if (rez == MessageBoxResult.Yes)
                    {
                        textbox_Name.Clear();
                        textbox_Phone.Clear();
                        textbox_Pass.Clear();
                    }
                }
                database.CloseConnection();
            }
            catch
            {
                MessageBox.Show($"Ошибка ввода данных! Пожалуйста, повторите попытку.", "AVTORENT", MessageBoxButton.OK);
                textbox_Name.Clear();
                textbox_Phone.Clear();
                textbox_Pass.Clear();
            }
            
        }
        private void cancel(object sender, RoutedEventArgs e)
        {
            driver водители = new driver();
            водители.Show();
            this.Close();
            водители.Background = this.Background;
        }
        private void cl_watch(object sender, RoutedEventArgs e)
        {
            watch_driver просмотр = new watch_driver();
            просмотр.Show();
            this.Close();
            просмотр.Background = this.Background;
        }
        private void exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cl_del(object sender, RoutedEventArgs e)
        {
            delete_driver удалить = new delete_driver();
            удалить.Show();
            this.Close();
            удалить.Background = this.Background;
        }
    }
}
