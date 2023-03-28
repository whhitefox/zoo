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
    /// Логика взаимодействия для ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        ProductTableAdapter Products = new ProductTableAdapter();
        Product_TypeTableAdapter ProductTypes = new Product_TypeTableAdapter();
        FilialTableAdapter Filials = new FilialTableAdapter();

        List<ComboItem> productTypeItems;
        List<ComboItem> filialItems;

        public ProductsPage()
        {
            InitializeComponent();
            ProductsDataGrid.ItemsSource = Products.GetData();

            productTypeItems = new List<ComboItem>();
            foreach (var item in ProductTypes.GetData())
            {
                ComboItem comboItem = new ComboItem(item.id, item.name);
                productTypeItems.Add(comboItem);
            }

            filialItems = new List<ComboItem>();
            foreach (var item in Filials.GetData())
            {
                ComboItem comboItem = new ComboItem(item.id, item.address);
                filialItems.Add(comboItem);
            }

            ProductTypeCombo.ItemsSource = productTypeItems;
            FilialCombo.ItemsSource = filialItems;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            ComboItem productType = ProductTypeCombo.SelectedItem as ComboItem;
            ComboItem filial = FilialCombo.SelectedItem as ComboItem;
            string priceStr = PriceTextBox.Text;

            if (name == "" || priceStr == "" || productType == null || filial == null)
            {
                return;
            }

            double price;
            try
            {
                price = Convert.ToSingle(priceStr);
            }
            catch
            {
                MessageBox.Show("Цена должна быть числом");
                return;
            }
            if (price <= 0)
            {
                MessageBox.Show("Цена должна быть больше 0");
                return;
            }

            Products.InsertQuery(name, productType.id, filial.id, price);
            ProductsDataGrid.ItemsSource = Products.GetData();
        }

        private void ProductsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView item = (ProductsDataGrid.SelectedItem as DataRowView);
            if (item != null)
            {
                string name = item.Row[1].ToString();
                int product_type_id = (int)item.Row[2];
                int filial_id = (int)item.Row[3];
                double price = (double)item.Row[4];
                ComboItem product_type = productTypeItems.Find(elem => elem.id == product_type_id);
                ComboItem filial = filialItems.Find(elem => elem.id == filial_id);

                NameTextBox.Text = name;
                ProductTypeCombo.SelectedItem = product_type;
                FilialCombo.SelectedItem = filial;
                PriceTextBox.Text = price.ToString();
                UpdateButton.IsEnabled = true;
                DeleteButton.IsEnabled = true;
            }
            else
            {
                NameTextBox.Text = "";
                ProductTypeCombo.SelectedItem = null;
                FilialCombo.SelectedItem = null;
                PriceTextBox.Text = "";
                UpdateButton.IsEnabled = false;
                DeleteButton.IsEnabled = false;
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            ComboItem productType = ProductTypeCombo.SelectedItem as ComboItem;
            ComboItem filial = FilialCombo.SelectedItem as ComboItem;
            string priceStr = PriceTextBox.Text;
            if (ProductsDataGrid.SelectedItem == null || name == "" || priceStr == "" || productType == null || filial == null)
            {
                return;
            }

            double price;
            try
            {
                price = Convert.ToSingle(priceStr);
            }
            catch
            {
                MessageBox.Show("Цена должна быть числом");
                return;
            }
            if (price <= 0)
            {
                MessageBox.Show("Цена должна быть ,больше 0");
                return;
            }

            int id = (int)(ProductsDataGrid.SelectedItem as DataRowView).Row[0];
            Products.UpdateQuery(name, productType.id, filial.id, price, id);
            ProductsDataGrid.ItemsSource = Products.GetData();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsDataGrid.SelectedItem == null)
            {
                return;
            }
            int id = (int)(ProductsDataGrid.SelectedItem as DataRowView).Row[0];
            Products.DeleteQuery(id);
            ProductsDataGrid.ItemsSource = Products.GetData();
        }
    }
}
