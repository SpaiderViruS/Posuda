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
using ООО_Посуда1.Models;

namespace ООО_Посуда1.UserControls
{
    /// <summary>
    /// Логика взаимодействия для ProductUserControl.xaml
    /// </summary>
    public partial class ProductUserControl : UserControl
    {
        public Product Product;

        /// <summary>
        /// Конструктор ProductUserControl
        /// </summary>
        /// <param name="product">Продукт</param>
        public ProductUserControl(Product product)
        {
            InitializeComponent();
            Product = product;

            LoadLabels();
            LoadImage();
        }

        /// <summary>
        /// Метод для загрузки Label
        /// </summary>
        private void LoadLabels()
        {
            NameLabel.Content = Product.Name;
            DescriptionLabel.Content = Product.Description;
            CostLabel.Content = Product.Cost;
            AmountLabel.Content = Product.Amount;
            DiscountLabel.Content = Product.Discount;
        }

        /// <summary>
        /// Метод для загрузки Image
        /// </summary>
        private void LoadImage()
        {
            if (Product.Photo != null && Product.Photo.Length > 0)
            {
                Console.WriteLine(Environment.CurrentDirectory + Product.Photo);
                ImageProduct.Source = new BitmapImage(
                    new Uri(Environment.CurrentDirectory + "//images//" + Product.Photo, UriKind.Absolute));
            }
            else
            {
                ImageProduct.Source = new BitmapImage(
                    new Uri(Environment.CurrentDirectory + "//images//image.png", UriKind.Relative));
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
