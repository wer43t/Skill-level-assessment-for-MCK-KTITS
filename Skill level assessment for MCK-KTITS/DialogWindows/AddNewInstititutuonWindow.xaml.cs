using SkillAssesmentCore;
using System.Collections.ObjectModel;
using System.Windows;

namespace Skill_level_assessment_for_MCK_KTITS.DialogWindows
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        Core core = new Core();
        ObservableCollection<Discticts> discticts { get; }
        public Window1()
        {
            InitializeComponent();
            discticts = core.GetDiscticts();
            cmBoxDisctricts.ItemsSource = discticts;
        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            if ((cmBoxDisctricts.SelectedItem as Discticts) != null)
            {
                Institution institution = new Institution()
                {
                    name = tBoxInstitutuonName.Text,
                    disctrict_id = (cmBoxDisctricts.SelectedItem as Discticts).disctrict_id
                };
                core.AddInstitution(institution);
            }
            this.Close();
        }
    }
}
