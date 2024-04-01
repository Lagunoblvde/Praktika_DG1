using praktika.UNLV_IncDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
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

namespace praktika
{
    /// <summary>
    /// Логика взаимодействия для Vtoraya_tablica.xaml
    /// </summary>
    public partial class Vtoraya_tablica : Page
    {
        OrdersTableAdapter Orders = new OrdersTableAdapter();
    
        public Vtoraya_tablica()
        {
            InitializeComponent();
            Tablica_Orders.ItemsSource = Orders.GetData();

        }

        private void Insert_vtoraya_Click(object sender, RoutedEventArgs e)
        {
            Orders.InsertQuery(Convert.ToInt32(IDClient_Insert.Text), Convert.ToInt32(IDGood_Insert), Convert.ToInt32(Quantity_Insert.Text), Convert.ToDateTime(OrderDate_Insert));
            Tablica_Orders.ItemsSource = Orders.GetData();
        }

        private void Update_vtoraya_Click(object sender, RoutedEventArgs e)
        {
            object id = (Tablica_Orders.SelectedItem as DataRowView).Row[0];
            Orders.UpdateQuery(Convert.ToInt32(IDClient_Insert.Text), Convert.ToInt32(IDGood_Insert), Convert.ToInt32(Quantity_Insert.Text), Convert.ToDateTime(OrderDate_Insert), Convert.ToInt32(id));
            Tablica_Orders.ItemsSource = Orders.GetData();
        }

        private void Delete_vtoraya_Click(object sender, RoutedEventArgs e)
        {
            object id = (Tablica_Orders.SelectedItem as DataRowView).Row[0];
            Orders.DeleteQuery(Convert.ToInt32(id));
        }

        private void Tablica_Orders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Tablica_Orders.SelectedItem == null) return;
            var row = (DataRowView)Tablica_Orders.SelectedItem;

            IDClient_Insert.Text = row["ID_Client"].ToString();
            IDGood_Insert.Text = row["ID_Good"].ToString();
            Quantity_Insert.Text = row["Quantity"].ToString();
            OrderDate_Insert.Text = row["OrderDate"].ToString();
        }
    }
}
