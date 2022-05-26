using SkillAssesmentCore;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Skill_level_assessment_for_MCK_KTITS.SubPages
{
    /// <summary>
    /// Логика взаимодействия для InstitutionPage.xaml
    /// </summary>
    public partial class InstitutionPage : Page
    {
        ObservableCollection<Discticts> discticts;
        public int institutionCount { get; set; }
        Core core = new Core();
        public InstitutionPage()
        {
            InitializeComponent();
            UpdateDate(core.GetInstitutions());
                        if (CurrentUser.User.role_id == 3)
                pageVsible.IsEnabled = false;
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
            foreach (var instituiton in dgInstitutions.SelectedItems)
            {
                if (instituiton != CollectionView.NewItemPlaceholder)
                {
                    if (MessageBox.Show($"Вы действильно хотите удалить {(instituiton as Institution).name}?", "Подтверждение удаления", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        core.RemoveInstitutions(instituiton as Institution);
                    }
                    else
                    {
                        MessageBox.Show("Удаление отменено");
                    }
                }
            }
            dgInstitutions.ItemsSource = core.GetInstitutions();
            lbInstitutionsCount.Content = $"Количество записей: {core.GetInstitutions().Count}";

        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Add();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            UpdateDate(core.GetInstitutions());
        }


        private void UpdateDate(ObservableCollection<Institution> institutions)
        {
            dgInstitutions.ItemsSource = institutions;
            discticts = core.GetDiscticts();
            cmBoxDistricts.ItemsSource = discticts;
            lbInstitutionsCount.Content = $"Количество записей: {institutions.Count}";

        }

        private void cmBoxDistricts_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            UpdateDate(core.GetInstitutions());
        }

        private void dgInstitutions_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            Add();
        }

        private void Add()
        {
            Window window = new DialogWindows.Window1();
            window.Show();
            window.Closing += Window_Closing;
        }

        private void cmBoxDistricts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var filteredData = core.GetInstitutionsOrderDistrict(cmBoxDistricts.SelectedItem as Discticts);
            UpdateDate(filteredData);
        }
    }
}
