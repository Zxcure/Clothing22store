﻿using Clothing22store.Db;
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

        private void GetList()
        {
            List<Product> products = new List<Product>();
            products = EF.EfClass.Context.Product.ToList();
            LvProduct1.ItemsSource = products;
        }
    }

   
}

