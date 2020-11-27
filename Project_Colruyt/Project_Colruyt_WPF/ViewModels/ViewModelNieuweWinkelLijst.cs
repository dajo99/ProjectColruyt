using MongoDB.Bson;
using Project_Colruyt_DAL;
using Project_Colruyt_DAL.Models;
using Project_Colruyt_WPF.Views;
using ProjectColruyt_MODELS;
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

            //foreach (var productQuantity in Lijstje.Producten)
            //{
            //    Producten.Add(GetProductAantaltById(productQuantity.AsObjectId));

            //}

            //foreach (var product in Producten)
            //{
            //    Product item = new Product();
            //    item.Price = GetProductPriceById(product.Product.AsObjectId);
            //    product.Product= GetProductNameById(product.Product);

            //    product.TotalPrice = (double)item.Price * (int)product.Quantity;
            //}

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
                case "Verwijderen":
           
                    break;
                    
            }
        }
    }
}
