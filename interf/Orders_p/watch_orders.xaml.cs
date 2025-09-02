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

namespace interf.Orders_p
{
    /// <summary>
    /// Логика взаимодействия для watch_orders.xaml
    /// </summary>
    public partial class watch_orders : Window
    {
        Database database = new Database();
        public watch_orders()
        {
            InitializeComponent();
            DBView();
        }
        private void DBView()
        {
            database.OpenConnection();
            string query = "SELECT * FROM Orders";  
            SqlCommand createCommand = new SqlCommand(query, database.sqlConnection);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("Orders");
            dataAdp.Fill(dt);
            OrdersGrid.ItemsSource = dt.DefaultView; 
            database.CloseConnection();
        }


        private void cancel(object sender, RoutedEventArgs e)
        {
            orders заказы = new orders();
            заказы.Show();
            this.Close();
            заказы.Background = this.Background;
        }
        private void exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cl_add(object sender, RoutedEventArgs e)
        {
            add_orders добавить = new add_orders();
            добавить.Show();
            this.Close();
            добавить.Background = this.Background;
        }
        private void cl_del(object sender, RoutedEventArgs e)
        {
            delete_orders удаление = new delete_orders();
            удаление.Show();
            this.Close();
            удаление.Background = this.Background;
        }
    }
}
