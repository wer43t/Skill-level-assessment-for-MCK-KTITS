﻿using System;
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

namespace Skill_level_assessment_for_MCK_KTITS.Pages
{
    /// <summary>
    /// Логика взаимодействия для DataEditPage.xaml
    /// </summary>
    public partial class DataEditPage : Page
    {
        public DataEditPage()
        {
            InitializeComponent();
            disctrictsFrame.NavigationService.Navigate(new SubPages.DisctrictsPage());
            institutionFrame.NavigationService.Navigate(new SubPages.InstitutionPage());
        }
    }
}
