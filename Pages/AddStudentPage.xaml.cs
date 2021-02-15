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
    /// Логика взаимодействия для AddStudentPage.xaml
    /// </summary>
    public partial class AddStudentPage : Page
    {
        Core.teacher69Entities context;
        public AddStudentPage()
        {
            InitializeComponent();
            context = new Core.teacher69Entities();

            Professions_List.ItemsSource = context.Professions.ToList();
            Professions_List.DisplayMemberPath = "NameProfession";
            Professions_List.SelectedValuePath = "IdProfession";

            YearAddList.ItemsSource = context.YearAdd.ToList();
            YearAddList.DisplayMemberPath = "Year";
            YearAddList.SelectedValuePath = "idYear";

            FormTimeList.ItemsSource = context.FormTime.ToList();
            FormTimeList.DisplayMemberPath = "Name";
            FormTimeList.SelectedValuePath = "Id";

            GroupsList.ItemsSource = context.Groups.ToList();
            GroupsList.DisplayMemberPath = "NameGroup";
            GroupsList.SelectedValuePath = "IdGroup";
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
           
            try
            {
                string[] name = NameStudentBox.Text.Split(' ');

               
                int NameProfession = Convert.ToInt32(Professions_List.SelectedValue);

               
                int Year = Convert.ToInt32(YearAddList.SelectedValue);

                
                int Name = Convert.ToInt32(FormTimeList.SelectedValue);

                
                int NameGroup = Convert.ToInt32(GroupsList.SelectedValue);

                string str = String.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}", name[0], name[1], name[2], NameProfession, Name, NameGroup, Year);
                Core.Students students = new Core.Students()
                {
                    FiestName = name[0],
                    LastName = name[1],
                    PatronomicName = name[2],
                    IdProfession = NameProfession,
                    IdFormTime = Name,
                    IdGroup = NameGroup, 
                    IdYearAdd = Year
                };
                
                context.Students.Add(students);
                context.SaveChanges();

            }
            catch
            {
                MessageBox.Show("Критический сбор в работе приложения:", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
    }
}
