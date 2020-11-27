using MongoDB.Driver;
using Project_Colruyt_DAL.Models;
using ProjectColruyt_MODELS;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Project_Colruyt_DAL.DatabaseOperations;

namespace Project_Colruyt_WPF.ViewModels
{
    public class LijstOverzichtViewModel: BasisViewModel
    {
        private ObservableCollection<GebruikerLijst> _lijst;
        public ObservableCollection<GebruikerLijst> Lijst 
        { 
            get 
            { return _lijst; } 
            set 
            {
                _lijst = value;
                NotifyPropertyChanged();
            } 
        }

        public override string this[string columnName] => throw new NotImplementedException();

        public LijstOverzichtViewModel()
        {
            Lijst = new ObservableCollection<GebruikerLijst>(GetListByUserId(GebruikerStatic.Gebruiker.Id));
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
