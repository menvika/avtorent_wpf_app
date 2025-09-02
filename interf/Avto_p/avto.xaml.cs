using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using System.Xml;

namespace interf.Avto_p
{
    /// <summary>
    /// Логика взаимодействия для авто.xaml
    /// </summary>
    public partial class avto : Window
    {
        public avto()
        {
            InitializeComponent();

        }

        private void cancel(object sender, RoutedEventArgs e)
        {
            choice выбор = new choice();
            выбор.Show();
            this.Close();
            выбор.Background=this.Background;
        }

        private void add(object sender, RoutedEventArgs e)
        {
            add_avto добавление = new add_avto();
            добавление.Show();
            this.Close();
            добавление.Background = this.Background;
        }

        private void watch(object sender, RoutedEventArgs e)
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

        private void delete(object sender, RoutedEventArgs e)
        {
            delete_avto удалить = new delete_avto();
            удалить.Show();
            this.Close();
            удалить.Background = this.Background;
        }
    }
}
