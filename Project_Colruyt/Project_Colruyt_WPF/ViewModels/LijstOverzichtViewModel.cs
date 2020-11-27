﻿using MongoDB.Driver;
using ProjectColruyt_MODELS;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Colruyt_WPF.Usercontrols;
using static Project_Colruyt_DAL.DatabaseOperations;
using ProjectColruyt_MODELS.UserControlHelp;

namespace Project_Colruyt_WPF.ViewModels
{
    public class LijstOverzichtViewModel: BasisViewModel
    {
        private ObservableCollection<GebruikerLijst> _lijst;

        private GebruikerLijst _selectItem;
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

        public GebruikerLijst SelectItem
        {
            get { return _selectItem; }
            set
            {
                _selectItem = value;
                OpenLijstje();    
                NotifyPropertyChanged();
            }
        }


        public void OpenLijstje()
        {
            NieuweLijst_usercontrol usc = new NieuweLijst_usercontrol();
            ViewModelNieuweWinkelLijst viewModel;
            if (_selectItem != null)
            {
                viewModel = new ViewModelNieuweWinkelLijst(_selectItem.Id);
            }
            viewModel = new ViewModelNieuweWinkelLijst();
            usc.DataContext = viewModel;
            ControlSwitch.InvokeSwitch(usc, "Winkellijst");
        }

        public override string this[string columnName] => throw new NotImplementedException();

        public LijstOverzichtViewModel()
        {
            Lijst = new ObservableCollection<GebruikerLijst>(GetListByUserId(GebruikerStatic.Gebruiker.Id));
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            if (parameter.ToString() == "VoegToe")
            {
                _selectItem = null;
                OpenLijstje();
            }
        }
    }
}
