using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using ZooApp.ZooDBDataSetTableAdapters;

namespace ZooApp
{
    /// <summary>
    /// Логика взаимодействия для SupportsPage.xaml
    /// </summary>
    public partial class SupportsPage : Page
    {
        SupportTableAdapter Supports = new SupportTableAdapter();
        FilialTableAdapter Filials = new FilialTableAdapter();

        List<ComboItem> filialItems;

        public SupportsPage()
        {
            InitializeComponent();
            SupportsDataGrid.ItemsSource = Supports.GetData();

            filialItems = new List<ComboItem>();
            foreach (var item in Filials.GetData())
            {
                ComboItem comboItem = new ComboItem(item.id, item.address);
                filialItems.Add(comboItem);
            }
            FilialCombo.ItemsSource = filialItems;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string phone = PhoneTextBox.Text;
            ComboItem filial = FilialCombo.SelectedItem as ComboItem;
            if (phone == "" || filial == null)
            {
                return;
            }
            if (!Validatetelefon(phone))
            {
                MessageBox.Show("неверный формат");
                return;
            }
            
            Supports.InsertQuery(filial.id, phone);
            SupportsDataGrid.ItemsSource = Supports.GetData();
        }

        private void SupportsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView item = (SupportsDataGrid.SelectedItem as DataRowView);
            if (item != null)
            {
                int filial_id = (int)item.Row[1];
                string phone = item.Row[2].ToString();
                ComboItem filial = filialItems.Find(elem => elem.id == filial_id);

                PhoneTextBox.Text = phone;
                FilialCombo.SelectedItem = filial;
                UpdateButton.IsEnabled = true;
                DeleteButton.IsEnabled = true;
            }
            else
            {
                PhoneTextBox.Text = "";
                FilialCombo.SelectedItem = null;
                UpdateButton.IsEnabled = false;
                DeleteButton.IsEnabled = false;
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            string phone = PhoneTextBox.Text;
            ComboItem filial = FilialCombo.SelectedItem as ComboItem;
            if (SupportsDataGrid.SelectedItem == null || phone == "" || filial == null)
            {
                return;
            }
            if (!Validatetelefon(phone))
            {
                MessageBox.Show("неверный формат");
                return;
            }
            int id = (int)(SupportsDataGrid.SelectedItem as DataRowView).Row[0];
            Supports.UpdateQuery(filial.id, phone, id);
            SupportsDataGrid.ItemsSource = Supports.GetData();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (SupportsDataGrid.SelectedItem == null)
            {
                return;
            } 
            int id = (int)(SupportsDataGrid.SelectedItem as DataRowView).Row[0];
            Supports.DeleteQuery(id);
            SupportsDataGrid.ItemsSource = Supports.GetData();
        }
        private bool Validatetelefon(string telefon)
        {
            Regex regex = new Regex(@"^\+7\(\d\d\d\)\d\d\d-\d\d-\d\d$");
            MatchCollection match = regex.Matches(telefon);
            if (match.Count > 0)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }
    }
}
