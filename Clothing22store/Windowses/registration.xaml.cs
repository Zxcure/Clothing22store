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
using Clothing22store.Db;
using Clothing22store.EF;

namespace Clothing22store.Windowses
{
    /// <summary>
    /// Логика взаимодействия для registration.xaml
    /// </summary>
    public partial class registration : Window
    {
        public registration()
        {
            InitializeComponent();
            CmbGender.ItemsSource = EF.EfClass.Context.Gender.ToList();
            CmbGender.SelectedIndex = 0;
            CmbGender.DisplayMemberPath = "GenderName";
        }

        private void BtnAdduser_Click(object sender, RoutedEventArgs e)
        {
           
            if (string.IsNullOrWhiteSpace(TbLogin.Text))
            {
                MessageBox.Show("Логин не может быть пустым или состоять из пробелов");
                return;
            }

           
            EF.EfClass.Context.User.Add(new User()
            {
                Login = TbLogin.Text,
                Password = PbPassword.Password,
                LastName = TblName.Text,
                FirstName = TbFName.Text,
                Patronymic = TbPatronumic.Text,
                Email = TbEmail.Text,
                PhoneNumber = TbPhone.Text,
                Birthday = DpDateOfBirth.SelectedDate.Value,
                IDGender = (CmbGender.SelectedItem as Gender).IDGender,

            });

           
            EF.EfClass.Context.SaveChanges();



            MessageBox.Show("Ok");




        }
    }
}
