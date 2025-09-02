using Guna.UI2.WinForms.Suite;
using interf.Driver_p;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TheArtOfDevHtmlRenderer.Adapters;

namespace interf.Orders_p
{
    /// <summary>
    /// Логика взаимодействия для delete_orders.xaml
    /// </summary>
    public partial class delete_orders : Window
    {
        Database database = new Database();
        public delete_orders()
        {
            InitializeComponent();
            database.OpenConnection();
            DBView();
        }
        private void cl_del(object sender, RoutedEventArgs e)
        {
            try
            {
                orders заказы = new orders();
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table = new DataTable();
                database.OpenConnection();
                var OrdersID = textbox_ID.Text;
                string query_prov = $"SELECT [ID заказа] FROM Orders where [ID заказа] = '{OrdersID}'";
                var query_delete = $"DELETE FROM Orders where [ID заказа]  = {OrdersID}";
                SqlCommand command = new SqlCommand(query_prov, database.GetConnection());
                adapter.SelectCommand = command;
                adapter.Fill(table);
                if (table.Rows.Count == 1)
                {
                    var rez = MessageBox.Show($"Удалить заказ с номером {OrdersID}?", "AVTORENT", MessageBoxButton.YesNo);
                    if (rez == MessageBoxResult.Yes)
                    {
                        SqlCommand createCommand = new SqlCommand(query_delete, database.sqlConnection);
                        createCommand.ExecuteNonQuery();
                        replay();
                    }
                }
                else
                {
                    MessageBox.Show($"Заказ с номером {OrdersID} не найден. Попробуйте еще раз.", "AVTORENT", MessageBoxButton.OK);
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
            orders заказы = new orders();
            var OrdersID = textbox_ID.Text;
            var rez = MessageBox.Show($"Заказ удален. Удалить еще один?", "AVTORENT", MessageBoxButton.YesNo);
            if (rez == MessageBoxResult.No) { заказы.Show(); this.Close(); заказы.Background = this.Background; }
            if (rez == MessageBoxResult.Yes)
            {
                textbox_ID.Clear();
            }
        }

        private void DBView()
        {
            database.OpenConnection();
            var OrdersID = textbox_ID.Text;
            string query = $"SELECT * FROM Orders";
            SqlCommand createCommand = new SqlCommand(query, database.sqlConnection);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("Orders");
            dataAdp.Fill(dt);
            OrdersGrid.ItemsSource = dt.DefaultView;
        }

        private void cl_add(object sender, RoutedEventArgs e)
        {
            add_orders добавить = new add_orders();
            добавить.Show();
            this.Close();
            добавить.Background = this.Background;
        }
        private void cancel(object sender, RoutedEventArgs e)
        {
            orders заказы = new orders();
            заказы.Show();
            this.Close();
            заказы.Background = this.Background;
        }
        private void cl_watch(object sender, RoutedEventArgs e)
        {
            watch_orders просмотр = new watch_orders();
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
