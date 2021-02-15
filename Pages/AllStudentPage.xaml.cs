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
    /// Логика взаимодействия для AllStudentPage.xaml
    /// </summary>
    public partial class AllStudentPage : Page
    {
        Core.teacher69Entities context;
        public AllStudentPage()
        {
            InitializeComponent();
            context = new Core.teacher69Entities();

            GroupComboBox.ItemsSource = context.Groups.ToList();
            GroupComboBox.DisplayMemberPath = "NameGroup";
            GroupComboBox.SelectedValuePath = "IdGroup";
            AllDataGrid.ItemsSource = context.Students.ToList();
        }

        private void GroupComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int a = Convert.ToInt32(GroupComboBox.SelectedValue);
            AllDataGrid.ItemsSource = context.Students.Where(x => x.IdGroup == a).ToList();
        }
    }
}
