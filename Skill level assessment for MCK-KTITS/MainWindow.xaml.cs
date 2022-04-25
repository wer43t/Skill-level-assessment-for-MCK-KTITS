using System.Windows;

namespace Skill_level_assessment_for_MCK_KTITS
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            blanksFrame.NavigationService.Navigate(new Pages.BlanksMainPage());
            dataEditFrame.NavigationService.Navigate(new Pages.DataEditPage());
        }
    }
}
