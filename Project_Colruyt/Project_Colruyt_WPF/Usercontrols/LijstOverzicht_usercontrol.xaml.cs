using Project_Colruyt_WPF.ViewModels;
using Project_Colruyt_WPF.Views;
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

namespace Project_Colruyt_WPF.Usercontrols
{
    /// <summary>
    /// Interaction logic for LijstOverzicht_usercontrol.xaml
    /// </summary>
    public partial class LijstOverzicht_usercontrol : UserControl
    {
        public LijstOverzicht_usercontrol()
        {
            InitializeComponent();
        }

        private void LVOverzichtLijsten_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TestView testView = new TestView();
            TestViewModel testViewModel = new TestViewModel();
            testView.DataContext = testViewModel;
            testView.Show();
        }
    }
}
