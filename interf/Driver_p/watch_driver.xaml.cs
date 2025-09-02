using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace interf.Driver_p
{
    /// <summary>
    /// Логика взаимодействия для watch_driver.xaml
    /// </summary>
    public partial class watch_driver : Window
    {
        Database database = new Database();
        public watch_driver()
        {
            InitializeComponent();
            DBView();
        }
        private void DBView()
        {
            database.OpenConnection();
            string querty = "SELECT * FROM Drivers"; // Из какой таблицы нужен вывод 
            SqlCommand createCommand = new SqlCommand(querty, database.sqlConnection);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("Drivers"); // Из какой таблицы нужен вывод
            dataAdp.Fill(dt);
            DriverGrid.ItemsSource = dt.DefaultView; // вывод 
            database.CloseConnection();

        }

        private void cancel(object sender, RoutedEventArgs e)
        {
            driver водители = new driver();
            водители.Show();
            this.Close();
            водители.Background = this.Background;
            
        }

        private void cl_add(object sender, RoutedEventArgs e)
        {
            add_driver добавить = new add_driver ();
            добавить.Show();
            this.Close();
            добавить.Background = this.Background;
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
