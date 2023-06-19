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
using ООО_Посуда1.Models;
using ООО_Посуда1.UserControls;

namespace ООО_Посуда1.Windows
{
    /// <summary>
    /// Логика взаимодействия для ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        public static Posuda_db DbContext;
        Order Orders;
        List<Product> selectedProducts = new List<Product>();
        User User;

        public ProductWindow(User user)
        {
            InitializeComponent();
            DbContext = new Posuda_db();

            if (user != null)
            {
                User = user;
                Orders = DbContext.Orders.Where(o => o.UserId == user.Iduser).FirstOrDefault();
            }
            else
            {
                Orders = new Order();
            }

            UpdateWindow();
        }

        private void UpdateWindow()
        {
            ProductListView.Items.Clear();

            List<Product> displayProducts = new List<Product>();
            displayProducts = DbContext.Products.ToList();

            if (!string.IsNullOrEmpty(SearchTextBox.Text))
            {
                displayProducts = displayProducts.Where(p =>
                    p.Name.ToLower().Contains(SearchTextBox.Text.ToLower())
                    || p.Description.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList();
            }

            foreach(Product product in displayProducts)
            {
                ProductListView.Items.Add(new ProductUserControl(product)
                {
                    Width = GetOptimizedWidth()
                });
            }
        }

        private double GetOptimizedWidth()
        {
            if (WindowState == WindowState.Maximized)
            {
                return RenderSize.Width - 55;
            }
            else
            {
                return Width - 55;
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void OrdersButton_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow orderWindow = new OrderWindow(selectedProducts);
            orderWindow.ShowDialog();
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateWindow();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateWindow();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (ProductListView.SelectedItem != null)
            {
                Product product = ((ProductUserControl)ProductListView.SelectedItem).Product;

                selectedProducts.Add(product);

                if (selectedProducts.Count > 0)
                {
                    OrdersButton.Visibility = Visibility.Visible;
                }
            }
        }
    }
}
