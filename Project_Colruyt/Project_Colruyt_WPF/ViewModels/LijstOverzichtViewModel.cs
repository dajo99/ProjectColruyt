using MongoDB.Driver;
using Project_Colruyt_DAL.Models;
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
                NotifyPropertyChanged();
            }
        }
        public void Verwijder()
        {
            if (SelectItem != null)
            {
                GebruikerLijst lijst = GetListByObjectId(SelectItem.Id);
                bool check = LijstVerwijderen(lijst, GebruikerStatic.Gebruiker);
                if (check)
                {
                    
                    
                    List<GebruikerLijst> gebruikerLijst = new List<GebruikerLijst>();
                    for (int i = 0; i <= GebruikerStatic.Gebruiker.lists.Count()-1; i++)
                    {
                        List<GebruikerLijst>forlooplijst = LolGetListByObjectId().AsQueryable().Where(x => x.Id == GebruikerStatic.Gebruiker.lists[i]).ToList<GebruikerLijst>();
                        gebruikerLijst.AddRange(forlooplijst);
                        
                    }
                   
                    

                    Lijst = new ObservableCollection<GebruikerLijst>(gebruikerLijst);

                }
                
            }
           
        }


        public void VoegNieuweLijstToe()
        {
            UserControlStatic.PreviousUsercontrol = new LijstOverzicht_usercontrol();

            NieuweLijst_usercontrol usc = new NieuweLijst_usercontrol();
            ViewModelNieuweWinkelLijst viewModel = new ViewModelNieuweWinkelLijst();

            usc.DataContext = viewModel;

            ControlSwitch.ChangeNavbuttonsVisibility("Collapsed", "logout");
            ControlSwitch.ChangeNavbuttonsVisibility("Visible", "back");
            ControlSwitch.InvokeSwitch(usc, "Winkellijst");
        }

        public void OpenLijstje()
        {
            UserControlStatic.PreviousUsercontrol = new LijstOverzicht_usercontrol();

            NieuweLijst_usercontrol usc = new NieuweLijst_usercontrol();
            ViewModelNieuweWinkelLijst viewModel;
            if (_selectItem != null)
            {
                viewModel = new ViewModelNieuweWinkelLijst(_selectItem.Id);
                usc.DataContext = viewModel;
            }
               

            ControlSwitch.ChangeNavbuttonsVisibility("Collapsed", "logout");
            ControlSwitch.ChangeNavbuttonsVisibility("Visible", "back");
            ControlSwitch.InvokeSwitch(usc, "Winkellijst");
            
        }

        public override string this[string columnName] => throw new NotImplementedException();

        public LijstOverzichtViewModel()
        {
            Lijst = new ObservableCollection<GebruikerLijst>(GetListByUserId(GebruikerStatic.Gebruiker.Id));
        }

        public override bool CanExecute(object parameter)
        {
            if (parameter.ToString() == "Verwijder")
            {
                if (Lijst.Count == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public override void Execute(object parameter)
        {
            if (parameter.ToString() == "VoegToe")
            {
                VoegNieuweLijstToe();
            }
            if (parameter.ToString() == "Verwijder")
            {
                Verwijder();
            }
            if (parameter.ToString() == "Open")
            {
                OpenLijstje();
            }
        }
    }
}
