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
using System.Windows.Shapes;

namespace Skill_level_assessment_for_MCK_KTITS
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        Core core = new Core();
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if(core.IsUserCorrect(tbLogin.Text, pbPassword.Password))
            {
                var temp = App.Current.MainWindow;
                CurrentUser.User = core.GetUser(tbLogin.Text, pbPassword.Password);
                MainWindow window = new MainWindow();
                App.Current.MainWindow = window;
                App.Current.MainWindow.Show();
                temp.Close();
            }
            else
            {
                MessageBox.Show("Такого пользователя не существует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnWithoutLogin_Click(object sender, RoutedEventArgs e)
        {
            var temp = App.Current.MainWindow;
            CurrentUser.User = new Users { name = "Зритель",
                surname = "",
                patronymic = "",
                role_id = 3,
                Role = new Role
                {
                    role_id = 3,
                    name = "Зритель"
                }
            };
            MainWindow window = new MainWindow();
            App.Current.MainWindow = window;
            App.Current.MainWindow.Show();
            temp.Close();
        }
    }
}
