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

namespace interf.Driver_p
{
    /// <summary>
    /// Логика взаимодействия для водители.xaml
    /// </summary>
    public partial class driver : Window
    {
        public driver()
        {
            InitializeComponent();
        }

        private void cancel(object sender, RoutedEventArgs e)
        {
            choice выбор = new choice();
            выбор.Show();
            this.Close();
            выбор.Background = this.Background;
            avtoriz авторизация = new avtoriz();
        }

        private void add(object sender, RoutedEventArgs e)
        {
            add_driver добавление = new add_driver();
            добавление.Show();
            this.Close();
            добавление.Background = this.Background;
        }

        private void watch(object sender, RoutedEventArgs e)
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
