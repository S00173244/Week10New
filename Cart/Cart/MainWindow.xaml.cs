using System;
using System.Collections.Generic;
using System.Globalization;
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
            string[] bikeTypes = { "All", "Male", "Female" };
            cbox_bikeType.ItemsSource = bikeTypes;
            cbox_bikeType.SelectedIndex = 0;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Product product1 = new Product("1234", "book", 876.53, new Variation("Female"));
            productList.Add(product1);
            Product product2 = new Product("1235", "bike", 780.00, new Variation("Male"));
            productList.Add(product2);
            Product product3 = new Product("1236", "boat", 900.00, new Variation("Female"));
            productList.Add(product3);
            Product product4 = new Product("1237", "book", 532.53, new Variation("Female"));
            productList.Add(product4);
            Product product5 = new Product("1238", "bike", 263.00, new Variation("Male"));
            productList.Add(product5);
            Product product6 = new Product("1239", "boat", 124.00, new Variation("Female"));
            productList.Add(product6);

            lbox_products.ItemsSource = "";
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
            lbox_cart.ItemsSource = "";
            lbox_cart.ItemsSource = cartList;

            lbl_calculatedCost.Content = calculateTotalCost().ToString("C", CultureInfo.CurrentCulture);

        }

        private void btn_addToCart_Click(object sender, RoutedEventArgs e)
        {
            if (lbox_products.SelectedItem != null)
            {

                if (!cartList.Contains(lbox_products.SelectedItem as Product)) cartList.Add(lbox_products.SelectedItem as Product);

                lbox_cart.ItemsSource = "";
                lbox_cart.ItemsSource = cartList;

                lbl_calculatedCost.Content = calculateTotalCost().ToString("C", CultureInfo.CurrentCulture);
            }


        }

        private void btn_rmvFromCart_Click(object sender, RoutedEventArgs e)
        {


            if (lbox_cart.SelectedItem != null)
            {

                cartList.Remove(lbox_cart.SelectedItem as Product);

                lbox_cart.ItemsSource = "";
                lbox_cart.ItemsSource = cartList;
                lbl_calculatedCost.Content = calculateTotalCost().ToString("C", CultureInfo.CurrentCulture);

            }
        }

        private void cbox_bikeType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lbox_products.ItemsSource = "";
            List<Product> tempList = new List<Product>();

            if ("All" == (string)cbox_bikeType.SelectedItem)
            {
                lbox_products.ItemsSource = productList;
            }
            else
            {
                foreach (Product item in productList)
                {
                    if (item.Variation.Type == (string)cbox_bikeType.SelectedItem)
                    {
                        tempList.Add(item);
                    }

                }

                lbox_products.ItemsSource = tempList;
            }
               
            
        }

        private double calculateTotalCost()
        {
            double total = 0;
            
            //if (lbox_cart.SelectedItem != null)
            //{

                foreach (Product item in cartList)
                {
                    total += item.Price + item.Tax;
                }
            //}
            return total;
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
