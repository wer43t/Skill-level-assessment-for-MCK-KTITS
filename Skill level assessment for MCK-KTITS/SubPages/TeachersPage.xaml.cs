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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SkillAssesmentCore;

namespace Skill_level_assessment_for_MCK_KTITS.SubPages
{
    /// <summary>
    /// Логика взаимодействия для TeachersPage.xaml
    /// </summary>
    public partial class TeachersPage : Page
    {
        Core core = new Core();
        public ObservableCollection<Teachers> Teachers { get; set; }
        public int teachersCount { get; set; }

        public TeachersPage()
        {
            InitializeComponent();
            Teachers = core.GetTeachers();
            Core.AddNewItemEvent += Core_AddNewItemEvent;
            teachersCount = Teachers.Count;
            DataContext = this;
        }

        private void Core_AddNewItemEvent()
        {
            Teachers = core.GetTeachers();
            dgTeachers.ItemsSource = Teachers.ToList();
            dgTeachers.Items.Refresh();
            lbTeachersCount.Content = Teachers.Count;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            dgTeachers.SelectedItem = dgTeachers.Items[dgTeachers.Items.Count - 1];
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCreateTeacher_Click(object sender, RoutedEventArgs e)
        {
            DialogWindows.AddNewTeacherWindow teacherWindow = new DialogWindows.AddNewTeacherWindow();
            teacherWindow.Show();
        }
    }
}
