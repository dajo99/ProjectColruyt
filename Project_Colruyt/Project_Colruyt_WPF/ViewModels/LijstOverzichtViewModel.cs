using MongoDB.Driver;
using Project_Colruyt_DAL;
using Project_Colruyt_DAL.Partials;
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

        IMongoCollection<Userlist> collection = DatabaseOperations.GetUserlists();

        public DateTime Date { get; set; }
        private string _foutmelding;
        private ObservableCollection<Userlist> _userlists;
        private Userlist _geselecteerdeUserlist;
        private Userlist _userlistRecord;


        public string Foutmelding
        {
            get { return _foutmelding; }
            set { _foutmelding = value; NotifyPropertyChanged(); }
        }

        public ObservableCollection<Userlist> Userlists
        {
            get { return _userlists; }
            set
            {
                _userlists = value;
                NotifyPropertyChanged();
            }
        }

        public Userlist GeselecteerdeUserlist
        {
            get { return _geselecteerdeUserlist; }
            set
            {
                _geselecteerdeUserlist = value;
                UserRecordInstellen();
                NotifyPropertyChanged();

            }
        }

        public Userlist UserlistRecord
        {
            get { return _userlistRecord; }
            set
            {
                _userlistRecord = value;
                NotifyPropertyChanged();

            }
        }

        public LijstOverzichtViewModel()
        {
            List<Userlist> resultList = collection.AsQueryable().ToList<Userlist>();
            // Bind result data to WPF view.
            if (resultList.Count() > 0)
            {
                Userlists = new ObservableCollection<Userlist>(resultList);

            }

            UserlistRecord = new Userlist();
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
        private void UserRecordInstellen()
        {
            if (GeselecteerdeUserlist != null)
            {
                UserlistRecord = GeselecteerdeUserlist;
            }
            else
            {
                UserlistRecord = new Userlist();
            }
        }

        public void Wissen()
        {
            GeselecteerdeUserlist = null;
            UserRecordInstellen();
            Foutmelding = "";
        }
    }
}
