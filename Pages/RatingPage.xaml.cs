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
    /// Логика взаимодействия для RatingPage.xaml
    /// </summary>
    public partial class RatingPage : Page
    {
        Core.teacher69Entities context;
        public RatingPage()
        {
            InitializeComponent();
            context = new Core.teacher69Entities();

            GroupList.ItemsSource = context.Groups.ToList();
            GroupList.DisplayMemberPath = "NameGroup";
            GroupList.SelectedValuePath = "IdGroup";
           



        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int Group = Convert.ToInt32(GroupList.SelectedValue);
                int Student = Convert.ToInt32(StudentList.SelectedValue);
                int Subject = Convert.ToInt32(SubjectsList.SelectedValue);
                int Rating = Convert.ToInt32(RatingTextBox.Text);

                Core.Journals journals = new Core.Journals()
                {
                    IdStudent = Student,
                    IdGroup = Group,
                    IdSubject = Subject,
                    Evaluation = Rating
                };


                context.Journals.Add(journals);
                context.SaveChanges();

            }
            catch
            {
                MessageBox.Show("Критический сбор в работе приложения:", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private void GroupList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int Group = Convert.ToInt32(GroupList.SelectedValue);
            StudentList.ItemsSource = context.Students.Where(x => x.IdGroup == Group).ToList();
            StudentList.DisplayMemberPath = "FiestName";
            StudentList.SelectedValuePath = "IdStudent";

            SubjectsList.ItemsSource = context.Subjects.ToList();
            SubjectsList.DisplayMemberPath = "NameSubject";
            SubjectsList.SelectedValuePath = "IdSubject";
        }
    }
}
