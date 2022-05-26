using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для AdminViewPage.xaml
    /// </summary>
    public partial class AdminViewPage : Page
    {
        public ObservableCollection<Users> Users { get; set; }
        Core core = new Core();
        public AdminViewPage()
        {
            InitializeComponent();
            Users = core.GetUsers();
            Core.AddNewItemEvent += Core_AddNewItemEvent;
            dgUsers.ItemsSource = Users;
            this.DataContext = DataContext;
            if (CurrentUser.User.role_id == 3)
                pageVsible.IsEnabled = false;
        }

        private void Core_AddNewItemEvent()
        {
            dgUsers.ItemsSource = core.GetUsers();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SubPages.UserEditPage());
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgUsers.SelectedItem != null)
                NavigationService.Navigate(new SubPages.UserEditPage(dgUsers.SelectedItem as Users));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            lock (dgUsers.SelectedItems)
            if((dgUsers.SelectedItem as Users) != null)
            {
                foreach(var u in dgUsers.SelectedItems)
                {
                    if (u != CollectionView.NewItemPlaceholder)
                    {
                        if (MessageBox.Show($"Вы действильно хотите удалить {(u as Users).name}?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            core.RemoveUsers(u as Users);
                        }
                        else
                        {
                            MessageBox.Show("Удаление отменено", "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
            dgUsers.ItemsSource = core.GetUsers();
        }

    }
}
