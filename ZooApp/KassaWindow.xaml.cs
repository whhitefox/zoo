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
    /// Логика взаимодействия для KassaWindow.xaml
    /// </summary>
    public partial class KassaWindow : Window
    {
        public KassaWindow()
        {
            InitializeComponent();
        }

        private void PurchaseButton_Click(object sender, RoutedEventArgs e)
        {
            PurchaseButton.IsEnabled = false;
            ChecksButton.IsEnabled = true;
            PageFrame.Source = new Uri("PurchasePage.xaml", UriKind.Relative);
        }

        private void ChecksButton_Click(object sender, RoutedEventArgs e)
        {
            PurchaseButton.IsEnabled = true;
            ChecksButton.IsEnabled = false;
            PageFrame.Source = new Uri("ChecksPage.xaml", UriKind.Relative);
        }
    }
}
