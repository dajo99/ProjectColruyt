using MongoDB.Driver;
using Project_Colruyt_DAL;
using Project_Colruyt_WPF.Views;
using ProjectColruyt_MODELS;
using ProjectColruyt_MODELS.UserControlHelp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Project_Colruyt_DAL.DatabaseOperations;

namespace Project_Colruyt_WPF.ViewModels
{
    class AanmeldenViewModel: BasisViewModel
    {
        IMongoCollection<Gebruikers> collection = DatabaseOperations.GetUsers();

        private string _email;
        private string _wachtwoord;
        private string _melding;

        public string Melding
        {
            get { return _melding; }
            set { 
                _melding = value;
                NotifyPropertyChanged();
            }
        }


        public string Email
        {
            get { return _email; }
            set {
                _email = value;
                NotifyPropertyChanged();
            }
        }
        public string Wachtwoord
        {
            get { return _wachtwoord; }
            set {
                _wachtwoord = value;
                NotifyPropertyChanged();
            }
        }

        public delegate void SwitchUsercontrolEvent(string title); 
        public event SwitchUsercontrolEvent setViewTitle;
        
        public AanmeldenViewModel()
        {
            setViewTitle?.Invoke("Aanmelden");
        }

        Gebruikers gebruiker;
        public void Authenticeer()
        {
            gebruiker = DatabaseOperations.GetUserByEmail(Email);

            if (gebruiker == null)
            {
                Melding = "Een gebruiker met dit emailadres bestaat niet!";
            }
            else if (gebruiker.password != Wachtwoord)
            {
                Melding = "Fout wachtwoord!";
            }
            else
            {
                GebruikerStatic.Gebruiker = gebruiker;
                Usercontrols.LijstOverzicht_usercontrol usc = new Usercontrols.LijstOverzicht_usercontrol();
                usc.DataContext = new LijstOverzichtViewModel();
                ControlSwitch.InvokeSwitch(usc, "Winkellijsten");
            }

        }

        

        public override string this[string columnName]
        {
            get
            {
                if (columnName == "Email" && string.IsNullOrWhiteSpace(Email))
                {
                    return "Vul een geldig emailadres in!";
                }
                else if (columnName == "Wachtwoord" && string.IsNullOrWhiteSpace(Email))
                {
                    return "Vul een wachtwoord in om aan te melden!";
                }

                return "";
            }
        }




        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Aanmelden": Authenticeer(); break;
            }
        }
    }
}
