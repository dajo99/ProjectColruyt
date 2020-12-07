using MongoDB.Bson;
using MongoDB.Driver;
using Project_Colruyt_DAL;
using Project_Colruyt_DAL.Models;
using Project_Colruyt_WPF.Usercontrols;
using ProjectColruyt_MODELS;
using ProjectColruyt_MODELS.UserControlHelp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Project_Colruyt_WPF.ViewModels
{
    public class NieuwProductViewModel: BasisViewModel
    {
        private Product _productRecord;
        private string _foutmelding;
        ProductAantal resultaat = new ProductAantal();

        IMongoCollection<Product> collectionProducts = DatabaseOperations.GetProducts();
        IMongoCollection<Location> collectionLocations = DatabaseOperations.GetLocations();


        private ViewModelNieuweWinkelLijst vm { get; set; }

        private ObservableCollection<Location> _locations;

        private ObservableCollection<ProductAantal> _products;
        


        private Location _geselecteerdeLocation;
        private Location _nieuwLocation;
        private ProductAantal _geselecteerdeProductAantal;
       
        private string _quantity;



        public string Foutmelding
        {
            get { return _foutmelding; }
            set { _foutmelding = value; NotifyPropertyChanged(); }
        }


        public ObservableCollection<ProductAantal> Products
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

        public Location NieuwLocation
        {
            get { return _nieuwLocation; }
            set
            {
                _nieuwLocation = value;
                
            }
        }

        public ProductAantal GeselecteerdeProductAantal
        {
            get { return _geselecteerdeProductAantal; }
            set
            {
                _geselecteerdeProductAantal = value;
                NotifyPropertyChanged();
                
                
            }
        }

        public string Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
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
        public NieuwProductViewModel(ViewModelNieuweWinkelLijst vm)
        {
            this.vm = vm;
            List<Location> locationList = collectionLocations.AsQueryable().ToList<Location>();
            List<Product> productList = collectionProducts.AsQueryable().ToList<Product>();
            Update(productList);
            if (locationList.Count()>0)
            {
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


        public void Update(List<Product> productList)
        {
            List<ProductAantal> productAantalList = new List<ProductAantal>();
            for (int i = 0; i < productList.Count; i++)
            {
                ProductAantal nieuw = new ProductAantal();
                nieuw.Product = productList[i];
                nieuw.Quantity = 0;

                productAantalList.Add(nieuw);
            }
            // Bind result data to WPF view.
            if (productAantalList.Count() > 0)
            {
                Products = new ObservableCollection<ProductAantal>(productAantalList);

            }
        }
        


       
        public void Zoeken()
        {
            if (GeselecteerdeLocation != null)
            {
                List<Product> productList = new List<Product>();
                if (GeselecteerdeLocation.Category == "Alles")
                {
                    productList = collectionProducts.AsQueryable().ToList<Product>();
                }
                else
                {
                    productList = DatabaseOperations.GetProducts().AsQueryable().Where(x => x.LocationID == GeselecteerdeLocation.LocationID).ToList();
                }
                
                Update(productList);
            }
            
        }

        public void Toevoegen()
        {
            Product product = new Product();
            product.Name = ProductRecord.Name;
            product.Price = 0.00;
            product.LocationID = NieuwLocation.LocationID;

            bool resultaat = DatabaseOperations.ProductToevoegen(product);

            if (resultaat == true)
            {
                List<Product> productList = collectionProducts.AsQueryable().ToList<Product>();
                Update(productList);
                MessageBox.Show($"{product.Name} is toegevoegd!");
            }
            else
            {
                MessageBox.Show("Fout bij toevoegen!");
            }


        }

        public void AanwinkellijstToevoegen()
        {
            

            if (GeselecteerdeProductAantal != null && GeselecteerdeProductAantal.Quantity != 0)
            {
                bool resultaat = false;
                    resultaat = DatabaseOperations.ProductAantalToevoegen(GeselecteerdeProductAantal);
                    
                if (resultaat == true)
                {
                    MessageBox.Show($"{GeselecteerdeProductAantal.Product.Name} is toegevoegd aan productaantal!");
                    NieuweLijst_usercontrol usc = new NieuweLijst_usercontrol();
                    vm.Lijstje.Producten.Add((ObjectId)GeselecteerdeProductAantal.Id);
                    List<Location> locationList = collectionLocations.AsQueryable().ToList<Location>();
                    Locations = new ObservableCollection<Location>(locationList);
                    List<Product> productList = collectionProducts.AsQueryable().ToList<Product>();
                    Update(productList);


                    vm.Instellen();
                    usc.DataContext = vm;
                    ControlSwitch.InvokeSwitch(usc, "Winkellijstje");
                }
                else
                {
                    MessageBox.Show("Error: Fout bij toevoegen!");
                }
            }
            else
            {
                MessageBox.Show("Error: Niks geselecteerd of het aantal is 0.!");
            }
        }
    

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
                case "Toevoegen": Toevoegen(); break;
                case "AanwinkellijstToevoegen": AanwinkellijstToevoegen() ; break;
                
            }
        }
    }
}
