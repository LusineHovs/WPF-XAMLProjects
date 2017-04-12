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

namespace WPF_BindingElementToElement
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

        private void SetSmall(object sender, RoutedEventArgs e)
        {
            lblSampleText.FontSize = 2;
        }

        private void SetNormal(object sender, RoutedEventArgs e)
        {
            lblSampleText.FontSize = this.FontSize;
        }

        private void SetLarge(object sender, RoutedEventArgs e)
        {
            lblSampleText.FontSize = 40;
        }
    }
}
