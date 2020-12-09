using MongoDB.Bson;
using MongoDB.Driver;
using Project_Colruyt_DAL;
using Project_Colruyt_DAL.Models;
using Project_Colruyt_WPF.Views;
using ProjectColruyt_MODELS;
using ProjectColruyt_MODELS.UserControlHelp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Project_Colruyt_DAL.DatabaseOperations;

namespace Project_Colruyt_WPF.ViewModels
{
    public class AanmeldenViewModel: BasisViewModel
    {
        //IMongoCollection<Gebruiker> collection = DatabaseOperations.GetUsers();

        private string _email;
        private string _wachtwoord;
        private string _wachtwoordMelding;
        private string _emailMelding;

        public string EmailMelding
        {
            get { return _emailMelding; }
            set { 
                _emailMelding = value;
                NotifyPropertyChanged();
            }
        }


        public string WachtwoordMelding
        {
            get { return _wachtwoordMelding; }
            set {
                _wachtwoordMelding = value;
                NotifyPropertyChanged();
            }
        }

        public string Email
        {
            get { return _email; }
            set {
                _email = value;
                NotifyPropertyChanged();
                EmailMelding = string.Empty;
            }
        }

        public string Wachtwoord
        {
            get { return _wachtwoord; }
            set {
                _wachtwoord = value;
                NotifyPropertyChanged();
                WachtwoordMelding = string.Empty;
            }
        }


        Gebruiker gebruiker;

        public void Authenticeer()
        {
            if (this["Email"] != string.Empty)
            {
                EmailMelding = "Vul een emailadres in";
                return;
            }
            else
            {
                gebruiker = DatabaseOperations.GetUserByEmail(Email);

                if (gebruiker == null)
                {

                    EmailMelding = "Een account met dit emailadres bestaat niet";
                    return;
                }
                
            }
            

            if (this["Wachtwoord"] != string.Empty)
            {
                WachtwoordMelding = "Foutief wachtwoord";
            }
            else
            {
                GebruikerStatic.Gebruiker = gebruiker;
               
                Usercontrols.LijstOverzicht_usercontrol usc = new Usercontrols.LijstOverzicht_usercontrol();
                usc.DataContext = new LijstOverzichtViewModel();
                ControlSwitch.InvokeSwitch(usc, "Winkellijsten");
                ControlSwitch.ChangeNavbuttonsVisibility("Visible","logout");

            }

        }

        public string DecodePassword(string wachtwoord)
        {


            byte[] data = Convert.FromBase64String(wachtwoord);
            using (SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider())
            {
                byte[] keys = sha256.ComputeHash(UTF8Encoding.UTF8.GetBytes("892C8E496E1E33355E858B327B@C238A939B7601E96159F9E9CAD05@19BA5055CD"));
                using (AesCryptoServiceProvider tripdes = new AesCryptoServiceProvider { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.ISO10126 })
                {
                    ICryptoTransform transform = tripdes.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    
                    return UTF8Encoding.UTF8.GetString(results);
                }
            }

        }

        public void OpenRegistreren()
        {
            UserControlStatic.PreviousUsercontrol = new Usercontrols.Aanmelden_usercontrol();

            Usercontrols.RegistrerenUsercontrol usc = new Usercontrols.RegistrerenUsercontrol();
            usc.DataContext = new RegistreerViewModel();
            ControlSwitch.InvokeSwitch(usc, "Registreren");
            ControlSwitch.ChangeNavbuttonsVisibility("Visible", "back");
        }


        public override string this[string columnName]
        {
            get
            {
                if (columnName == "Email" && string.IsNullOrWhiteSpace(Email))
                {
                    return "Vul een geldig emailadres in!";
                    
                }
                else if (columnName == "Wachtwoord" && string.IsNullOrWhiteSpace(Wachtwoord))
                {
                    return "Vul een wachtwoord in om aan te melden!";

                }else if (columnName == "Wachtwoord" && Wachtwoord != DecodePassword(gebruiker.password.ToString()))
                {
                    return "Foutief wachtwoord";
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
                case "Registreer": OpenRegistreren();  break;
            }
        }
    }
}
