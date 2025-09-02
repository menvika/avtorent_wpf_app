using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using interf.Driver_p;
using interf.Orders_p;

namespace interf.Avto_p
{
    /// <summary>
    /// Логика взаимодействия для delete_avto.xaml
    /// </summary>
    public partial class delete_avto : Window
    {
        Database database = new Database();
        public delete_avto()
        {
            InitializeComponent();
            database.OpenConnection();
            DBView();
        }
        private void cl_del(object sender, RoutedEventArgs e)
        {
            try
            {
                avto авто = new avto();
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table = new DataTable();
                database.OpenConnection();
                var AvtoID = textbox_ID.Text;
                string query_prov = $"SELECT [ID авто] FROM Avto where [ID авто]  = '{AvtoID}'";
                var query_delete = $"DELETE FROM Avto where [ID авто] = {AvtoID}";
                SqlCommand command = new SqlCommand(query_prov, database.GetConnection());
                adapter.SelectCommand = command;
                adapter.Fill(table);
                if (table.Rows.Count == 1)
                {
                    var rez = MessageBox.Show($"Удалить автомобиль с номером {AvtoID}?", "AVTORENT", MessageBoxButton.YesNo);
                    if (rez == MessageBoxResult.Yes)
                    {
                        SqlCommand createCommand = new SqlCommand(query_delete, database.sqlConnection);
                        createCommand.ExecuteNonQuery();
                        replay();
                    }
                }
                else
                {
                    MessageBox.Show($"Автомобиль с номером {AvtoID} не найден. Попробуйте еще раз.", "AVTORENT", MessageBoxButton.OK);
                    textbox_ID.Clear();
                }
                database.CloseConnection();
            }
            catch
            {
                MessageBox.Show($"Ошибка ввода данных! Пожалуйста, повторите попытку.", "AVTORENT", MessageBoxButton.OK);
                textbox_ID.Clear();
            }
            
        }
        private void replay()
        {
            avto авто = new avto();
            var DriverID = textbox_ID.Text;
            var rez = MessageBox.Show($"Автомобиль удален. Удалить еще один?", "AVTORENT", MessageBoxButton.YesNo);
            if (rez == MessageBoxResult.No) { авто.Show(); this.Close(); авто.Background = this.Background; }
            if (rez == MessageBoxResult.Yes)
            {
                textbox_ID.Clear();
            }
        }


        private void DBView()
        {
            database.OpenConnection();
            var AvtoID = textbox_ID.Text;
            string query = $"SELECT [ID авто],[Государственный номер],[Год выпуска],[Тип],[Стоимость аренды],[Стоимость аренды за МКАДом],[Дополнительные услуги] FROM Avto ";
            SqlCommand createCommand = new SqlCommand(query, database.sqlConnection);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("Avto");
            dataAdp.Fill(dt);
            AvtoGrid.ItemsSource = dt.DefaultView;
        }

        private void cl_add(object sender, RoutedEventArgs e)
        {
            add_avto добавить = new add_avto();
            добавить.Show();
            this.Close();
            добавить.Background = this.Background;
        }
        private void cancel(object sender, RoutedEventArgs e)
        {
            avto заказы = new avto();
            заказы.Show();
            this.Close();
            заказы.Background = this.Background;
        }
        private void cl_watch(object sender, RoutedEventArgs e)
        {
            watch_avto просмотр = new watch_avto();
            просмотр.Show();
            this.Close();
            просмотр.Background = this.Background;
        }
        private void exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

