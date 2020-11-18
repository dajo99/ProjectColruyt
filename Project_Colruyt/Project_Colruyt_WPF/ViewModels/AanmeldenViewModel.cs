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
    class AanmeldenViewModel: BasisViewModel
    {
        IMongoCollection<Gebruikers> collection = DatabaseOperations.GetUsers();

        private string _email;
        private string _wachtwoord;

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

       
        public void Authenticeer()
        {
            
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
