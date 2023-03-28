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
using ZooApp.ZooDBDataSetTableAdapters;

namespace ZooApp
{
    /// <summary>
    /// Логика взаимодействия для ZonesPage.xaml
    /// </summary>
    public partial class ZonesPage : Page
    {
        ZoneTableAdapter Zones = new ZoneTableAdapter();
        public ZonesPage()
        {
            InitializeComponent();
            ZonesDataGrid.ItemsSource = Zones.GetData();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (NameTextBox.Text == "")
            {
                return;
            }

            string name = NameTextBox.Text;
            Zones.InsertQuery(name);
            ZonesDataGrid.ItemsSource = Zones.GetData();
        }

        private void ZonesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView item = (ZonesDataGrid.SelectedItem as DataRowView);
            if (item != null)
            {
                string name = item.Row[1].ToString();
                NameTextBox.Text = name;
                UpdateButton.IsEnabled = true;
                DeleteButton.IsEnabled = true;
            }
            else
            {
                NameTextBox.Text = "";
                UpdateButton.IsEnabled = false;
                DeleteButton.IsEnabled = false;
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            if (ZonesDataGrid.SelectedItem == null || name == "")
            {
                return;
            }
            int id = (int)(ZonesDataGrid.SelectedItem as DataRowView).Row[0];
            Zones.UpdateQuery(name, id);
            ZonesDataGrid.ItemsSource = Zones.GetData();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (ZonesDataGrid.SelectedItem == null)
            {
                return;
            }
            int id = (int)(ZonesDataGrid.SelectedItem as DataRowView).Row[0];
            Zones.DeleteQuery(id);
            ZonesDataGrid.ItemsSource = Zones.GetData();
        }
    }
}
