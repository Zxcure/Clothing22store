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
    /// Логика взаимодействия для AddEmployeeWindow.xaml
    /// </summary>
    public partial class AddEmployeeWindow : Window
    {
        public AddEmployeeWindow()
        {
            InitializeComponent();
            CBPost.ItemsSource = EF.EfClass.Context.Position.ToList();
            CBPost.SelectedIndex = 0;
            CBPost.DisplayMemberPath = "Title";
            CBGender.ItemsSource = EF.EfClass.Context.Gender.ToList();
            CBGender.SelectedItem = 0;
            CBGender.DisplayMemberPath = "Title";
        }

        private void Vhod_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextFirstName.Text))
            {
                MessageBox.Show("Имя не может быть пустым");
                return;
            }
            else if (string.IsNullOrWhiteSpace(TextLastName.Text))
            {
                MessageBox.Show("Фамилия не может быть пустой");
                return;
            }
            else if (string.IsNullOrWhiteSpace(TbBirthday.Text))
            {
                MessageBox.Show("Дата не может быть пустой"); return;
            }
            else if (string.IsNullOrWhiteSpace(TextPhone.Text))
            {
                MessageBox.Show("Телефон не может быть пустой"); return;
            }
            else if (string.IsNullOrWhiteSpace(TextLogin.Text))
            {
                MessageBox.Show("Логин не может быть пустой"); return;
            }
            else if (string.IsNullOrWhiteSpace(PBPasswoed.Password))
            {
                MessageBox.Show("Пароль не может быть пустой"); return;
            }
            else
            {
                MessageBox.Show("Работник добавлен"); ;
            }

            Db.User account = new Db.User();
            account.FirstName = TextFirstName.Text;
            account.LastName = TextLastName.Text;
            account.Birthday = TextBirthday.SelectedDate.Value;
            account.PhoneNumber = TextPhone.Text;
            account.Login = TextLogin.Text;
            account.Password = PBPasswoed.Password;
            EF.EfClass.Context.User.Add(account);
            EF.EfClass.Context.SaveChanges();
            Db.Employee employee = new Employee
            
                IDPosition = (CBPost.SelectedItem as Position).Id,
                IDUser = EF.EfClass.Context.User.ToList().Where(i => i.Login == TextLogin.Text).FirstOrDefault().Id,
                IDGender = (CBGender.SelectedItem as Gender).Id
            
            context.Employee.Add(employee);
            context.SaveChanges();
            Employee employeeWindow = new Employee();
            employeeWindow.Show();
            this.Close();



        }
    }
}
