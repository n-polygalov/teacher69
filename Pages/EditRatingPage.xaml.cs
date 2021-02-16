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
    /// Логика взаимодействия для EditRatingPage.xaml
    /// </summary>
    public partial class EditRatingPage : Page
    {
        Core.teacher69Entities context;
        public EditRatingPage()
        {
            InitializeComponent();
            context = new Core.teacher69Entities();

            GroupComboBox.ItemsSource = context.Groups.ToList();
            GroupComboBox.DisplayMemberPath = "NameGroup";
            GroupComboBox.SelectedValuePath = "IdGroup";

            SubjectsComboBox.ItemsSource = context.Subjects.ToList();
            SubjectsComboBox.DisplayMemberPath = "NameSubject";
            SubjectsComboBox.SelectedValuePath = "IdSubject";

        }

        private void GroupComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int a = Convert.ToInt32(GroupComboBox.SelectedValue);
            EditDataGrid.ItemsSource = context.Journals.Where(x => x.IdGroup == a).ToList();
        }

        private void SubjectsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var dates = context.Journals.Select(x=> x.date.ToString()).Distinct().ToList();

            for(int i = 0; i < dates.Count; i++)
            {
                DataGridTextColumn textColumn = new DataGridTextColumn();
                textColumn.Header = String.Format("{0: dd.MM.yyyy}", dates[i]);
                textColumn.Binding = new Binding("Evaluation");
                EditDataGrid.Columns.Add(textColumn);
            }
           

            EditDataGrid.ItemsSource = context.Journals.ToList();
            
        }
    }
}