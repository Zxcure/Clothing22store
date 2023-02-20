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
            //Валидация поля Логин
            if (TbLogin.Text == "Введите Логин")
            {
                MessageBox.Show("Поле Логин должно быть заполнено", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (string.IsNullOrWhiteSpace(TbLogin.Text))
            {
                MessageBox.Show("Поле Логин должно быть заполнено", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (TbLogin.Text.Length > 30)
            {
                MessageBox.Show("Доупустимое количество символов в поле логин 30", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            //Валидация поля Email

            else if (string.IsNullOrWhiteSpace(TbEmail.Text))
            {
                MessageBox.Show("Поле Email должно быть заполнено", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string[] dataLogin = TbEmail.Text.Split('@'); // делим строку на две части
            if (dataLogin.Length != 2) // проверяем если у нас две части
            {
                MessageBox.Show("Поле Email заполнено не по формату x@x.x", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            string[] data2Login = dataLogin[1].Split('.'); // делим вторую часть ещё на две части
            if (data2Login.Length != 2) // проверяем если у нас две части
            {
                MessageBox.Show("Поле Email заполнено не по формату x@x.x", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            //Валидация поля Фамилия

            else if (string.IsNullOrWhiteSpace(TblName.Text))
            {
                MessageBox.Show("Поле Фамилия должно быть заполнено", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            else if (TblName.Text.Length < 3 && TblName.Text.Length > 50)
            {
                MessageBox.Show("Неправильно заполнено поле Фамилия", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            bool symbol = false;
            bool number = false;

            for (int i = 0; i < TblName.Text.Length; i++) // перебираем символы
            {
                if (TblName.Text[i] >= '0' && TblName.Text[i] <= '9') number = true;
                if (TblName.Text[i] == '-' || TblName.Text[i] == '_' ||
                    TblName.Text[i] == '=' || TblName.Text[i] == '+' ||
                    TblName.Text[i] == ':' || TblName.Text[i] == ';' ||
                    TblName.Text[i] == '!' || TblName.Text[i] == '@' ||
                    TblName.Text[i] == '#' || TblName.Text[i] == '%' ||
                    TblName.Text[i] == '*') symbol = true;
            }

            if (number)
            {
                MessageBox.Show("В поле Фамилия не должны присутствовать цифры", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (symbol)
            {
                MessageBox.Show("В поле Фамилия не должны присутствовать символы", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            //Валидация поля Имя

            else if (string.IsNullOrWhiteSpace(TbFName.Text))
            {
                MessageBox.Show("Поле Имя должно быть заполнено", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (TbFName.Text.Length < 2 && TbFName.Text.Length > 50)
            {
                MessageBox.Show("Неправильно заполнено поле Фамилия", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            for (int i = 0; i < TbFName.Text.Length; i++) // перебираем символы
            {
                if (TbFName.Text[i] >= '0' && TbFName.Text[i] <= '9') number = true;
                if (TbFName.Text[i] == '-' || TbFName.Text[i] == '_' ||
                    TbFName.Text[i] == '=' || TbFName.Text[i] == '+' ||
                    TbFName.Text[i] == ':' || TbFName.Text[i] == ';' ||
                    TbFName.Text[i] == '!' || TbFName.Text[i] == '@' ||
                    TbFName.Text[i] == '#' || TbFName.Text[i] == '%' ||
                    TbFName.Text[i] == '*') symbol = true;
            }

            if (number)
            {
                MessageBox.Show("В поле Имя не должны присутствовать цифры", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (symbol)
            {
                MessageBox.Show("В поле Имя не должны присутствовать символы", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //Валидация поля Отчество
            else if (string.IsNullOrWhiteSpace(TbPatronumic.Text))
            {
                MessageBox.Show("Поле Отчество должно быть заполнено", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (TbPatronumic.Text.Length < 2 && TbPatronumic.Text.Length > 50)
            {
                MessageBox.Show("Неправильно заполнено поле Фамилия", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            for (int i = 0; i < TbPatronumic.Text.Length; i++) // перебираем символы
            {
                if (TbPatronumic.Text[i] >= '0' && TbPatronumic.Text[i] <= '9') number = true;
                if (TbPatronumic.Text[i] == '-' || TbPatronumic.Text[i] == '_' ||
                    TbPatronumic.Text[i] == '=' || TbPatronumic.Text[i] == '+' ||
                    TbPatronumic.Text[i] == ':' || TbPatronumic.Text[i] == ';' ||
                    TbPatronumic.Text[i] == '!' || TbPatronumic.Text[i] == '@' ||
                    TbPatronumic.Text[i] == '#' || TbPatronumic.Text[i] == '%' ||
                    TbPatronumic.Text[i] == '*') symbol = true;
            }

            if (number)
            {
                MessageBox.Show("В поле Отчество не должны присутствовать цифры", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (symbol)
            {
                MessageBox.Show("В поле Отчество  не должны присутствовать символы", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //Валидация поля Номер телефона
            else if (string.IsNullOrWhiteSpace(TbPhone.Text))
            {
                MessageBox.Show("Поле Логин должно быть заполнено", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //Валидация поля Пол
            else if (string.IsNullOrWhiteSpace(CmbGender.Text))
            {
                MessageBox.Show("Поле Пола должно быть заполнено", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //Валидация поля Дата Рождения
            else if (string.IsNullOrWhiteSpace(DpDateOfBirth.Text))
            {
                MessageBox.Show("Поле Даты Рождения должно быть заполнено", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //Валидация поля Пароль
            else if (string.IsNullOrWhiteSpace(PbPassword.Text))
            {
                MessageBox.Show("Поле Пароль должно быть заполнено", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            EF.EfClass.Context.User.Add(new User()
            {

                Login = TbLogin.Text,
                Password = PbPassword.Text,
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
