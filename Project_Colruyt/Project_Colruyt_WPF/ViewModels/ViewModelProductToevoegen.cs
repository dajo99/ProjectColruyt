using OEFDBFIRST_WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Colruyt_WPF.ViewModels
{
    public class ViewModelProductToevoegen : BasisViewModel
    {
        private ObservableCollection<string> _gekendeLijst;

        private ObservableCollection<string> _comboboxType;

        private ObservableCollection<string> _inOnsLijstje;

        private string _nieuwItem;

        private string _type;

        private string _selectedComboboxType;
        public string NieuwItem {

            get
            {
                return _nieuwItem;
            }

            set
            {
                _nieuwItem = value;
                NotifyPropertyChanged();
            }
        }

        public string Type
        {
            get
            {
                return _type;
            }

            set
            {
                _type = value;
                NotifyPropertyChanged();
            }
        }

        public string SelectedComboboxType
        {
            get
            {
                return _selectedComboboxType;
            }
            set
            {
                _selectedComboboxType = value;
                VulLijst();
                NotifyPropertyChanged();
            }
        }
        public ObservableCollection<string> GekendeLijst
        {
            get
            {
                return _gekendeLijst;
            }
            set
            {
                _gekendeLijst = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<string> ComboBoxType
        {
            get
            {
                return _comboboxType;
            }
            set
            {
                _comboboxType = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<string> InOnsLijstje
        {
            get
            {
                return _inOnsLijstje;
            }
            set
            {
                _inOnsLijstje = value;
                NotifyPropertyChanged();
            }
        }
        public void VulLijst()
        {
            ///code voor het opvullen van het lijstje met gekende producten
            ///aan de hand van het geselecteerde combobox item

        }

        public void ToevoegenAanWinkellijst()
        {
            ///code voor het toevoegen van een item aan onze winkellijst
        }
        public void OpenWinkellijst()
        {
            ///code voor terug te gaan naar het overzicht van onze lijst
        }
        public override string this [string columnName] => throw new NotImplementedException();

        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Toevoegen":
                    return true;
                case "OverzichtLijst":
                    return true;
            }
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Toevoegen":
                    ToevoegenAanWinkellijst();
                    break;
                case "OverzichtLijst":
                    OpenWinkellijst();
                    break;

            }
        }

    }
}
