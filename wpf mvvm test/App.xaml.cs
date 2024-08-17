using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using wpf_mvvm_test.ViewModels;

namespace wpf_mvvm_test
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            wpf_mvvm_test.MainWindow window = new MainWindow();
            UserViewModel model = new UserViewModel();
            window.DataContext = model;
            window.Show();
        }
    }
}
