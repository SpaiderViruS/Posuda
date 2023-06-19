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
using ООО_Посуда1.Windows;

namespace ООО_Посуда1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Posuda_db DbContext;
        /// <summary>
        /// Конструктор MainWindow
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            DbContext = new Posuda_db();
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(LoginTextBox.Text) 
                && !string.IsNullOrEmpty(PasswordBox.Password))
            {
                User user = DbContext.Users.Where(u => u.Login == LoginTextBox.Text 
                && u.Password == PasswordBox.Password).FirstOrDefault();

                if (user != null)
                {
                    MessageBox.Show($"Добро пожаловать, {user.Role.RoleName} {user.Name} {user.Surname} {user.Patronomyc}",
                        "Уведоиление", MessageBoxButton.OK, MessageBoxImage.Information);

                    ProductWindow productWindow = new ProductWindow(user);
                    productWindow.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Неверный логин/пароль", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Заполните поля", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EnterAsGuestButton_Click(object sender, RoutedEventArgs e)
        {
            ProductWindow productWindow = new ProductWindow(null);
            productWindow.Show();
            Close();
        }
    }
}
