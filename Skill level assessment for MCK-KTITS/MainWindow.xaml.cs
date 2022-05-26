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
using System.Windows.Shapes;
using SkillAssesmentCore;

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
            adminEditFrame.NavigationService.Navigate(new Pages.AdminEditPage());
            if (CurrentUser.User.role_id == 1)
                tabAdmin.Visibility = Visibility.Visible;
        }
    }
}
