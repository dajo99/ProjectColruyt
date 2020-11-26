using Project_Colruyt_WPF.Usercontrols;
using Project_Colruyt_WPF.Views;
using ProjectColruyt_MODELS.UserControlHelp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Project_Colruyt_WPF.ViewModels
{
   public class MainViewModel : BasisViewModel
   {
        private string _windowTitle;
        private UserControl _control;

        private string _logoutVisibility;

        private string _backVisibility;

        public string BackVisibility
        {
            get { return _backVisibility; }
            set { _backVisibility = value; }
        }


        public string LogoutVisibility
        {
            get { return _logoutVisibility; }
            set { 
                _logoutVisibility = value; 
                NotifyPropertyChanged();
            }
        }


        public string WindowTitle
        {
            get {return _windowTitle; }
            set {
                _windowTitle = value;
                NotifyPropertyChanged();
            }
        }

        public UserControl Control
        {
            get
            {
                return _control;
            }
            set
            {
                _control = value;

                NotifyPropertyChanged();
            }
        }


        public MainViewModel()
        {

            ControlSwitch.UscEvent += SwitchControl;


        }

        
        public void SwitchControl(UserControl usc, string title)
        {
            Control = usc;
            WindowTitle = title;
        }

        public override string this[string columnName] => throw new NotImplementedException();
        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public void Back()
        {
            ///code voor terug te gaan naar een vorige view
            
        }
        public void LogOut()
        {
            ///uitlog code
        }
        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Back":
                    Back();
                    break;
                case "LogOut":
                    LogOut();
                    break;
                
            }
        }

    }

    
}
