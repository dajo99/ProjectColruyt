using Project_Colruyt_WPF.Usercontrols;
using Project_Colruyt_WPF.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Project_Colruyt_WPF.ViewModels
{
    public class LijstOverzichtViewModel : BasisViewModel
    {
        MainView view = (MainView)Application.Current.MainWindow;

        private ObservableCollection<string> _lijst;
        public DateTime Datum { get; set; }
        public string Lijstnaam { get; set; }
        public ObservableCollection<string> Lijst
        { 
            get 
            {
                return _lijst;
            }

            set 
            {
                _lijst= value;
                NotifyPropertyChanged();
            } 
        }

        public LijstOverzichtViewModel()
        {
            /////Lijst = (de methode gebruikt om lijsten op te halen uit mongoDB
            //if (Lijst.Count > 0)
            //{
            //    foreach (var item in Lijst)
            //    {
            //        //Datum = item.Datum;
            //        //Lijstnaam = item.Naam;
            //    }
            //}
        }

        public void LijstToevoegen()
        {
            ViewModelNieuweWinkelLijst viewModel = new ViewModelNieuweWinkelLijst();
            NieuweLijst_usercontrol usc = new NieuweLijst_usercontrol();
            usc.DataContext = viewModel;
            view.GridMain.Children.Clear();
            view.GridMain.Children.Add(usc);
        }

        public void LijstVerwijderen()
        {
            //code voor lijst weg te smijten
        }
        public override string this[string columnName] => throw new NotImplementedException();

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Toevoegen":
                    LijstToevoegen();
                    break;
                case "Verwijderen":
                    LijstVerwijderen();
                    break;
            }
        }
    }
}
