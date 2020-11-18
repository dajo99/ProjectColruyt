using MongoDB.Driver;
using Project_Colruyt_DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Project_Colruyt_WPF.ViewModels
{
    public class NieuwProductViewModel: BasisViewModel
    {
        private Product _productRecord;
        private string _foutmelding;


        IMongoCollection<Product> collectionProducts = DatabaseOperations.GetProducts();
        IMongoCollection<Location> collectionLocations = DatabaseOperations.GetLocations();




        private ObservableCollection<Location> _locations;

        private ObservableCollection<Product> _products;
        


        private Location _geselecteerdeLocation;
        private Product _geselecteerdeProduct;


        public string Foutmelding
        {
            get { return _foutmelding; }
            set { _foutmelding = value; NotifyPropertyChanged(); }
        }


        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<Location> Locations
        {
            get { return _locations; }
            set
            {
                _locations = value;
                NotifyPropertyChanged();
            }
        }


        public Location GeselecteerdeLocation
        {
            get { return _geselecteerdeLocation; }
            set
            {
                _geselecteerdeLocation = value;
                Zoeken();
            }
        }

        public Product GeselecteerdeWerknemer
        {
            get { return _geselecteerdeProduct; }
            set
            {
                _geselecteerdeProduct = value;
                NotifyPropertyChanged();

            }
        }

        public Product ProductRecord
        {
            get { return _productRecord; }
            set
            {
                _productRecord = value;
                NotifyPropertyChanged();

            }
        }
        public NieuwProductViewModel()
        {
            List<Location> locationList = collectionLocations.AsQueryable().ToList<Location>();
            List<Product> productList = collectionProducts.AsQueryable().ToList<Product>();
            // Bind result data to WPF view.
            if (productList.Count() > 0)
            {
                Products = new ObservableCollection<Product>(productList);
                Locations = new ObservableCollection<Location>(locationList);

            }

            ProductRecord = new Product();

        }

        public override string this[string columnName]
        {
            get
            {


                return "";
            }
        }






       
        private void Zoeken()
        {
            if (GeselecteerdeLocation != null)
            {
                List<Product> lijstproducts = DatabaseOperations.GetProducts().AsQueryable().Where(x => x.LocationID == GeselecteerdeLocation.LocationID).ToList();
                Products = new ObservableCollection<Product>(lijstproducts);
            }
            
        }

        //public void Toevoegen()
        //{

        //    if (GeselecteerdeUitgever != null)
        //    {
        //        WerknemerRecord.pub_id = GeselecteerdeUitgever.pub_id;
        //        WerknemerRecord.hire_date = DateTime.Now;

        //        if (WerknemerRecord.IsGeldig())
        //        {
        //            int ok = DatabaseOperations.ToevoegenWerknemer(WerknemerRecord);
        //            if (ok > 0)
        //            {
        //                Werknemers = new ObservableCollection<Employee>(DatabaseOperations.OphalenWerknemersViaUitgeverID(GeselecteerdeUitgever.pub_id));
        //                Wissen();
        //            }
        //            else
        //            {
        //                Foutmelding = "Werknemer is niet toegevoegd!";
        //            }
        //        }


        //    }



        //}

        

        /*
        public void Verwijder()
        {

            if (GeselecteerdeWerknemer != null)
            {
                int ok = DatabaseOperations.VerwijderenWerknemer(GeselecteerdeWerknemer);
                if (ok > 0)
                {
                    Werknemers = new ObservableCollection<Employee>(DatabaseOperations.OphalenWerknemersViaUitgeverID(GeselecteerdeUitgever.pub_id));
                    Wissen();
                }
                else
                {
                    Foutmelding = "Werknemer is niet verwijderd!";
                }
            }
            else
            {
                Foutmelding = "Eerst Werknemer selecteren!";
            }

        }


        private void WerknemerRecordInstellen()
        {
            if (GeselecteerdeWerknemer != null)
            {
                WerknemerRecord = GeselecteerdeWerknemer;
            }
            else
            {
                WerknemerRecord = new Employee();
            }
        }

        public void Wissen()
        {
            GeselecteerdeWerknemer = null;
            WerknemerRecordInstellen();
            Foutmelding = "";
        }*/

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            //Via parameter kom je te weten op welke knop er gedrukt is,  
            //instelling via CommandParameter in xaml
            switch (parameter.ToString())
            {
                case "Toevoegen": /*Toevoegen();*/ break;
                
            }
        }
    }
}
