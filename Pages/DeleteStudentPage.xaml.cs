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
    /// Логика взаимодействия для DeleteStudentPage.xaml
    /// </summary>
    public partial class DeleteStudentPage : Page
    {
        Core.teacher69Entities context;
        public DeleteStudentPage()
        {
            InitializeComponent();
            context = new Core.teacher69Entities();

            GroupComboBox.ItemsSource = context.Groups.ToList();
            GroupComboBox.DisplayMemberPath = "NameGroup";
            GroupComboBox.SelectedValuePath = "IdGroup";
            DeleteDataGrid.ItemsSource = context.Students.ToList();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Core.Students students = (Core.Students)DeleteDataGrid.Items[DeleteDataGrid.SelectedIndex];
                context.Students.Remove(students);
                context.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Критический сбор в работе приложения:", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private void GroupComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int a = Convert.ToInt32(GroupComboBox.SelectedValue);
            DeleteDataGrid.ItemsSource = context.Students.Where(x => x.IdGroup == a).ToList();
        }
    }
}
