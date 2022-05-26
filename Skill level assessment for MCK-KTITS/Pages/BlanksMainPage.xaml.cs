using System.Windows.Controls;
using QuizzModuleWpf;
using QuizzModuleCore;
using SkillAssesmentCore;
using System.Collections.ObjectModel;
using System.Linq;

namespace Skill_level_assessment_for_MCK_KTITS.Pages
{
    /// <summary>
    /// Логика взаимодействия для BlanksMainPage.xaml
    /// </summary>
    public partial class BlanksMainPage : Page
    {
        PassingTheTestWindow window;
        static CategoryService service;
        PassingTheTestPage page;
        Core core = new Core();
        public ObservableCollection<Discticts> Districts { get; set; }
        public ObservableCollection<Institution> Institutions { get; set; }
        public ObservableCollection<Teachers> Teachers { get; set; }

        public BlanksMainPage()
        {
            InitializeComponent();
            Districts = core.GetDiscticts();
            Institutions = core.GetInstitutions();
            Teachers = core.GetTeachers();
            tBoxExpert.Text = core.GetFullUserName();
            if (CurrentUser.User.role_id == 3)
                cmBoxDistrict.IsEnabled = false;
            this.DataContext = this;
        }

        private void cmBoxDistrict_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cmBoxInstitution.IsEnabled = true;
            cmBoxTeacher.IsEnabled = false;
            btnExport.IsEnabled = false;
            btnStart.IsEnabled = false;
            btnPrinting.IsEnabled = false;
            cmBoxInstitution.ItemsSource = Institutions.Where(x => x.disctrict_id == (cmBoxDistrict.SelectedItem as Discticts).disctrict_id);
        }

        private void cmBoxInstitution_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cmBoxTeacher.IsEnabled = true;
            btnExport.IsEnabled = false;
            btnStart.IsEnabled = false;
            btnPrinting.IsEnabled = false;
            cmBoxTeacher.ItemsSource = Teachers.Where(x => x.institution_id == (cmBoxInstitution.SelectedItem as Institution)?.institution_id);

        }

        private void cmBoxTeacher_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmBoxTeacher.SelectedItem != null)
            {

            btnExport.IsEnabled = true;
            btnStart.IsEnabled = true;
            btnPrinting.IsEnabled = true;
            }
            service = new CategoryService();
            page = new PassingTheTestPage(service);
        }

        private void btnStart_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            window = new PassingTheTestWindow(page);
            window.Show();
        }

        private void btnExport_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            service.CreateReport(tBoxExpert?.Text, core.GetFullNameTeacher(cmBoxTeacher.SelectedItem as Teachers),
                (cmBoxTeacher.SelectedItem as Teachers).Categories.name, (cmBoxTeacher.SelectedItem as Teachers).Subjects.name);
        }
    }
}
