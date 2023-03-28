using Microsoft.WindowsAPICodePack.Dialogs;
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
    /// Логика взаимодействия для PurchasePage.xaml
    /// </summary>
    public partial class PurchasePage : Page
    {
        ProductTableAdapter Products = new ProductTableAdapter();
        CheckTableAdapter Checks = new CheckTableAdapter();
        Product_CheckTableAdapter ProductsCheck = new Product_CheckTableAdapter();

        List<ProductItem> SelectedProducts = new List<ProductItem>();

        public PurchasePage()
        {
            InitializeComponent();
            ProductsDataGrid.ItemsSource = Products.GetData();
            SelectedDataGrid.ItemsSource = SelectedProducts;
        }

        private void AddToSelected(int id, string name, double price)
        {
            ProductItem item = SelectedProducts.Find(elem => elem.id == id);
            if (item != null)
            {
                item.count += 1;
            }
            else
            {
                item = new ProductItem(id, name, price, 1);
                SelectedProducts.Add(item);
            }

            SelectedDataGrid.ItemsSource = null;
            SelectedDataGrid.ItemsSource = SelectedProducts;
        }

        private void RemoveFromSelected(int index)
        {
            ProductItem item = SelectedProducts[index];
            item.count -= 1;
            if (item.count <= 0)
            {
                SelectedProducts.Remove(item);
            }
            SelectedDataGrid.ItemsSource = null;
            SelectedDataGrid.ItemsSource = SelectedProducts;
        }

        private void UpdatePrice()
        {
            double price = 0;
            foreach (var item in SelectedProducts)
            {
                price += item.price * item.count;
            }

            PriceLabel.Content = $"Итоговая сумма: {price}";
        }

        private void Reset()
        {
            SelectedProducts = new List<ProductItem>();
            SelectedDataGrid.ItemsSource = null;
            SelectedDataGrid.ItemsSource = SelectedProducts;
            PayTextBox.Text = "";
            UpdatePrice();
        }

        private string SelectDir()
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog { IsFolderPicker = true};
            var result = dialog.ShowDialog();

            if (result == CommonFileDialogResult.Ok)
            {
                return dialog.FileName;
            }
            return null;
        }

        private void ProductsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProductsDataGrid.SelectedItem != null)
            {
                AddButton.IsEnabled = true;
            }
            else
            {
                AddButton.IsEnabled = false;
            }
        }

        private void SelectedDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SelectedDataGrid.SelectedItem != null)
            {
                RemoveButton.IsEnabled = true;
            }
            else
            {
                RemoveButton.IsEnabled = false;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            DataRowView item = (ProductsDataGrid.SelectedItem as DataRowView);
            if (item == null)
            {
                return;
            }

            int id = (int)item.Row[0];
            string name = item.Row[1].ToString();
            double price = (double)item.Row[4];

            AddToSelected(id, name, price);
            UpdatePrice();
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            int index = SelectedDataGrid.SelectedIndex;
            if (index == -1)
            {
                return;
            }
            RemoveFromSelected(index);
            UpdatePrice();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string payStr = PayTextBox.Text;
            if (SelectedProducts.Count == 0 || payStr == "")
            {
                return;
            }

            double pay;
            try
            {
                pay = Convert.ToDouble(payStr);
            }
            catch
            {
                MessageBox.Show("Оплата должна быть числом");
                return;
            }

            double price = 0;
            foreach (var item in SelectedProducts)
            {
                price += item.price * item.count;
            }

            if (pay < price)
            {
                MessageBox.Show("Клиент не может заплатить меньше итоговой суммы");
                return;
            }

            string dir = SelectDir();
            if (dir == null)
            {
                return;
            }

            DateTime date = DateTime.Now;
            Checks.InsertQuery(date, pay);
            int check_id = Checks.GetData().ToList().Max(elem => elem.id);
            foreach (var item in SelectedProducts)
            {
                ProductsCheck.InsertQuery(item.id, check_id, item.count);
            }

            Check check = new Check(check_id, date, pay, SelectedProducts);
            check.SaveToFile(dir);
            Reset();
        }
    }
}
