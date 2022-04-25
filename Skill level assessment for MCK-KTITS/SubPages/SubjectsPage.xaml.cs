using SkillAssesmentCore;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Skill_level_assessment_for_MCK_KTITS.SubPages
{
    /// <summary>
    /// Логика взаимодействия для SubjectsPage.xaml
    /// </summary>
    public partial class SubjectsPage : Page
    {
        Core core = new Core();
        public SubjectsPage()
        {
            InitializeComponent();
            dgSubjects.ItemsSource = core.GetSubjects();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            foreach (var subject in dgSubjects.SelectedItems)
            {
                if (subject != CollectionView.NewItemPlaceholder)
                {
                    if (MessageBox.Show($"Вы действильно хотите удалить {(subject as Subjects).name}?", "Подтверждение удаления", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        core.RemoveSubject(subject as Subjects);
                    }
                    else
                    {
                        MessageBox.Show("Удаление отменено");
                    }
                }
            }
            dgSubjects.ItemsSource = core.GetPosts();
        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            foreach (var subject in dgSubjects.SelectedItems)
            {
                if (subject != CollectionView.NewItemPlaceholder && (subject as Subjects).name != null)
                {
                    MessageBox.Show((subject as Subjects).name);
                    try
                    {
                        core.AddSubject((subject as Subjects).name);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            dgSubjects.SelectedItem = dgSubjects.Items[dgSubjects.Items.Count - 1];
            dgSubjects.SelectedItem = Focus();
        }

        private void dgSubjects_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName.StartsWith("name"))
            {
                e.Column.Header = "Предметы";
                e.Column.Width = new DataGridLength(1.0, DataGridLengthUnitType.Star);
            }
            else
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
        }
    }
}
