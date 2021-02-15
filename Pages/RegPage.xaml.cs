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

namespace teacher69.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        Core.teacher69Entities context;
        public RegPage()
        {
            InitializeComponent();
            context = new Core.teacher69Entities();
        }

        private void AccessButton_click(object sender, RoutedEventArgs e)
        {
            try
            {
                int a = context.Users.Where(x => x.Login == LoginTextBox.Text).Count();
                if (a == 0)
                {
                    if (PasswordTextBox.Password == RePasswordTextBox.Password)
                    {
                        Core.Users user = new Core.Users()
                        {
                            Login = LoginTextBox.Text,
                            Password = PasswordTextBox.Password
                        };
                        //context.users.Add(new Core.users
                        //{
                        //    login = LoginTextBox.Text,
                        //    password = PasswordTextBox.Password
                        //});
                        context.Users.Add(user);
                        context.SaveChanges();
                        this.NavigationService.Navigate(new LoginPage());
                    }
                }
            }
            catch
            {
                MessageBox.Show("Критический сбор в работе приложения:", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
           
        }
    }
}
