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
            lbTeachersCount.Content = $"Количество записей: {core.GetTeachers().Count}";
            this.DataContext = this;
            if (CurrentUser.User.role_id == 3)
                pageVsible.IsEnabled = false;
        }

        private void Core_AddNewItemEvent()
        {
            Teachers = core.GetTeachers();
            dgTeachers.ItemsSource = Teachers.ToList();
            dgTeachers.Items.Refresh();
            UpdateItemsCount();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            dgTeachers.SelectedItem = dgTeachers.Items[dgTeachers.Items.Count - 1];
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            foreach (var teacher in dgTeachers.SelectedItems)
            {
                if (teacher != CollectionView.NewItemPlaceholder)
                {
                    if (MessageBox.Show($"Вы действильно хотите удалить {(teacher as Teachers).name}?", "Подтверждение удаления", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        core.RemoveTeachers(teacher as Teachers);
                    }
                    else
                    {
                        MessageBox.Show("Удаление отменено");
                    }
                }
            }
            dgTeachers.ItemsSource = core.GetTeachers();
            UpdateItemsCount();
        }

        private void UpdateItemsCount()
        {
            lbTeachersCount.Content = $"Количество записей: {core.GetTeachers().Count}";
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
