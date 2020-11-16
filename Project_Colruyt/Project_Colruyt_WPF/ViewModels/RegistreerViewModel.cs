using MongoDB.Driver;
using Project_Colruyt_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
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
          public void Toevoegen()
        {
            if (this.IsGeldig())
            {
                Gebruikers user = new Gebruikers();
                user.email = Email;
                user.lists = new string[] { };
                user.password = Wachtwoord;
                collection.InsertOne(user);
            }
        }
        public override string this [string columnName] {
            get
            {
                if (Email != null && columnName == "Email" && !Email.Contains("@"))
                {
                    return "Vul een correct email adress in";
                }
                else if (Wachtwoord != null && columnName == "Wachtwoord" && Wachtwoord.Length < 8) 
                {
                    return "Vul een correct wachtwoord in van minimum 8 karakters";
                }
                else if(Herhaal != null && columnName == "Herhaal" && Herhaal != Wachtwoord)
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
