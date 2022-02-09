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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SkillAssesmentCore;

namespace Skill_level_assessment_for_MCK_KTITS.SubPages
{
    /// <summary>
    /// Логика взаимодействия для InstitutionPage.xaml
    /// </summary>
    public partial class InstitutionPage : Page
    {
        Core core = new Core();
        public InstitutionPage()
        {
            InitializeComponent();
            UpdateDate();
        }

        private void dgInstitutions_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName.StartsWith("name"))
            {
                e.Column.Header = "Учреждение";
                e.Column.Width = new DataGridLength(1.0, DataGridLengthUnitType.Star);
            }
            else
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
        }


        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void cmBoxDistricts_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
        }

        private void UpdateDate()
        {
            dgInstitutions.ItemsSource = core.GetInstitutions();
            foreach(var districts in core.GetDiscticts())
            {
                cmBoxDistricts.Items.Add(districts.name.ToString());
            }
        }

        private void cmBoxDistricts_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            UpdateDate();
        }
    }
}
