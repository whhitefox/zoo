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
    /// Логика взаимодействия для AnimalsPage.xaml
    /// </summary>
    public partial class AnimalsPage : Page
    {
        AnimalTableAdapter Animals = new AnimalTableAdapter();
        ZoneTableAdapter Zones = new ZoneTableAdapter();

        List<ComboItem> zoneItems;

        public AnimalsPage()
        {
            InitializeComponent();
            AnimalsDataGrid.ItemsSource = Animals.GetData();
            zoneItems = new List<ComboItem>();
            foreach (var item in Zones.GetData())
            {
                ComboItem comboItem = new ComboItem(item.id, item.name);
                zoneItems.Add(comboItem);
            }
            ZoneCombo.ItemsSource = zoneItems;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (NameTextBox.Text == "" || TypeTextBox.Text == "" || ZoneCombo.SelectedItem == null)
            {
                return;
            }

            string name = NameTextBox.Text;
            string type = TypeTextBox.Text;
            ComboItem zone = ZoneCombo.SelectedItem as ComboItem;
            Animals.InsertQuery(name, type, zone.id);
            AnimalsDataGrid.ItemsSource = Animals.GetData();
        }

        private void AnimalsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView item = (AnimalsDataGrid.SelectedItem as DataRowView);
            if (item != null)
            {
                string name = item.Row[1].ToString();
                string type = item.Row[2].ToString();
                int zone_id = (int)item.Row[3];
                ComboItem zone = zoneItems.Find(elem => elem.id == zone_id);
                
                NameTextBox.Text = name;
                TypeTextBox.Text = type;
                ZoneCombo.SelectedItem = zone;
                UpdateButton.IsEnabled = true;
                DeleteButton.IsEnabled = true;
            }
            else
            {
                NameTextBox.Text = "";
                TypeTextBox.Text = "";
                ZoneCombo.SelectedItem = null;
                UpdateButton.IsEnabled = false;
                DeleteButton.IsEnabled = false;
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            string type = TypeTextBox.Text;
            ComboItem zone = ZoneCombo.SelectedItem as ComboItem;
            if (AnimalsDataGrid.SelectedItem == null || name == "" || type == "" || zone == null)
            {
                return;
            }
            int id = (int)(AnimalsDataGrid.SelectedItem as DataRowView).Row[0];
            Animals.UpdateQuery(name, type, zone.id, id);
            AnimalsDataGrid.ItemsSource = Animals.GetData();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (AnimalsDataGrid.SelectedItem == null)
            {
                return;
            }
            int id = (int)(AnimalsDataGrid.SelectedItem as DataRowView).Row[0];
            Animals.DeleteQuery(id);
            AnimalsDataGrid.ItemsSource = Animals.GetData();
        }
    }
}
