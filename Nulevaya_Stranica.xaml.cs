
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
using praktika.UNLV_IncDataSetTableAdapters;


namespace praktika
{
    /// <summary>
    /// Логика взаимодействия для Nulevaya_Stranica.xaml
    /// </summary>
    public partial class Nulevaya_Stranica : Page
    {
        ClientsTableAdapter Clients = new ClientsTableAdapter();

        public Nulevaya_Stranica()
        {
            InitializeComponent();
            Clients_Tablica.ItemsSource = Clients.GetData();

        }

        private void Insert_nulevaya_Click(object sender, RoutedEventArgs e)
        {
            Clients.InsertQuery(FirstName_Insert.Text, SurName_Insert.Text, MiddleName_Insert.Text, Convert.ToInt32(PasportSeriya_Insert.Text), Convert.ToInt32(PasportNumber_Insert.Text));
            Clients_Tablica.ItemsSource = Clients.GetData();

        }

        private void Update_nulevaya_Click(object sender, RoutedEventArgs e)
        {
            object id = (Clients_Tablica.SelectedItem as DataRowView).Row[0];
            Clients.UpdateQuery(FirstName_Insert.Text, SurName_Insert.Text, MiddleName_Insert.Text, Convert.ToInt32(PasportSeriya_Insert.Text), Convert.ToInt32(PasportNumber_Insert.Text), Convert.ToInt32(id));
            Clients_Tablica.ItemsSource = Clients.GetData();
        }

        private void Delete_nulevaya_Click(object sender, RoutedEventArgs e)
        {
            object id = (Clients_Tablica.SelectedItem as DataRowView).Row[0];
            Clients.DeleteQuery(Convert.ToInt32(id));
            Clients_Tablica.ItemsSource = Clients.GetData();
        }

        private void Clients_Tablica_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Clients_Tablica.SelectedItem == null) return;
            var row = (DataRowView)Clients_Tablica.SelectedItem;

            FirstName_Insert.Text = row["FirstNameClient"].ToString();
            SurName_Insert.Text = row["SurNameClient"].ToString();
            MiddleName_Insert.Text = row["MiddleNameClient"].ToString();
            PasportSeriya_Insert.Text = row["PasportSeriya"].ToString();
            PasportNumber_Insert.Text = row["PasportNumber"].ToString();

        }
    }
}