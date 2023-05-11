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

namespace Clothing22store.Windowses
{
    /// <summary>
    /// Логика взаимодействия для Employee.xaml
    /// </summary>
    public partial class Employee : Window
    {
        public Employee()
        {
            InitializeComponent();
            if (EF.EmployeeDataContextClass.employee.IDPosition != 1)
            {
                btnAddProd.Visibility = Visibility.Hidden;
            }

            EmpGrid.ItemsSource = EF.UserDataClas.Context.Employee.ToList();
        }

        private void btnAddProd_Click(object sender, RoutedEventArgs e)
        {
            AddEmployeeWindow addEmployeeWindow = new AddEmployeeWindow();
            addEmployeeWindow.Show();
            this.Close();
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            EF.UserDataClas.Context.SaveChanges();
            MessageBox.Show("Изменено");
        }
    }
}
