using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace ZooApp
{
    /// <summary>
    /// Логика взаимодействия для WorkerWindow.xaml
    /// </summary>
    public partial class WorkerWindow : Window
    {
        public WorkerWindow()
        {
            InitializeComponent();
        }

        private void ZonesButton_Click(object sender, RoutedEventArgs e)
        {
            ZonesButton.IsEnabled = false;
            AnimalsButton.IsEnabled = true;
            ProductTypesButton.IsEnabled = true;
            ProductsButton.IsEnabled = true;
            PageFrame.Source = new Uri("ZonesPage.xaml", UriKind.Relative);
        }

        private void AnimalsButton_Click(object sender, RoutedEventArgs e)
        {
            ZonesButton.IsEnabled = true;
            AnimalsButton.IsEnabled = false;
            ProductTypesButton.IsEnabled = true;
            ProductsButton.IsEnabled = true;
            PageFrame.Source = new Uri("AnimalsPage.xaml", UriKind.Relative);
        }

        private void ProductTypesButton_Click(object sender, RoutedEventArgs e)
        {
            ZonesButton.IsEnabled = true;
            AnimalsButton.IsEnabled = true;
            ProductTypesButton.IsEnabled = false;
            ProductsButton.IsEnabled = true;
            PageFrame.Source = new Uri("ProductTypesPage.xaml", UriKind.Relative);
        }

        private void ProductsButton_Click(object sender, RoutedEventArgs e)
        {
            ZonesButton.IsEnabled = true;
            AnimalsButton.IsEnabled = true;
            ProductTypesButton.IsEnabled = true;
            ProductsButton.IsEnabled = false;
            PageFrame.Source = new Uri("ProductsPage.xaml", UriKind.Relative);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            Close();
        }
    }
}
