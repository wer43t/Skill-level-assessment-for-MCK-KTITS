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
    /// Логика взаимодействия для DisctrictsPage.xaml
    /// </summary>
    public partial class DisctrictsPage : Page
    {
        Core core = new Core();
        public DisctrictsPage()
        {
            InitializeComponent();
            dgDisctricts.ItemsSource = core.GetDiscticts();
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
            foreach(var v in dgDisctricts.SelectedItems)
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
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            foreach(var disctict in dgDisctricts.SelectedItems)
            {
                if(disctict != CollectionView.NewItemPlaceholder)
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
        }
    }
}
