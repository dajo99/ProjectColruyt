using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project_Colruyt_WPF.ViewModels
{
    public class ViewModelNieuweWinkelLijst : BasisViewModel
    {

        private string _selectItem;
        public ObservableCollection<string> _lijstje;

        //Properties
        public ObservableCollection<string> Lijstje
        {
            get { return _lijstje; }
            set { 
                _lijstje = value;
                NotifyPropertyChanged();
            }
        }

        public string SelectItem
        {
            get { return _selectItem; }
            set
            {
                _selectItem = value;
                NotifyPropertyChanged();
            }
        }

        public ViewModelNieuweWinkelLijst()
        {

        }

        ///Komende sprints hieraan werken
        public override string this[string columnName] => throw new NotImplementedException();



        public void OpenToevoegen()
        {
            ///Code voor naar de usercontrole van toevoegen te gaan
        }

        public void Annuleren()
        {
            ///Code voor naar de usercontrole van het overzicht met alle lijstjes te gaan en het huidige lijstje ongedaan maakt
        }

        public void Verwijderen()
        {
            ///Code die een item uit het huidige lijstje verwijdert. kan nog meer in komen te staan
            Lijstje.Remove(SelectItem);
        }
        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Toevoegen":
                    return true;
                case "Annuleren":
                    return true;
                case "Verwijderen":
                    return true;
            }
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Toevoegen":
                    OpenToevoegen();
                    break;
                case "Annuleren":
                    Annuleren();
                    break;
                case "Verwijderen":
                    Verwijderen();
                    break;
                    
            }
        }
    }
}
