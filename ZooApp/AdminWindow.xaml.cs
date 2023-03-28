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
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void RolesButton_Click(object sender, RoutedEventArgs e)
        {
            FilialsButton.IsEnabled = true;
            SupportsButton.IsEnabled = true;
            RolesButton.IsEnabled = false;
            EmployeesButton.IsEnabled = true;
            UsersButton.IsEnabled = true;
            PageFrame.Source = new Uri("RolesPage.xaml", UriKind.Relative);
        }

        private void EmployeesButton_Click(object sender, RoutedEventArgs e)
        {
            FilialsButton.IsEnabled = true;
            SupportsButton.IsEnabled = true;
            RolesButton.IsEnabled = true;
            EmployeesButton.IsEnabled = false;
            UsersButton.IsEnabled = true;
            PageFrame.Source = new Uri("EmployeesPage.xaml", UriKind.Relative);
        }

        private void UsersButton_Click(object sender, RoutedEventArgs e)
        {
            FilialsButton.IsEnabled = true;
            SupportsButton.IsEnabled = true;
            RolesButton.IsEnabled = true;
            EmployeesButton.IsEnabled = true;
            UsersButton.IsEnabled = false;
            PageFrame.Source = new Uri("UsersPage.xaml", UriKind.Relative);
        }

        private void FilialsButton_Click(object sender, RoutedEventArgs e)
        {
            FilialsButton.IsEnabled = false;
            SupportsButton.IsEnabled = true;
            RolesButton.IsEnabled = true;
            EmployeesButton.IsEnabled = true;
            UsersButton.IsEnabled = true;
            PageFrame.Source = new Uri("FilialsPage.xaml", UriKind.Relative);
        }

        private void SupportsButton_Click(object sender, RoutedEventArgs e)
        {
            FilialsButton.IsEnabled = true;
            SupportsButton.IsEnabled = false;
            RolesButton.IsEnabled = true;
            EmployeesButton.IsEnabled = true;
            UsersButton.IsEnabled = true;
            PageFrame.Source = new Uri("SupportsPage.xaml", UriKind.Relative);
        }
    }
}
