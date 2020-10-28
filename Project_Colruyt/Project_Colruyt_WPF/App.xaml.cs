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
            Views.NieuweLijstView view = new Views.NieuweLijstView();
            view.DataContext = viewmodel;
            view.Show();

        }
    }
}
