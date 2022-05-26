using SkillAssesmentCore;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Skill_level_assessment_for_MCK_KTITS.SubPages
{
    /// <summary>
    /// Логика взаимодействия для DisctrictsPage.xaml
    /// </summary>
    public partial class DisctrictsPage : Page
    {
        Core core = new Core();
        public DisctrictsPage()
        {
            InitializeComponent();
            dgDisctricts.ItemsSource = core.GetDiscticts();
            lbDistrictsCount.Content = $"Количество записей: {core.GetDiscticts().Count}";
            if (CurrentUser.User.role_id == 3)
                pageVsible.IsEnabled = false;
        }

        private void dgDisctricts_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName.StartsWith("name"))
            {
                e.Column.Header = "Районы";
                e.Column.Width = new DataGridLength(1.0, DataGridLengthUnitType.Star);
            }
            else
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            dgDisctricts.SelectedItem = dgDisctricts.Items[dgDisctricts.Items.Count - 1];
        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            foreach (var v in dgDisctricts.SelectedItems)
            {
                if (v != CollectionView.NewItemPlaceholder)
                {
                    MessageBox.Show((v as Discticts).name);
                    try
                    {
                        core.AddDisctics((v as Discticts).name);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            dgDisctricts.ItemsSource = core.GetDiscticts();
            lbDistrictsCount.Content = $"Количество записей: {core.GetDiscticts().Count}";
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            foreach (var disctict in dgDisctricts.SelectedItems)
            {
                if (disctict != CollectionView.NewItemPlaceholder)
                {
                    if (MessageBox.Show($"Вы действильно хотите удалить {(disctict as Discticts).name}?", "Подтверждение удаления", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        core.RemoveDisctics(disctict as Discticts);
                    }
                    else
                    {
                        MessageBox.Show("Удаление отменено");
                    }
                }
            }
            dgDisctricts.ItemsSource = core.GetDiscticts();
            lbDistrictsCount.Content = $"Количество записей: {core.GetDiscticts().Count}";
        }
    }
}
