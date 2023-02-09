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
            GetListProduct();
        }

        
    }

    private void GetListProduct()
    {
        List<Product> products = new List<Product>();
        products = EFClass.Context.Product.ToList();

        LvProduct.ItemsSource = products;
    }
}
}
    }
}
