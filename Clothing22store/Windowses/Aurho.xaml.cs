using Clothing22store.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
using static Clothing22store.EF.UserDataClas;


namespace Clothing22store.Windowses
{
    /// <summary>
    /// Логика взаимодействия для Aurho.xaml
    /// </summary>
    public partial class Aurho : Window
    {
        public Aurho()
        {
            InitializeComponent();
        }
        private void Signin_Click(object sender, RoutedEventArgs e)
        {
           
            
            var userAuth = EF.UserDataClas.Context.User.ToList().Where(i => i.Login == LoginBox1.Text && i.Password == PassBx1.Text)
                .FirstOrDefault();
            if (userAuth != null)
            {
                // сохранияем данные входа
                EF.ClassPas.User = userAuth;
                var emplAuth = EF.UserDataClas.Context.Employee.Where(i => i.IDUser == userAuth.IDUser).FirstOrDefault();
                if (emplAuth != null)
                {
                    // если не пустой то Работник

                    // сохранияем данные входа

                    EF.ClassPas.Employee = emplAuth;

                    // проверка роли 

                    switch (emplAuth.IDPosition)
                    {
                        case 1:
                            // переход на страницу директора
                            MainWindow mainWindow = new MainWindow();
                            mainWindow.Show();
                            this.Close();
                            break;

                        case 2:
                            // переход на страницу администратора
                            break;
                        case 3:
                            // переход на страницу продавца
                            break;
                        default:
                            break;
                    }

                }
                else
                {
                    // Client

                    // сохраняем клиента
                    //ClassHelper.UserDataClass.Client = userAuth;


                    ProductList productListWindow = new ProductList();
                    productListWindow.Show();
                    this.Close();

                }


            }
            else
            {
                MessageBox.Show("Пользователь не найден", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
