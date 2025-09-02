using Guna.UI2.WinForms.Suite;
using interf.Driver_p;
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

namespace interf.Avto_p
{
    /// <summary>
    /// Логика взаимодействия для add_avto.xaml
    /// </summary>
    public partial class add_avto : Window
    {
        Database database = new Database();
        public add_avto()
        {
            InitializeComponent();
            database.OpenConnection();
        }
        private void cl_add(object sender, RoutedEventArgs e)
        {
            try
            {
                var ID = textbox_ID.Text;
                var Year = textbox_Year.Text;
                var Type = textbox_Type.Text;
                var Sum = textbox_Sum.Text;
                var SumMKAD = textbox_SumMKAD.Text;
                var Requirements = textbox_Requirements.Text;
                var query = $"INSERT INTO Avto ([Государственный номер],[Год выпуска],Тип, [Стоимость аренды], [Стоимость аренды за МКАДом], [Дополнительные услуги]) values ('{ID}', '{Year}', '{Type}', '{Sum}', '{SumMKAD}', '{Requirements}')";

                avto авто = new avto();
                var rez = MessageBox.Show($"Добавить автомобиль?", "AVTORENT", MessageBoxButton.YesNo);
                if (rez == MessageBoxResult.Yes)
                {
                    SqlCommand createCommand = new SqlCommand(query, database.sqlConnection);
                    createCommand.ExecuteNonQuery();
                    rez = MessageBox.Show($"Автомобиль добавлен. Добавить еще один?", "AVTORENT", MessageBoxButton.YesNo);
                    if (rez == MessageBoxResult.No) { авто.Show(); this.Close(); авто.Background = this.Background; }
                    if (rez == MessageBoxResult.Yes)
                    {
                        textbox_ID.Clear();
                        textbox_Year.Clear();
                        textbox_Type.Clear();
                        textbox_Sum.Clear();
                        textbox_SumMKAD.Clear();
                        textbox_Requirements.Clear();
                    }
                }
                database.CloseConnection();
            }
            catch
            {
                MessageBox.Show($"Ошибка ввода данных! Пожалуйста, повторите попытку.", "AVTORENT", MessageBoxButton.OK);
                textbox_ID.Clear();
                textbox_Year.Clear();
                textbox_Type.Clear();
                textbox_Sum.Clear();
                textbox_SumMKAD.Clear();
                textbox_Requirements.Clear();
            }
            
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

        private void cl_watch(object sender, RoutedEventArgs e)
        {
            watch_avto просмотр = new watch_avto();
            просмотр.Show();
            this.Close();
            просмотр.Background = this.Background;
        }
    }
}
