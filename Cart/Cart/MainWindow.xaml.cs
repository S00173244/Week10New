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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cart
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Product> productList = new List<Product>();
        List<Product> cartList = new List<Product>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Product product1 = new Product("1234", "book", 12.53);
            productList.Add(product1);
            Product product2 = new Product("1235", "bike", 780.00);
            productList.Add(product2);
            Product product3 = new Product("1236", "boat", 900.00);
            productList.Add(product3);

            lbox_products.ItemsSource = productList;


        }

        private void btn_addTax_Click(object sender, RoutedEventArgs e)
        {
            foreach (Product item in productList)
            {
                item.AddTax(0.03);

            }
            lbox_products.ItemsSource = "";
            lbox_products.ItemsSource = productList;
        }

        private void btn_addToCart_Click(object sender, RoutedEventArgs e)
        {
            if (lbox_products.SelectedItem != null)
            {

                if (!cartList.Contains(lbox_products.SelectedItem as Product)) cartList.Add(lbox_products.SelectedItem as Product);

                lbox_cart.ItemsSource = "";
                lbox_cart.ItemsSource = cartList;
            }


        }

        private void btn_rmvFromCart_Click(object sender, RoutedEventArgs e)
        {


            if (lbox_cart.SelectedItem != null)
            {

                cartList.Remove(lbox_cart.SelectedItem as Product);

                lbox_cart.ItemsSource = "";
                lbox_cart.ItemsSource = cartList;
            }
        }
    
    }
}
