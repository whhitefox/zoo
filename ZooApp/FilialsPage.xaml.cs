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
    /// Логика взаимодействия для FilialsPage.xaml
    /// </summary>
    public partial class FilialsPage : Page
    {
        FilialTableAdapter Filials = new FilialTableAdapter();

        public FilialsPage()
        {
            InitializeComponent();
            FilialsDataGrid.ItemsSource = Filials.GetData();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string address = AddressTextBox.Text;
            string worktime = WorkTimeTextBox.Text;
            if (address == "" || worktime == "")
            {
                return;
            }

            Filials.InsertQuery(address, worktime);
            FilialsDataGrid.ItemsSource = Filials.GetData();
        }

        private void FilialsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView item = (FilialsDataGrid.SelectedItem as DataRowView);
            if (item != null)
            {
                string address = item.Row[1].ToString();
                string worktime = item.Row[2].ToString();
                AddressTextBox.Text = address;
                WorkTimeTextBox.Text = worktime;
                UpdateButton.IsEnabled = true;
                DeleteButton.IsEnabled = true;
            }
            else
            {
                AddressTextBox.Text = "";
                WorkTimeTextBox.Text = "";
                UpdateButton.IsEnabled = false;
                DeleteButton.IsEnabled = false;
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            string address = AddressTextBox.Text;
            string worktime = WorkTimeTextBox.Text;
            if (FilialsDataGrid.SelectedItem == null || address == "" || worktime == "")
            {
                return;
            }

            int id = (int)(FilialsDataGrid.SelectedItem as DataRowView).Row[0];
            Filials.UpdateQuery(address, worktime, id);
            FilialsDataGrid.ItemsSource = Filials.GetData();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (FilialsDataGrid.SelectedItem == null)
            {
                return;
            }
            int id = (int)(FilialsDataGrid.SelectedItem as DataRowView).Row[0];
            Filials.DeleteQuery(id);
            FilialsDataGrid.ItemsSource = Filials.GetData();
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<FilialModel> filials = Converter.Load<List<FilialModel>>();
                foreach (var filial in filials)
                {
                    Filials.InsertQuery(filial.address, filial.worktime);
                }

                FilialsDataGrid.ItemsSource = Filials.GetData();
            }
            catch
            {
                MessageBox.Show("Ошибка при загрузке JSON");
            }
        }
    }
}
