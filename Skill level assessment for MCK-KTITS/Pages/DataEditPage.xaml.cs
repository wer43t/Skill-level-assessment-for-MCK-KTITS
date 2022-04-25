using System.Windows.Controls;

namespace Skill_level_assessment_for_MCK_KTITS.Pages
{
    /// <summary>
    /// Логика взаимодействия для DataEditPage.xaml
    /// </summary>
    public partial class DataEditPage : Page
    {
        public DataEditPage()
        {
            InitializeComponent();
            disctrictsFrame.NavigationService.Navigate(new SubPages.DisctrictsPage());
            institutionFrame.NavigationService.Navigate(new SubPages.InstitutionPage());
            postsFrame.NavigationService.Navigate(new SubPages.PostsPage());
            subjectsFrame.NavigationService.Navigate(new SubPages.SubjectsPage());
            categoriesFrame.NavigationService.Navigate(new SubPages.CategoriesPage());
            teachersFrame.NavigationService.Navigate(new SubPages.TeachersPage());
        }
    }
}
