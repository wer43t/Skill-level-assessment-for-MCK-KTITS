using SkillAssesmentCore;
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

namespace Skill_level_assessment_for_MCK_KTITS.SubPages
{
    /// <summary>
    /// Логика взаимодействия для CategoriesPage.xaml
    /// </summary>
    public partial class CategoriesPage : Page
    {
        Core core = new Core();
        public int categoriesCount { get; set; }
        public CategoriesPage()
        {
            InitializeComponent();
            dgCategories.ItemsSource = core.GetCategories();
            lblCategoriesCount.Content = $"Количество записей: {core.GetCategories().Count}";
            this.DataContext = this;
            if (CurrentUser.User.role_id == 3)
                pageVsible.IsEnabled = false;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            foreach (var category in dgCategories.SelectedItems)
            {
                if (category != CollectionView.NewItemPlaceholder)
                {
                    if (MessageBox.Show($"Вы действильно хотите удалить {(category as Categories).name}?", "Подтверждение удаления", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        core.RemoveCategory(category as Categories);
                    }
                    else
                    {
                        MessageBox.Show("Удаление отменено");
                    }
                }
            }
            dgCategories.ItemsSource = core.GetCategories();
            lblCategoriesCount.Content = $"Количество записей: {core.GetCategories().Count}";
        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            foreach (var category in dgCategories.SelectedItems)
            {
                if (category != CollectionView.NewItemPlaceholder && (category as Categories).name != null)
                {
                    MessageBox.Show((category as Categories).name);
                    try
                    {
                        core.AddCategory((category as Categories).name);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            dgCategories.ItemsSource = core.GetCategories();
            lblCategoriesCount.Content = $"Количество записей: {core.GetCategories().Count}";
        }

        private void dgCategories_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName.StartsWith("name"))
            {
                e.Column.Header = "Категории";
                e.Column.Width = new DataGridLength(1.0, DataGridLengthUnitType.Star);
            }
            else
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
        }
    }
}
