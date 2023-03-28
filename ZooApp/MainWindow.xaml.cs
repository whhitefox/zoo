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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UserTableAdapter Users = new UserTableAdapter();
        EmployeeTableAdapter Employees = new EmployeeTableAdapter();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordBox.Password;
            if (login == "" || password == "")
            {
                return;
            }

            DataRow user = FindUser(login, password);
            if (user == null)
            {
                MessageBox.Show("Пользователя с такими данными не существует.");
                return;
            }

            DataRow employee = FindEmployee(user);
            if (employee == null)
            {
                MessageBox.Show("Сотрудник не найден.");
                return;
            }

            switch ((int)employee[4])
            {
                case 1:
                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.Show();
                    Close();
                    break;
                case 2:
                    KassaWindow kassaWindow = new KassaWindow();
                    kassaWindow.Show();
                    Close();
                    break;
                case 3:
                    WorkerWindow workerWindow = new WorkerWindow();
                    workerWindow.Show();
                    Close();
                    break;
                default:
                    MessageBox.Show("Действия для Вашей роли не назначены");
                    break;
            }
        }

        private DataRow FindUser(string login, string password)
        {
            var allUsers = Users.GetData().Rows;
            for (int i = 0; i < allUsers.Count; i++)
            {
                if (allUsers[i][1].ToString() == login && allUsers[i][2].ToString() == password)
                {
                    return allUsers[i];
                }
            }
            return null;
        }

        private DataRow FindEmployee(DataRow user)
        {
            var allEmployees = Employees.GetData().Rows;
            for (int i = 0; i < allEmployees.Count; i++)
            {
                if ((int)allEmployees[i][0] == (int)user[3])
                {
                    return allEmployees[i];
                }
            }
            return null;
        }
    }
}
