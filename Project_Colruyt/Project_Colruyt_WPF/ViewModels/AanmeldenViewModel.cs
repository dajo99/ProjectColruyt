using MongoDB.Bson;
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
            string result = DecodePassword(gebruiker.password);

            if (gebruiker == null)
            {
                Melding = "Een gebruiker met dit emailadres bestaat niet!";
            }
            else if (Wachtwoord != result)
            {
                Melding = "Fout wachtwoord!";
            }
            else
            {

                GebruikerStatic.Gebruiker = gebruiker;
               
                Usercontrols.LijstOverzicht_usercontrol usc = new Usercontrols.LijstOverzicht_usercontrol();
                usc.DataContext = new LijstOverzichtViewModel();
                ControlSwitch.InvokeSwitch(usc, "Winkellijsten");
                //ControlSwitch.SwitchVisibility("Visible");
            }

        }

        public string DecodePassword(BsonString encodedData)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encodedData.ToString());
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
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
