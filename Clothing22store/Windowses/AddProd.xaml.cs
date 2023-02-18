using Clothing22store.EF;
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

using Clothing22store.Windowses;
using Clothing22store.Db;
using System.IO;
using Microsoft.Win32;

namespace Clothing22store.Windowses
{
    /// <summary>
    /// Логика взаимодействия для AddProd.xaml
    /// </summary>
    public partial class AddProd : Window
    {
        private string pathImageProduct = null;
        public AddProd()
        {
            InitializeComponent();
            CmbCategory.ItemsSource = EF.EfClass.Context.Category.ToList();
            CmbCategory.DisplayMemberPath = "Name";
            CmbCategory.SelectedIndex = 0;
        }
        private void BtnChooseImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                ImgProduct.Source = new BitmapImage(new Uri(openFileDialog.FileName));

                pathImageProduct = openFileDialog.FileName;
            }
        }
        private void BtnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            // валидация 

            // добавление
            Product product = new Product();
            product.Name = TbName.Text;
            product.Price = Convert.ToDecimal(TbPrice.Text);
            product.IDCategory = (CmbCategory.SelectedItem as Category).IDCategory;
            if (pathImageProduct != null)
            {
                product.Photo = File.ReadAllBytes(pathImageProduct);
            }


            EfClass.Context.Product.Add(product);
            EfClass.Context.SaveChanges();

            MessageBox.Show("Товар добавлен");

            this.Close();
        }
    }
}
