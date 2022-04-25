using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using SkillAssesmentCore;

namespace Skill_level_assessment_for_MCK_KTITS.DialogWindows
{
    /// <summary>
    /// Логика взаимодействия для AddNewTeacherWindow.xaml
    /// </summary>
    public partial class AddNewTeacherWindow : Window
    {
        Core core = new Core();
        
        public ObservableCollection<Discticts> Districts { get; set; }
        public ObservableCollection<Institution> Institutions { get; set; }
        public ObservableCollection<Posts> Posts { get; set; }
        public ObservableCollection<Subjects> Subjects { get; set; }
        public ObservableCollection<Categories> Categories { get; set; }
        public AddNewTeacherWindow()
        {
            InitializeComponent();
            Districts = core.GetDiscticts();
            Institutions = core.GetInstitutions();
            Posts = core.GetPosts();
            Subjects = core.GetSubjects();
            Categories = core.GetCategories();
            DataContext = this;

        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            var teacher = new Teachers
            {
                disctict_id = (cmBoxDisctricts.SelectedItem as Discticts)?.disctrict_id,
                institution_id = (cmBoxInstittution.SelectedItem as Institution)?.institution_id,
                categories_id = (cmBoxCategories.SelectedItem as Categories)?.categories_id,
                post_id = (cmBoxPosts.SelectedItem as Posts)?.position_id,
                subject_id = (cmBoxSubjects.SelectedItem as Subjects)?.subject_id,
                name = tBoxName.Text,
                surname = tBoxSurname.Text,
                patronymic = tBoxPatronymic.Text
            };
            var results = core.ValidateTeacher(teacher);
            lvProperties.ItemsSource = results;
            if (lvProperties.Items.Count != 0)
            {
                spErrors.Visibility = Visibility.Visible;
            }
            else
            {
                spErrors.Visibility = Visibility.Collapsed;
                core.AddTeachers(teacher);
                this.Close();
            }
        }

        private void cmBoxDisctricts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var filteredInstitutions = Institutions.Where(
                x => x.disctrict_id == (cmBoxDisctricts.SelectedItem as Discticts).disctrict_id);
            cmBoxInstittution.ItemsSource = filteredInstitutions;
            cmBoxInstittution.IsEnabled = true;
        }

    }
}
