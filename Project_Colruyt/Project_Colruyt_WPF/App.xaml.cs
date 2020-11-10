using Project_Colruyt_WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Threading.Tasks;
using System.Windows;

namespace Project_Colruyt_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
         private void Application_Startup(object sender, StartupEventArgs e)
         {
            MainViewModel viewmodel = new MainViewModel();
            Views.MainView view = new Views.MainView();
            view.DataContext = viewmodel;
<<<<<<< Updated upstream
=======
            LijstOverzicht_usercontrol usc = new LijstOverzicht_usercontrol();
            LijstOverzichtViewModel lijstOverzichtVm = new LijstOverzichtViewModel();
            usc.DataContext = lijstOverzichtVm;
            view.GridMain.Children.Add(usc);
>>>>>>> Stashed changes
            view.Show();

         }

    }
}
