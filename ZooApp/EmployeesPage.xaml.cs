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
    /// Логика взаимодействия для EmployeesPage.xaml
    /// </summary>
    public partial class EmployeesPage : Page
    {
        EmployeeTableAdapter Employees = new EmployeeTableAdapter();
        AnimalTableAdapter Animals = new AnimalTableAdapter();
        FilialTableAdapter Filials = new FilialTableAdapter();
        RoleTableAdapter Roles = new RoleTableAdapter();

        List<ComboItem> animalItems;
        List<ComboItem> filialItems;
        List<ComboItem> roleItems;

        public EmployeesPage()
        {
            InitializeComponent();
            EmployeesDataGrid.ItemsSource = Employees.GetData();

            animalItems = new List<ComboItem>();
            foreach (var item in Animals.GetData())
            {
                ComboItem comboItem = new ComboItem(item.id, item.name);
                animalItems.Add(comboItem);
            }

            filialItems = new List<ComboItem>();
            foreach (var item in Filials.GetData())
            {
                ComboItem comboItem = new ComboItem(item.id, item.address);
                filialItems.Add(comboItem);
            }

            roleItems = new List<ComboItem>();
            foreach (var item in Roles.GetData())
            {
                ComboItem comboItem = new ComboItem(item.id, item.name);
                roleItems.Add(comboItem);
            }

            AnimalCombo.ItemsSource = animalItems;
            FilialCombo.ItemsSource = filialItems;
            RoleCombo.ItemsSource = roleItems;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            ComboItem animal = AnimalCombo.SelectedItem as ComboItem;
            ComboItem filial = FilialCombo.SelectedItem as ComboItem;
            ComboItem role = RoleCombo.SelectedItem as ComboItem;
            if (name == "" || animal == null || filial == null || role == null)
            {
                return;
            }

            Employees.InsertQuery(name, filial.id, animal.id, role.id);
            EmployeesDataGrid.ItemsSource = Employees.GetData();
        }

        private void EmployeesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView item = (EmployeesDataGrid.SelectedItem as DataRowView);
            if (item != null)
            {
                string name = item.Row[1].ToString();
                int filial_id = (int)item.Row[2];
                int animal_id = (int)item.Row[3];
                int role_id = (int)item.Row[4];
                ComboItem filial = filialItems.Find(elem => elem.id == filial_id);
                ComboItem animal = animalItems.Find(elem => elem.id == animal_id);
                ComboItem role = roleItems.Find(elem => elem.id == role_id);

                NameTextBox.Text = name;
                FilialCombo.SelectedItem = filial;
                AnimalCombo.SelectedItem = animal;
                RoleCombo.SelectedItem = role;
                UpdateButton.IsEnabled = true;
                DeleteButton.IsEnabled = true;
            }
            else
            {
                NameTextBox.Text = "";
                FilialCombo.SelectedItem = null;
                AnimalCombo.SelectedItem = null;
                RoleCombo.SelectedItem = null;
                UpdateButton.IsEnabled = false;
                DeleteButton.IsEnabled = false;
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            ComboItem animal = AnimalCombo.SelectedItem as ComboItem;
            ComboItem filial = FilialCombo.SelectedItem as ComboItem;
            ComboItem role = RoleCombo.SelectedItem as ComboItem;
            if (name == "" || animal == null || filial == null || role == null)
            {
                return;
            }

            int id = (int)(EmployeesDataGrid.SelectedItem as DataRowView).Row[0];
            Employees.UpdateQuery(name, filial.id, animal.id, role.id, id);
            EmployeesDataGrid.ItemsSource = Employees.GetData();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeesDataGrid.SelectedItem == null)
            {
                return;
            }
            int id = (int)(EmployeesDataGrid.SelectedItem as DataRowView).Row[0];
            Employees.DeleteQuery(id);
            EmployeesDataGrid.ItemsSource = Employees.GetData();
        }
    }
}
