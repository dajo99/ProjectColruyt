using Project_Colruyt_WPF.Usercontrols;
using Project_Colruyt_WPF.Views;
using ProjectColruyt_MODELS;
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
        private string _saveVisibility;

        public string SaveVisibility
        {
            get { return _saveVisibility; }
            set { 
                _saveVisibility = value;
                NotifyPropertyChanged();
            }
        }


        public string BackVisibility
        {
            get { return _backVisibility; }
            set { 
                _backVisibility = value;
                NotifyPropertyChanged();
            }
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
            ControlSwitch.ButtonVisibilityEvent += ChangeButtonPropertyVisibility;
        }

        
        public void SwitchControl(UserControl usc, string title)
        {
            Control = usc;
            WindowTitle = title;
        }

        public void ChangeButtonPropertyVisibility(string visibility, string buttonProperty)
        {
            switch (buttonProperty.ToLower())
            {
                case "back":
                    BackVisibility = visibility;
                    break;
                case "save":
                    SaveVisibility = visibility;
                    break;
                case "logout":
                    LogoutVisibility = visibility;
                    break;
            }          
        }

        public override string this[string columnName] => throw new NotImplementedException();
        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public void Back()
        {
            var datacontext = new FrameworkElement().DataContext;

            BackVisibility = "Collapsed";

            if (UserControlStatic.PreviousUsercontrol == null)
            {
                UserControlStatic.PreviousUsercontrol = new LijstOverzicht_usercontrol();
            }

            switch (UserControlStatic.PreviousUsercontrol.GetType().Name)
            {
                case "Aanmelden_usercontrol":
                    datacontext = new ViewModels.AanmeldenViewModel();
                    WindowTitle = "Aanmelden";
                    break;
                case "LijstOverzicht_usercontrol":
                    datacontext = new ViewModels.LijstOverzichtViewModel();
                    WindowTitle = "Winkellijsten";
                    LogoutVisibility = "Visible";
                    break;
                case "NieuweLijst_usercontrol":
                    datacontext = new ViewModels.ViewModelNieuweWinkelLijst();
                    WindowTitle = "Winkellijst";
                    BackVisibility = "Visible";
                    break;
            }

            
            Control = UserControlStatic.PreviousUsercontrol;
            Control.DataContext = datacontext;

            UserControlStatic.PreviousUsercontrol = null;
        }

        public void LogOut()
        {
            GebruikerStatic.Gebruiker = null;
            SwitchControl(new Usercontrols.Aanmelden_usercontrol(), "Aanmelden");
        }

        public void Save()
        {


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
                case "Save":
                    Save();
                    break;

            }
        }

    }

    
}
