using SkillAssesmentCore;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Skill_level_assessment_for_MCK_KTITS.SubPages
{
    /// <summary>
    /// Логика взаимодействия для PostsPage.xaml
    /// </summary>
    public partial class PostsPage : Page
    {
        Core core = new Core();
        public PostsPage()
        {
            InitializeComponent();
            dgPosts.ItemsSource = core.GetPosts();
        }

        private void dgPosts_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName.StartsWith("name"))
            {
                e.Column.Header = "Должности";
                e.Column.Width = new DataGridLength(1.0, DataGridLengthUnitType.Star);
            }
            else
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            dgPosts.SelectedItem = dgPosts.Items[dgPosts.Items.Count - 1];
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            foreach (var post in dgPosts.SelectedItems)
            {
                if (post != CollectionView.NewItemPlaceholder)
                {
                    if (MessageBox.Show($"Вы действильно хотите удалить {(post as Posts).name}?", "Подтверждение удаления", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        core.RemovePosts(post as Posts);
                    }
                    else
                    {
                        MessageBox.Show("Удаление отменено");
                    }
                }
            }
            dgPosts.ItemsSource = core.GetPosts();
        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            foreach (var v in dgPosts.SelectedItems)
            {
                if (v != CollectionView.NewItemPlaceholder && (v as Posts).name != null)
                {
                    MessageBox.Show((v as Posts).name);
                    try
                    {
                        core.AddPosts((v as Posts).name);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
    }
}
