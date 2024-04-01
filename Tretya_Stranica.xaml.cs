using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using praktika.UNLV_IncDataSetTableAdapters;


namespace praktika
{
    /// <summary>
    /// Логика взаимодействия для Tretya_Stranica.xaml
    /// </summary>
    public partial class Tretya_Stranica : Page
    {
        GoodTegTableAdapter goodTeg = new GoodTegTableAdapter();
        public Tretya_Stranica()
        {
            InitializeComponent();
            Tablica_GoodTeg.ItemsSource = goodTeg.GetData();

        }

        private void Insert_tretya_Click(object sender, RoutedEventArgs e)
        {
            goodTeg.InsertQuery(GoodTeg_Insert.Text);
            Tablica_GoodTeg.ItemsSource = goodTeg.GetData();
        }

        private void Update_tretya_Click(object sender, RoutedEventArgs e)
        {
            object id = (Tablica_GoodTeg.SelectedItem as DataRowView).Row[0];
            goodTeg.UpdateQuery(GoodTeg_Insert.Text, Convert.ToInt32(id));
            Tablica_GoodTeg.ItemsSource = goodTeg.GetData();

        }

        private void Delete_tretya_Click(object sender, RoutedEventArgs e)
        {
            object id = (Tablica_GoodTeg.SelectedItem as DataRowView).Row[0];
            goodTeg.DeleteQuery(Convert.ToInt32(id));
            Tablica_GoodTeg.ItemsSource = goodTeg.GetData();

        }

        private void Tablica_GoodTeg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Tablica_GoodTeg.SelectedItem == null) return;
            var row = (DataRowView)Tablica_GoodTeg.SelectedItem;

            GoodTeg_Insert.Text = row["GoodTeg"].ToString();
        }
    }
}
