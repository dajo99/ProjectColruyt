using Project_Colruyt_WPF.Usercontrols;
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
            ///Code usercontroles en de context van mainview te vernieuwen
            MainView view = (MainView)Application.Current.MainWindow;
            MainViewModel mainModel = new MainViewModel();
            mainModel.WindowTitle = "Producten toevoegen";
            view.DataContext = mainModel;
            view.GridMain.Children.Clear();
            NieuwProduct_usercontrol usc = new NieuwProduct_usercontrol();
            //viewmodel aanmaken voor het toevoegen van producten en de datacontext instellen
              view.GridMain.Children.Add(usc);
            
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
                case "ProductToevoegen":
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
                case "ProductToevoegen":
                    OpenToevoegen();
                    break;
                case "Verwijderen":
                    Verwijderen();
                    break;
                    
            }
        }
    }
}
