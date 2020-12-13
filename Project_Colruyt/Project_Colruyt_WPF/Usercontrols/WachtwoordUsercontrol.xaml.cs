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
    /// Interaction logic for WachtwoordUsercontrol.xaml
    /// </summary>
    public partial class WachtwoordUsercontrol : UserControl
    {


       

        // Using a DependencyProperty as the backing store for Wachtwoord.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WachtwoordProperty =
            DependencyProperty.Register("Wachtwoord", typeof(string), typeof(WachtwoordUsercontrol), new PropertyMetadata(string.Empty));

        public string Wachtwoord
        {
            get { return (string)GetValue(WachtwoordProperty); }
            set { SetValue(WachtwoordProperty, value); }
        }

        public WachtwoordUsercontrol()
        {
            InitializeComponent();
        }

        private void PBWachtwoord_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Wachtwoord = PBWachtwoord.Password;
        }
    }
}
