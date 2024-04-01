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
using System.Windows.Navigation;
using System.Windows.Shapes;
using praktika.UNLV_IncDataSetTableAdapters;

namespace praktika
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Vlevo_Click(object sender, RoutedEventArgs e)
        {
            Stranici.Content = new Pervaya_Tablica();
        }

        private void Vpravo_Click(object sender, RoutedEventArgs e)
        {
            Stranici.Content = new Vtoraya_tablica();
        }

        private void Center_Click(object sender, RoutedEventArgs e)
        {
            Stranici.Content = new Nulevaya_Stranica();
        }

        private void Center2_Click(object sender, RoutedEventArgs e)
        {
            Stranici.Content = new Tretya_Stranica();
        }
    }
}

