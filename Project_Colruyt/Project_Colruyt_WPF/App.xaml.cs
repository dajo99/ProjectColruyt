using Project_Colruyt_WPF.Usercontrols;
using Project_Colruyt_WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

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
            LijstOverzicht_usercontrol usc = new LijstOverzicht_usercontrol();
            view.DataContext = viewmodel;
            view.GridMain.Children.Clear();
            LijstOverzichtViewModel lijstOverzichtVm = new LijstOverzichtViewModel();
            usc.DataContext = lijstOverzichtVm;
            view.GridMain.Children.Add(usc);
            view.Show();

         }
    }
}
