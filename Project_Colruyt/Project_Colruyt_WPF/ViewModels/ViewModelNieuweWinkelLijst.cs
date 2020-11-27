using MongoDB.Bson;
using Project_Colruyt_WPF.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static Project_Colruyt_DAL.DatabaseOperations;

namespace Project_Colruyt_WPF.ViewModels
{
    public class ViewModelNieuweWinkelLijst : BasisViewModel
    {

        private GebruikerLijst _selectItem;
        public  GebruikerLijst _lijstje;

        //Properties
        public GebruikerLijst Lijstje
        {
            get { return _lijstje; }
            set { 
                _lijstje = value;
                NotifyPropertyChanged();
            }
        }



        public ViewModelNieuweWinkelLijst()
        {
            Lijstje = new GebruikerLijst();
        }

        public ViewModelNieuweWinkelLijst(BsonObjectId id)
        {
            Lijstje = GetListByObjectId(id);
        }

        ///Komende sprints hieraan werken
        public override string this[string columnName] => throw new NotImplementedException();



        public void OpenToevoegen()
        {
            ///Code usercontroles en de context van mainview te vernieuwen
            MainView view = (MainView)Application.Current.MainWindow;
            MainViewModel mainModel = new MainViewModel();
            mainModel.WindowTitle = "Producten toevoegen";
            //view.DataContext = mainModel;
            //view.GridMain.Children.Clear();

            //user control voor nieuwe lijst initialiseren en datacontext instellen
            /*voorbeeld
              UsercontrolToevoegen usc = new UsercontrolToevoegen();
              ViewModelToevoegen vm = new ViewModelToevoegen();
              usc.datacontext = vm;
              view.GridMain.Children.Add(usc);
            */
        }

        public void Verwijderen()
        {
            ///Code die een item uit het huidige lijstje verwijdert. kan nog meer in komen te staan
           
        }
        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Toevoegen":
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
                case "Verwijderen":
                    Verwijderen();
                    break;
                    
            }
        }
    }
}
