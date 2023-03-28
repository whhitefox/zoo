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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZooApp.ZooDBDataSetTableAdapters;

namespace ZooApp
{
    /// <summary>
    /// Логика взаимодействия для ChecksPage.xaml
    /// </summary>
    public partial class ChecksPage : Page
    {
        ProductTableAdapter Products = new ProductTableAdapter();
        CheckTableAdapter Checks = new CheckTableAdapter();
        Product_CheckTableAdapter ProductsCheck = new Product_CheckTableAdapter();

        List<ComboItem> checkItems;
        Check currentCheck;

        public ChecksPage()
        {
            InitializeComponent();
            checkItems = new List<ComboItem>();
            foreach (var item in Checks.GetData())
            {
                ComboItem comboItem = new ComboItem(item.id, item.date.ToString());
                checkItems.Add(comboItem);
            }
            CheckCombo.ItemsSource = checkItems;
        }

        private DataRow FindCheck(int id)
        {
            var allChecks = Checks.GetData().Rows;

            for (int i = 0; i < allChecks.Count; i++)
            {
                if ((int)allChecks[i][0] == id)
                {
                    return allChecks[i];
                }
            }
            return null;
        }

        private List<ProductItem> GetProducts(int check_id)
        {
            List<int[]> products = new List<int[]>();
            foreach (var item in ProductsCheck.GetData())
            {
                if (item.check_id == check_id)
                {
                    int[] product = { item.product_id, item.count };
                    products.Add(product);
                }
            }

            List<ProductItem> productItems = new List<ProductItem>();
            foreach (var product in Products.GetData())
            {
                int[] founded = products.Find(item => item[0] == product.id);

                if (founded != null)
                {
                    ProductItem item = new ProductItem(product.id, product.name, product.price, founded[1]);
                    productItems.Add(item);
                }
            }

            return productItems;
        }

        private string SelectDir()
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog { IsFolderPicker = true };
            var result = dialog.ShowDialog();

            if (result == CommonFileDialogResult.Ok)
            {
                return dialog.FileName;
            }
            return null;
        }

        private void CheckCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboItem item = CheckCombo.SelectedItem as ComboItem;
            if (item == null)
            {
                DateLabel.Content = "Дата: ";
                PayLabel.Content = "Оплата: ";
                SaveButton.IsEnabled = false;
                ProductsDataGrid.ItemsSource = null;
                currentCheck = null;
                return;
            }

            DataRow check = FindCheck(item.id);
            if (check == null)
            {
                return;
            }
            List<ProductItem> products = GetProducts(item.id);
            DateTime date = (DateTime)check[1];
            double pay = (double)check[2];
           
            ProductsDataGrid.ItemsSource = products;
            DateLabel.Content = $"Дата: {date}";
            PayLabel.Content = $"Оплата: {pay}";
            currentCheck = new Check(item.id, date, pay, products);
            SaveButton.IsEnabled = true;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentCheck == null)
            {
                return;
            }

            string dir = SelectDir();
            if (dir == null)
            {
                return;
            }

            currentCheck.SaveToFile(dir);
        }
    }
}
