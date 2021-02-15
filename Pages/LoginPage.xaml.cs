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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    { Core.teacher69Entities context;
        public LoginPage()
        {
            InitializeComponent();
            context = new Core.teacher69Entities();
        }

        private void AccessButton_click(object sender, RoutedEventArgs e)
        {
            int a = context.Users.Where(x => x.Login == LoginTextBox.Text && x.Password == PasswordTextBox.Password).Count();
            if (a == 1)
            {
               this.NavigationService.Navigate(new MainMenuPage());
            }
            else
            {
                this.NavigationService.Navigate(new nigra());
            }
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RegPage());
        }
    }
}
