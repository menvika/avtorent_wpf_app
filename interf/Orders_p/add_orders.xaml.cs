using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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

namespace interf.Orders_p
{
    /// <summary>
    /// Логика взаимодействия для add_orders.xaml
    /// </summary>
    public partial class add_orders : Window
    {
        Database database = new Database();
        
        public add_orders()
        {
            InitializeComponent();
            database.OpenConnection();
            box_driver.ItemsSource = new Driver[]
            {
                new Driver { ID = 1, Surname = "Васильев" },
                new Driver { ID = 4, Surname = "Смирнов" },
                new Driver { ID = 5, Surname = "Кузнецов" },
                new Driver { ID = 6, Surname = "Михайлов" },
                new Driver { ID = 10, Surname = "Дмитриев" },
            };
            box_avto.ItemsSource = new Avto[]
            {
                new Avto { ID = "А999АА", Type = "автобус" },
                new Avto { ID = "В844ИО", Type = "микроавтобус" },
                new Avto { ID = "Д666ДД", Type = "легковая" },
                new Avto { ID = "Н123ИВ", Type = "легковая" },
            };
        }
        private void cl_add(object sender, RoutedEventArgs e)
        {
            try
            {
                var Date = DateTime.Parse(textbox_Date.Text);
                var Time = textbox_Time.Text;
                var Driver = box_driver.SelectedValue.ToString();
                var AvtoID = box_avto.SelectedValue.ToString();
                var Sum = textbox_Sum.Text;
                var Customer = textbox_Customer.Text; // Заказчик.
                var Route = textbox_Route.Text; // Маршрут.
                var Requirements = textbox_Requirements.Text; // Дополнительные требования.
                var query = $"INSERT INTO Orders ([Дата заказа],[Время заказа], [ФИО заказчика], [Государственный номер авто], [ID водителя], Маршрут, Сумма, [Дополнительные услуги] ) values ('{Date}', '{Time}', '{Customer}', '{AvtoID}', '{Driver}', '{Route}', '{Sum}', '{Requirements}')";

                orders заказы = new orders();
                var rez = MessageBox.Show($"Добавить заказ?", "AVTORENT", MessageBoxButton.YesNo);
                if (rez == MessageBoxResult.Yes)
                {
                    SqlCommand createCommand = new SqlCommand(query, database.sqlConnection);
                    createCommand.ExecuteNonQuery();
                    rez = MessageBox.Show($"Заказ добавлен. Добавить еще один?", "AVTORENT", MessageBoxButton.YesNo);
                    if (rez == MessageBoxResult.No) { заказы.Show(); this.Close(); заказы.Background = this.Background; }
                    if (rez == MessageBoxResult.Yes)
                    {
                        textbox_Time.Clear();
                        textbox_Sum.Clear();
                        textbox_Customer.Clear();
                        textbox_Route.Clear();
                        textbox_Requirements.Clear();
                    }
                }
            }
            catch { 
                MessageBox.Show($"Ошибка ввода данных! Пожалуйста, повторите попытку.", "AVTORENT", MessageBoxButton.OK);
                textbox_Time.Clear();
                textbox_Sum.Clear();
                textbox_Customer.Clear();
                textbox_Route.Clear();
                textbox_Requirements.Clear();
            }
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

        private void cl_del(object sender, RoutedEventArgs e)
        {
            delete_orders удаление = new delete_orders();
            удаление.Show();
            this.Close();
            удаление.Background = this.Background;
        }
    }
}

public class Driver
{
    public int ID { get; set; } = 0;
    public string Surname { get; set; } = "";
    public override string ToString() => $"{ID} ({Surname})";
}

public class Avto
{
    public string ID { get; set; } = "";
    public string Type { get; set; } = "";
    public override string ToString() => $"{ID} ({Type})";
}
