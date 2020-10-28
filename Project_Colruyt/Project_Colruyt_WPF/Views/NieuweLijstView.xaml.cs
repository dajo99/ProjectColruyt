using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Project_Colruyt_WPF.Views
{
    /// <summary>
    /// Interaction logic for NieuweLijstView.xaml
    /// </summary>
    public partial class NieuweLijstView : Window
    {
        public NieuweLijstView()
        {
            InitializeComponent();
        }

        List<Product> producten;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //LVproducten.ItemsSource = datagridvullen();
        }

        public List<Product> datagridvullen()
        {
            producten = new List<Product>();
            producten.Add(new Product { Naam = "banaan", Prijs = "€2.30", Aantal = 6 });
            producten.Add(new Product { Naam = "head & shoulders shampoo", Prijs = "€3.20", Aantal = 2 });
            producten.Add(new Product { Naam = "Coca-cola 6 pack", Prijs = "€0.70", Aantal = 1 });
            producten.Add(new Product { Naam = "Rum", Prijs = "€18.30", Aantal = 6 });

            return producten;
        }

    }

    public class Product
    {
        private string _prijs;

        public string Prijs
        {
            get { return _prijs; }
            set { _prijs = value; }
        }

        private string _naam;

        public string Naam
        {
            get { return _naam; }
            set { _naam = value; }
        }

        private int _aantal;

        public int Aantal
        {
            get { return _aantal; }
            set { _aantal = value; }
        }




    }
}
