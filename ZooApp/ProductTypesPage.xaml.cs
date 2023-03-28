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
    /// Логика взаимодействия для ProductTypesPage.xaml
    /// </summary>
    public partial class ProductTypesPage : Page
    {
        Product_TypeTableAdapter ProductTypes = new Product_TypeTableAdapter();

        public ProductTypesPage()
        {
            InitializeComponent();
            ProductTypesDataGrid.ItemsSource = ProductTypes.GetData();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            if (name == "")
            {
                return;
            }

            ProductTypes.InsertQuery(name);
            ProductTypesDataGrid.ItemsSource = ProductTypes.GetData();
        }

        private void ProductTypesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView item = (ProductTypesDataGrid.SelectedItem as DataRowView);
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
            if (ProductTypesDataGrid.SelectedItem == null || name == "")
            {
                return;
            }
            int id = (int)(ProductTypesDataGrid.SelectedItem as DataRowView).Row[0];
            ProductTypes.UpdateQuery(name, id);
            ProductTypesDataGrid.ItemsSource = ProductTypes.GetData();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProductTypesDataGrid.SelectedItem == null)
            {
                return;
            }
            int id = (int)(ProductTypesDataGrid.SelectedItem as DataRowView).Row[0];
            ProductTypes.DeleteQuery(id);
            ProductTypesDataGrid.ItemsSource = ProductTypes.GetData();
        }
    }
}
