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

namespace interf.Orders_p
{
    /// <summary>
    /// Логика взаимодействия для заказы.xaml
    /// </summary>
    public partial class orders : Window
    {
        public orders()
        {
            InitializeComponent();  
        }
        choice выбор = new choice();
        avtoriz авторизация = new avtoriz();
        private void cancel(object sender, RoutedEventArgs e)
        {
            
            выбор.Show();
            this.Close();
            выбор.Background = this.Background;
        }

        private void cl_add(object sender, RoutedEventArgs e)
        {
            add_orders добавление = new add_orders();
            добавление.Show();
            this.Close();
            добавление.Background = this.Background;
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

        private void cl_delete(object sender, RoutedEventArgs e)
        {
            delete_orders удаление = new delete_orders();
            удаление.Show();
            this.Close();
            удаление.Background = this.Background;
        }
    }
}
