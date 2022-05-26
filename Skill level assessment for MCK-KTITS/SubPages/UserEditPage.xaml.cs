using Microsoft.Win32;
using SkillAssesmentCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
    /// Логика взаимодействия для UserEditPage.xaml
    /// </summary>
    public partial class UserEditPage : Page
    {

        public Users User { get; set; }
        public ObservableCollection<Role> Roles;
        Core core = new Core();
        public UserEditPage()
        {
            InitializeComponent();


            User = new Users();
            Roles = core.GetRoles();
            cbRoles.ItemsSource = Roles;
            this.DataContext = this;
        }

        public UserEditPage(Users user)
        {
            InitializeComponent();

            User = user;
            Roles = core.GetRoles();
            cbRoles.ItemsSource = Roles;
            cbRoles.SelectedItem = User.Role;

            this.DataContext = user;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            User.login = tbLogin.Text;
            User.password = tbPassword.Text;
            User.name = tbName.Text;
            User.surname = tbSurname.Text;
            User.patronymic = tbPatronymic.Text;
            User.role_id = (cbRoles.SelectedItem as Role)?.role_id;

            var results = core.ValidateUser(User);
            lvProperties.ItemsSource = results;
            if (lvProperties.Items.Count != 0)
            {
                spErrors.Visibility = Visibility.Visible;
            }
            else
            {
                spErrors.Visibility = Visibility.Collapsed;
                if (core.AddUsers(User))
                {
                    NavigationService.GoBack();
                }
                else
                {
                    MessageBox.Show("Пользователь с таким логином уже существует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnAddPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Filter = "*.png|*.png|*.jpeg|*.jpeg|*.jpg|*.jpg"
            };

            if (fileDialog.ShowDialog().Value)
            {
                var photo = File.ReadAllBytes(fileDialog.FileName);
                if (photo.Length > 1024 * 150)  //Размер фотографии не должен превышать 150 Кбайт
                {
                    MessageBox.Show("Размер фотографии не должен превышать 150 КБ", "Ошибка");
                    return;
                }
                User.photo = photo;
                imgPhoto.Source = new BitmapImage(new Uri(fileDialog.FileName));
            }
        }
    }
}
