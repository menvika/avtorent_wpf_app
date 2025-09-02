using interf.Avto_p;
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
using System.Web.UI.WebControls;
using interf.Orders_p;

namespace interf.Driver_p
{
    /// <summary>
    /// Логика взаимодействия для delete_driver.xaml
    /// </summary>
    public partial class delete_driver : Window
    {

        Database database = new Database();
        public delete_driver()
        {
            InitializeComponent();
            database.OpenConnection();
            DBView();
        }
        private void cl_del(object sender, RoutedEventArgs e)
        {
            try
            {
                driver водители = new driver();
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table = new DataTable();
                database.OpenConnection();
                var DriverID = Int32.Parse(textbox_ID.Text);
                string query_prov = $"SELECT [ID водителя] FROM Drivers where [ID водителя]  = '{DriverID}'";
                var query_delete = $"DELETE FROM Drivers where [ID водителя]  = {DriverID}";
                SqlCommand command = new SqlCommand(query_prov, database.GetConnection());
                adapter.SelectCommand = command;
                adapter.Fill(table);
                int count = table.Rows.Count;
                if (count == 1)
                {
                    var rez = MessageBox.Show($"Удалить водителя с номером {DriverID}?", "AVTORENT", MessageBoxButton.YesNo);
                    if (rez == MessageBoxResult.Yes)
                    {
                        SqlCommand createCommand = new SqlCommand(query_delete, database.sqlConnection);
                        createCommand.ExecuteNonQuery();
                        replay();
                    }
                }
                else
                {
                    MessageBox.Show($"Водитель с номером {DriverID} не найден. Попробуйте еще раз.", "AVTORENT", MessageBoxButton.OK);
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
        private void replay ()
        {
            driver водители = new driver();
            var DriverID = textbox_ID.Text;
            var rez = MessageBox.Show($"Водитель удален. Удалить еще один?", "AVTORENT", MessageBoxButton.YesNo);
            if (rez == MessageBoxResult.No) { водители.Show(); this.Close(); водители.Background = this.Background; }
            if (rez == MessageBoxResult.Yes)
            {
                textbox_ID.Clear();
            }
        }
        private void DBView()
        {
            database.OpenConnection();
            var DriverID = textbox_ID.Text;
            string query = $"SELECT * FROM Drivers";
            SqlCommand createCommand = new SqlCommand(query, database.sqlConnection);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("Drivers");
            dataAdp.Fill(dt);
            DriverGrid.ItemsSource = dt.DefaultView;
        }

        private void cl_add(object sender, RoutedEventArgs e)
        {
            add_driver добавить = new add_driver();
            добавить.Show();
            this.Close();
            добавить.Background = this.Background;
        }
        private void cancel(object sender, RoutedEventArgs e)
        {
            driver заказы = new driver();
            заказы.Show();
            this.Close();
            заказы.Background = this.Background;
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


    }
}

