using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Colruyt_WPF.ViewModels
{
    public class RegistreerViewModel : BasisViewModel
    {
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

        public override string this [string columnName] {
            get
            {
                if (columnName == "Email")
                {
                    return "Vul een correct email adress in";
                }
                else if (columnName == "Wachtwoord")
                {
                    return "Vul een correct wachtwoord in";
                }
                return "";
            }
              }
  



        public override bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public override void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
