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

namespace ООО_Посуда1.Windows
{
    /// <summary>
    /// Логика взаимодействия для OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        public Posuda_db DbContext;
        int totalCost = 0;
        List<Product> OrderProducts;

        public OrderWindow(List<Product> products)
        {
            InitializeComponent();

            OrderProducts = products;
            DbContext = new Posuda_db();

            LoadOrder();
        }

        private void LoadOrder()
        {
            ProductListView.Items.Clear();

            DeliveryDate.Content = DateTime.Now.AddDays(3).ToString();

            Random rnd = new Random();
            PickupCode.Content = rnd.Next(100, 999).ToString();

            PickupPointComboBox.ItemsSource = DbContext.PickupPoints.ToList();

            foreach (Product product in OrderProducts)
            {
                ProductListView.Items.Add($"{product.Name}\nСтоимость: {product.Cost}");
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MakeOrder_Click(object sender, RoutedEventArgs e)
        {
            int id;

            Order order = new Order();

            order.OrderDate = DateTime.Now.ToString();
            //order.DeliveryDate = DateTime.Now.AddDays(3);

            foreach (Product product in OrderProducts)
            {
                OrderProduct orderProduct = new OrderProduct();
                orderProduct.ProductId = orderProduct.ProductId;
                //orderProduct.OrderId
            }
        }

        private void MakeTicket_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
