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
    /// Логика взаимодействия для theme.xaml
    /// </summary>
    public partial class theme : Window
    {
        avtoriz avtoriz = new avtoriz(); //следующее окно (авторизация)
        

        public theme()
        {
            InitializeComponent();
        }

        private void RadioButton_white(object sender, RoutedEventArgs e) //изменение заднего фона на белый
        {
            Background = Brushes.White;
            //buttheme.Foreground = Brushes.White; 
            avtoriz.Background = Brushes.White;
        }

        private void RadioButton_black(object sender, RoutedEventArgs e) //изменение заднего фона на черный
        {
            Background = Brushes.Black;
            buttheme.Foreground = Brushes.Black;
            avtoriz.Background = Brushes.Black;
        }


        private void butUstanov(object sender, RoutedEventArgs e)
        {
            avtoriz.Show(); //переход на следующее окно (авторизация)
            this.Close();
        }
        private void exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
