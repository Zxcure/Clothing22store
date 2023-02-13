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
using static Clothing22store.EF.EfClass;


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
           
            
            var userAuth = EF.EfClass.Context.User.ToList().Where(i => i.Login == LoginBox1.Text && i.Password == PassBx1.Text)
                .FirstOrDefault();
            if (userAuth != null)
            {
                //go
                MessageBox.Show("ОК");
            }
            else
            {
                MessageBox.Show("пользователь не найден", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
