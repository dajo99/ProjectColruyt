using MongoDB.Bson;
using Project_Colruyt_DAL;
using Project_Colruyt_DAL.Models;
using Project_Colruyt_WPF.Views;
using ProjectColruyt_MODELS;
using ProjectColruyt_MODELS.UserControlHelp;
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

        private ObservableCollection<ProductAantal> _producten;
        public  GebruikerLijst _lijstje;
        private string _naam;

        private double _totalPrice;

        public double TotalPrice
        {
            get
            {
                return _totalPrice;
            }
            set
            {
                _totalPrice = value;
                NotifyPropertyChanged();
            }
        }
        public string Naam
        {
            get
            { return _naam; }
            set
            {
                _naam = value;
                NotifyPropertyChanged();
            }
        }
        //Properties
        public GebruikerLijst Lijstje
        {
            get { return _lijstje; }
            set { 
                _lijstje = value;
                NotifyPropertyChanged();
            }
        }


        public ObservableCollection<ProductAantal> Producten
        {
            get 
            { 
                return _producten; 
            }
            set
            {
                _producten = value;
                NotifyPropertyChanged();
            }
        }


        public ViewModelNieuweWinkelLijst()
        {
            Producten = new ObservableCollection<ProductAantal>();
            Lijstje = new GebruikerLijst();

        }

        public ViewModelNieuweWinkelLijst(BsonObjectId id)
        {
            Producten = new ObservableCollection<ProductAantal>();
            Lijstje = GetListByObjectId(id);
            Naam = (string)Lijstje.Lijstnaam;
            foreach (var productQuantity in Lijstje.Producten)
            {
                Producten.Add(GetProductAantaltById(productQuantity.AsObjectId));
            }


            foreach (var product in Producten)
            {
                Product item = new Product();

                item = GetProductPriceById(product.Product.ProductID);
                product.Product = GetProductNameById(product.Product.ProductID);

                TotalPrice = (double)item.Price * product.Quantity;

            }

        }

        ///Komende sprints hieraan werken
        public override string this[string columnName] => throw new NotImplementedException();

        public void Opslagen()
        {
            if (Lijstje.Id == null)
            {
                ///enkel nog product toevoegen hierin regelen
                Lijstje.Id = new BsonObjectId(ObjectId.GenerateNewId());
                Lijstje.Datum = DateTime.Now;
                Lijstje.Lijstnaam = Naam;
                bool check = LijstToevoegen(Lijstje, GebruikerStatic.Gebruiker);
                if (check)
                {
                    MessageBox.Show("succes!");
                }
            }
            else
            {
                Lijstje.Lijstnaam = Naam;
                Lijstje.Datum = DateTime.Now;
                LijstUpdaten(Lijstje);
            }
        }

        public void Openen()
        {
            Usercontrols.NieuwProduct_usercontrol usc = new Usercontrols.NieuwProduct_usercontrol();
            usc.DataContext = new NieuwProductViewModel();
            GebruikerStatic.Lijst = Lijstje;
            ControlSwitch.InvokeSwitch(usc, "Product toevoegen");
        }
        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Opslagen":
                    return true;
                

                case "Verwijderen":
                    if (Lijstje.Id != null)
                    {
                        return true;
                    }
                    return false;
                    
                    
            }
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Opslagen":
                    Opslagen();

                    break;
                
                case "ProductToevoegen":
                    Openen();
                    break;
                    
            }
        }
    }
}
