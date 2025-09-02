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
using System.Data.SqlClient;
using System.Data;

namespace interf.Avto_p
{
    
    public partial class watch_avto : Window
    {
        Database database = new Database();
        public watch_avto()
        {
            InitializeComponent();
            DBView();
        }
        private void DBView()
        {
            database.OpenConnection();
            string query = "SELECT * FROM Avto"; // Из какой таблицы нужен вывод 
            SqlCommand createCommand = new SqlCommand(query, database.sqlConnection);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("Avto"); // Из какой таблицы нужен вывод
            dataAdp.Fill(dt);
            AvtoGrid.ItemsSource = dt.DefaultView; // вывод 
            database.CloseConnection();

        }
        private void cancel(object sender, RoutedEventArgs e)
        {
            avto авто = new avto();
            авто.Show();
            this.Close();
            авто.Background = this.Background;
        }

        private void exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cl_del(object sender, RoutedEventArgs e)
        {
            delete_avto удалить = new delete_avto();
            удалить.Show();
            this.Close();
            удалить.Background = this.Background;
        }

        private void cl_add(object sender, RoutedEventArgs e)
        {
            add_avto добавление = new add_avto();
            добавление.Show();
            this.Close();
            добавление.Background = this.Background;            
        }
    }
}
