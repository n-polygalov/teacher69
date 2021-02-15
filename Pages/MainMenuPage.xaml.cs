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
    /// Логика взаимодействия для MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : Page
    {
        public MainMenuPage()
        {
            InitializeComponent();
        }

        private void AddStudentBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddStudentPage());
        }

        private void AddRatingBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RatingPage());

        }

        private void AllStudentBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AllStudentPage());
        }

        private void DeleteStudentBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new DeleteStudentPage());
        }

        private void EditRatingBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new EditRatingPage());
        }
    }
}
