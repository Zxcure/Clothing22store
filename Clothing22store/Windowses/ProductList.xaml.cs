using Clothing22store.Db;
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


namespace Clothing22store.Windowses
{
    /// <summary>
    /// Логика взаимодействия для ProductList.xaml
    /// </summary>
    public partial class ProductList : Window
    {
        public ProductList()
        {
            InitializeComponent();
            GetList();
        }
        private void GetCountCartProduct()
        {
            TxtCartCount.Text = EF.Cart.Products.Count.ToString();
        }
        private void GetList()
        {
            List<Product> products = new List<Product>();
            products = EF.UserDataClas.Context.Product.ToList();
            LvProduct.ItemsSource = products;
        }
        private void BtnAddProduct_Click(object sender, RoutedEventArgs e)
        {
         
            AddProd addEditProductWindow = new AddProd();
            addEditProductWindow.ShowDialog();

            GetList();
        }

        private void BtnMore_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button == null)
            {
                return;
            }
            Product selectedProduct = button.DataContext as Product;
            AddProd addEditProductWindow = new AddProd(selectedProduct);
            addEditProductWindow.ShowDialog();

            GetList();
        }
        private void BtnCart_Click(object sender, RoutedEventArgs e)
        {
            // добавление в корзину

            Button button = sender as Button;
            if (button == null)
            {
                return;
            }

            Product selectedProduct = button.DataContext as Product;

            EF.Cart.Products.Add(selectedProduct);

            GetCountCartProduct();
        }

        private void BtnGoToCart_Click(object sender, RoutedEventArgs e)
        {
            Cart cArtWindow = new Cart();
            cArtWindow.Show();
            this.Close();

            GetCountCartProduct();
        }
    }

   
}

