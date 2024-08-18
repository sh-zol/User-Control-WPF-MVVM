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
using wpf_mvvm_test.ViewModels;

namespace wpf_mvvm_test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       // private UserViewModel _viewmodel;
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new UserViewModel();
            this.Closing += MainWindowClosing;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if(button != null )
            {
                txtEmail.Text = string.Empty;
                txtPassword.Text = string.Empty;
                txtName.Text = string.Empty;
                txtSearch.Text = string.Empty;
            }
        }

        private void MainWindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var model = this.DataContext as UserViewModel;
            if(model != null )
            {
               // model.StopTokenGeneration();
            }
        }
    }
}
