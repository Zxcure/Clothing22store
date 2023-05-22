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

<<<<<<< HEAD
            EmpGrid.ItemsSource = EF.UserDataClas.Context.Employee.ToList();
=======
            EmpGrid.ItemsSource = EF.EfClass.Context.Employee.ToList();
>>>>>>> 234fc076c65f6578c74be4996ab3ac1cf0986d8f
        }

        private void btnAddProd_Click(object sender, RoutedEventArgs e)
        {
            AddEmployeeWindow addEmployeeWindow = new AddEmployeeWindow();
            addEmployeeWindow.Show();
            this.Close();
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
            EF.UserDataClas.Context.SaveChanges();
=======
            EF.EfClass.Context.SaveChanges();
>>>>>>> 234fc076c65f6578c74be4996ab3ac1cf0986d8f
            MessageBox.Show("Изменено");
        }
    }
}
