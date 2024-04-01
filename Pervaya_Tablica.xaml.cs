using praktika.UNLV_IncDataSetTableAdapters;
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

namespace praktika
{
    /// <summary>
    /// Логика взаимодействия для Pervaya_Tablica.xaml
    /// </summary>
    public partial class Pervaya_Tablica : Page
    {
        GoodsTableAdapter Goods = new GoodsTableAdapter();

        public Pervaya_Tablica()
        {
            InitializeComponent();
            Tablica_Goods.ItemsSource = Goods.GetData();

        }

        private void Insert_pervaya_Click(object sender, RoutedEventArgs e)
        {
            Goods.InsertQuery(NameGood_Insert.Text, Convert.ToInt32(GoodNumber_Insert.Text), Convert.ToDecimal(GoodCost_Insert.Text), Convert.ToInt32(GoodNalichie_Insert.Text));
            Tablica_Goods.ItemsSource = Goods.GetData();
        }

        private void Update_pervaya_Click(object sender, RoutedEventArgs e)
        {
            object id = (Tablica_Goods.SelectedItem as DataRowView).Row[0];
            Goods.UpdateQuery(NameGood_Insert.Text, Convert.ToInt32(GoodNumber_Insert.Text), Convert.ToDecimal(GoodCost_Insert.Text), Convert.ToInt32(GoodNalichie_Insert.Text), Convert.ToInt32(id));
            Tablica_Goods.ItemsSource = Goods.GetData();
        }

        private void Delete_pervaya_Click(object sender, RoutedEventArgs e)
        {
            object id = (Tablica_Goods.SelectedItem as DataRowView).Row[0];
            Goods.DeleteQuery(Convert.ToInt32(id));
        }

        private void Tablica_Goods_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Tablica_Goods.SelectedItem == null) return;
            var row = (DataRowView)Tablica_Goods.SelectedItem;

            NameGood_Insert.Text = row["NameGood"].ToString();
            GoodNumber_Insert.Text = row["GoodNumber"].ToString();
            GoodCost_Insert.Text = row["GoodCost"].ToString();
            GoodNalichie_Insert.Text = row["GoodNalichie"].ToString();
        }
    }
}
