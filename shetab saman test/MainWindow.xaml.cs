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

namespace shetab_saman_test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ClickButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            if (button != null )
            {
                ResultBox.Visibility = Visibility.Visible;
                ResultBox.Text = InputBox.Text.ToString();
            }
            else
            {
                throw new Exception();
            }
        }

        
    }
}
