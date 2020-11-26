using Project_Colruyt_DAL;
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

            //Usercontrols.NieuwProduct_usercontrol usc = new Usercontrols.NieuwProduct_usercontrol();
            //usc.DataContext = new NieuwProductViewModel();

            Usercontrols.Aanmelden_usercontrol usc = new Usercontrols.Aanmelden_usercontrol();
            usc.DataContext = new AanmeldenViewModel();

            viewmodel.WindowTitle = "Welkom";
            viewmodel.LogoutVisibility = "Hidden";
            viewmodel.BackVisibility = "Hidden";

            //Usercontrols.RegistrerenUsercontrol usc = new Usercontrols.RegistrerenUsercontrol();
            //usc.DataContext = new RegistreerViewModel();
            viewmodel.Control = usc;
            view.DataContext = viewmodel;
            view.Show();

         }
    }
}
