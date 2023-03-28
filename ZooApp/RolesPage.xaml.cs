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
using System.Xml.Linq;
using ZooApp.ZooDBDataSetTableAdapters;

namespace ZooApp
{
    /// <summary>
    /// Логика взаимодействия для RolesPage.xaml
    /// </summary>
    public partial class RolesPage : Page
    {
        RoleTableAdapter Roles = new RoleTableAdapter();

        public RolesPage()
        {
            InitializeComponent();
            RolesDataGrid.ItemsSource = Roles.GetData();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            if (name == "")
            {
                return;
            }

            Roles.InsertQuery(name);
            RolesDataGrid.ItemsSource = Roles.GetData();
        }

        private void RolesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView item = (RolesDataGrid.SelectedItem as DataRowView);
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
            if (RolesDataGrid.SelectedItem == null || name == "")
            {
                return;
            }
            int id = (int)(RolesDataGrid.SelectedItem as DataRowView).Row[0];
            Roles.UpdateQuery(name, id);
            RolesDataGrid.ItemsSource = Roles.GetData();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (RolesDataGrid.SelectedItem == null)
            {
                return;
            }
            int id = (int)(RolesDataGrid.SelectedItem as DataRowView).Row[0];
            Roles.DeleteQuery(id);
            RolesDataGrid.ItemsSource = Roles.GetData();
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<RoleModel> roles = Converter.Load<List<RoleModel>>();
                foreach (var role in roles)
                {
                    Roles.InsertQuery(role.name);
                }

                RolesDataGrid.ItemsSource = Roles.GetData();
            }
            catch
            {
                MessageBox.Show("Ошибка при загрузке JSON");
            }
        }
    }
}
