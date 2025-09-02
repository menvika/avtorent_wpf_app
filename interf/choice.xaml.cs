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

namespace interf
{
    /// <summary>
    /// Логика взаимодействия для выбор.xaml
    /// </summary>
    public partial class choice : Window
    {
        public choice()
        {
            InitializeComponent();
        }

        private void cl_zakaz(object sender, RoutedEventArgs e)
        {
            Orders_p.orders заказы = new Orders_p.orders();
            заказы.Show();
            заказы.Background = this.Background;
            Close();
        }

        private void vodit(object sender, RoutedEventArgs e)
        {
            Driver_p.driver водители = new Driver_p.driver();
            водители.Show();
            водители.Background = this.Background;
            Close();
        }

        private void avto(object sender, RoutedEventArgs e)
        {
            Avto_p.avto авто = new Avto_p.avto();
            авто.Show();
            авто.Background = this.Background;
            Close();
            avtoriz avtoriz = new avtoriz();
        }
        private void cancel(object sender, RoutedEventArgs e)
        {
            avtoriz авторизация = new avtoriz();
            авторизация.Show();
            this.Close();
            авторизация.Background = this.Background;
        }
        private void exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
