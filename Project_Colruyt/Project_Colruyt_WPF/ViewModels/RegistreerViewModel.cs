using MongoDB.Bson;
using MongoDB.Driver;
using Project_Colruyt_DAL;
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
    public class RegistreerViewModel : BasisViewModel
    {

        IMongoCollection<Gebruikers> collection = DatabaseOperations.GetUsers();
        private string _email;
        private string _wachtwoord;
        private string _herhaal;

        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = value;
                NotifyPropertyChanged();
            }
        }
        public string Wachtwoord
        {
            get
            {
                return _wachtwoord;
            }
            set
            {
                _wachtwoord = value;
                NotifyPropertyChanged();
            }
        }

        public string Herhaal
        {
            get
            {
                return _herhaal;
            }
            set
            {
                _herhaal = value;
                NotifyPropertyChanged();
            }
        }

        
        public static string EncryptString(string encr)
        {
            //array van bytes (tussen 0 en 255) opvullen met een code van chars in bytes
            byte[] bytes = UTF8Encoding.UTF8.GetBytes(encr);
            //provider gebruiken om met het SHA256 algoritme te werken
            using (SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider())
            {
                //Converteert de invoerreeks naar een bytearray  + Berekent de hash-waarde
                byte[] keys = sha256.ComputeHash(UTF8Encoding.UTF8.GetBytes("892C8E496E1E33355E858B327B@C238A939B7601E96159F9E9CAD05@19BA5055CD"));
                //Met behulp van cryptografisch interface, symmetrische encryptie mogelijk maken
                using (AesCryptoServiceProvider cryptor = new AesCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.ISO10126 })
                {
                    //Een symmetrisch encryptor object aanmaken 
                    ICryptoTransform transform = cryptor.CreateEncryptor();
                    //Transformeren van het opgegeven gebied van de opgegeven bytearray.
                    byte[] results = transform.TransformFinalBlock(bytes, 0, bytes.Length);
                    //Teruggeven van een 64 bit string
                    return Convert.ToBase64String(results, 0, results.Length);
                }
            }
        }
        public void Toevoegen()
        {
            if (this.IsGeldig())
            {
                Gebruikers user = new Gebruikers();
                user.email = Email;
                user.lists = new BsonValue[] { };
                user.password = EncryptString(Wachtwoord);
                collection.InsertOne(user);
                GebruikerStatic.Gebruiker = user;
                
                Usercontrols.LijstOverzicht_usercontrol usc = new Usercontrols.LijstOverzicht_usercontrol();
                usc.DataContext = new LijstOverzichtViewModel();
                ControlSwitch.InvokeSwitch(usc, "Winkellijsten");
            }
        }
        public override string this [string columnName] {
            get
            {
                try
                {
                    
                    var lijst = this.GetType().GetProperties().ToList();
                    for (int i = 0; i <= this.GetType().GetProperties().Length - 1; i++)
                    {
                     
                        if (lijst[i].Name == columnName && lijst[i].GetValue(this, null) == null || (string)lijst[i].GetValue(this, null) == "")
                        {
                            return "* Verplicht veld";
                        }
                    }
                }

                catch (Exception ex)
                {
                    Foutlogger.FoutLoggen(ex);
                }

                if (Email != null && columnName == "Email" && !Email.Contains("@"))
                {
                    return "Vul een correct email adress in";
                }
                else if (Wachtwoord != null && columnName == "Wachtwoord" && Wachtwoord.Length < 4)
                {
                    return "Vul een correct wachtwoord in van minimum 4 karakters";
                }
                else if (Herhaal != null && columnName == "Herhaal" && Herhaal != Wachtwoord)
                {
                    return "Zorg ervoor dat beide wachtwoorden overeen komen";
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
            if (parameter.ToString() == "Registreer")
            {
                Toevoegen();
            }
        }
    }
}
