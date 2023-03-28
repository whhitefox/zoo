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
    /// Логика взаимодействия для UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        UserTableAdapter Users = new UserTableAdapter();
        EmployeeTableAdapter Employees = new EmployeeTableAdapter();

        List<ComboItem> employeeItems;

        public UsersPage()
        {
            InitializeComponent();
            UsersDataGrid.ItemsSource = Users.GetData();

            employeeItems = new List<ComboItem>();
            foreach (var item in Employees.GetData())
            {
                ComboItem comboItem = new ComboItem(item.id, item.name);
                employeeItems.Add(comboItem);
            }
            EmployeeCombo.ItemsSource = employeeItems;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordBox.Password;
            ComboItem employee = EmployeeCombo.SelectedItem as ComboItem;
            if (login == "" || password == "" || employee == null)
            {
                return;
            }

            Users.InsertQuery(login, password, employee.id);
            UsersDataGrid.ItemsSource = Users.GetData();
        }

        private void UsersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView item = (UsersDataGrid.SelectedItem as DataRowView);
            if (item != null)
            {
                string login = item.Row[1].ToString();
                string password = item.Row[2].ToString();
                int employee_id = (int)item.Row[3];
                ComboItem employee = employeeItems.Find(elem => elem.id == employee_id);

                LoginTextBox.Text = login;
                PasswordBox.Password = password;
                EmployeeCombo.SelectedItem = employee;
                UpdateButton.IsEnabled = true;
                DeleteButton.IsEnabled = true;
            }
            else
            {
                LoginTextBox.Text = "";
                PasswordBox.Password = "";
                EmployeeCombo.SelectedItem = null;
                UpdateButton.IsEnabled = false;
                DeleteButton.IsEnabled = false;
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordBox.Password;
            ComboItem employee = EmployeeCombo.SelectedItem as ComboItem;
            if (UsersDataGrid.SelectedItem == null || login == "" || password == "" || employee == null)
            {
                return;
            }
            int id = (int)(UsersDataGrid.SelectedItem as DataRowView).Row[0];
            Users.UpdateQuery(login, password, employee.id, id);
            UsersDataGrid.ItemsSource = Users.GetData();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsersDataGrid.SelectedItem == null)
            {
                return;
            }
            int id = (int)(UsersDataGrid.SelectedItem as DataRowView).Row[0];
            Users.DeleteQuery(id);
            UsersDataGrid.ItemsSource = Users.GetData();
        }
    }
}
