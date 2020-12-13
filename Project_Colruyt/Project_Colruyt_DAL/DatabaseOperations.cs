using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using Project_Colruyt_DAL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Colruyt_DAL
{
    public static class DatabaseOperations
    {

        public static string Connectionstring = "mongodb+srv://dbdajo:vandoninck@cluster0.zvqn2.gcp.mongodb.net/Colruyt?retryWrites=true&w=majority";
        public static MongoClient client = new MongoClient(Connectionstring);
        public static IMongoCollection<Gebruiker> GetUsers()
        {

            IMongoDatabase database = client.GetDatabase("Colruyt");
            IMongoCollection<Gebruiker> collection = database.GetCollection<Gebruiker>("Users");

            //Environment.Exit(1);

            return collection;
        }

        public static IMongoCollection<Product> GetProducts()
        {

            IMongoDatabase database = client.GetDatabase("Colruyt");
            IMongoCollection<Product> collection = database.GetCollection<Product>("Products");

            //Environment.Exit(1);

            return collection;
        }

        public static IMongoCollection<GebruikerLijst> LolGetListByObjectId()
        {

            IMongoDatabase database = client.GetDatabase("Colruyt");
            IMongoCollection<GebruikerLijst> collection = database.GetCollection<GebruikerLijst>("Userlists");


            return collection;

        }
        
        public static ObservableCollection<GebruikerLijst> GetListByUserId(BsonObjectId id)
        {
             ObservableCollection<GebruikerLijst> lijst = new ObservableCollection<GebruikerLijst>();
            IMongoDatabase database = client.GetDatabase("Colruyt");
            IMongoCollection<Gebruiker> collection = database.GetCollection<Gebruiker>("Users");
            Gebruiker gebruiker = collection.Find(x => x.Id == id).FirstOrDefault();
            var list = database.GetCollection<GebruikerLijst>("Userlists");
            foreach (var item in gebruiker.lists)
            {
                GebruikerLijst gbl = new GebruikerLijst();
                if (item.IsObjectId)
                {
                    gbl = list.Find(x => x.Id == item.AsObjectId).SingleOrDefault();
                }
                if (!lijst.Contains(gbl))
                {
                    lijst.Add(gbl);
                }
                
            }
            //Environment.Exit(1);
            return lijst;

        }


        public static GebruikerLijst GetListByObjectId(BsonObjectId id)
        {

            IMongoDatabase database = client.GetDatabase("Colruyt");
            var collection = database.GetCollection<GebruikerLijst>("Userlists");
            GebruikerLijst gebruikerLijst = collection.Find(x => x.Id == id).FirstOrDefault();

            return gebruikerLijst;

        }

        public static Product GetProductPriceById(BsonObjectId id)
        {

            IMongoDatabase database = client.GetDatabase("Colruyt");
            var collection = database.GetCollection<Product>("Products");
            Product product = collection.Find(x => x.ProductID == id).SingleOrDefault();
            return product;

        }

        public static ProductAantal GetProductAantaltById(BsonObjectId id)
        {

            IMongoDatabase database = client.GetDatabase("Colruyt");
            var collection = database.GetCollection<ProductAantal>("ProductQuantitys");
            ProductAantal productQuantity = collection.Find(x => x.Id == id).SingleOrDefault();
            return productQuantity;

        }
        public static Product GetProductNameById(BsonObjectId id)
        {
            IMongoDatabase database = client.GetDatabase("Colruyt");
            var collection = database.GetCollection<Product>("Products");
            Product product = collection.Find(x => x.ProductID == id.AsObjectId).SingleOrDefault();
            return product;
        }
        public static IMongoCollection<Location> GetLocations()
        {

            IMongoDatabase database = client.GetDatabase("Colruyt");
            IMongoCollection<Location> collection = database.GetCollection<Location>("Locations");

            //Environment.Exit(1);

            return collection;
        }

        public static Gebruiker GetUserByEmail(string email)
        {

            IMongoDatabase database = client.GetDatabase("Colruyt");
            IMongoCollection<Gebruiker> collection = database.GetCollection<Gebruiker>("Users");
            Gebruiker gebruiker = collection.Find(x => x.email == email).FirstOrDefault();

            //Environment.Exit(1);

            return gebruiker;
        }

        public static bool ProductToevoegen(Product product)
        {
            try
            {
                IMongoDatabase database = client.GetDatabase("Colruyt");
                IMongoCollection<Product> collection = database.GetCollection<Product>("Products");
                collection.InsertOne(product);
                return true;
            }
            catch (Exception ex)
            {
                FileOperations.Foutloggen(ex);
                return false;
            }

        }

        public static bool LijstToevoegen(GebruikerLijst gebruikerLijst, Gebruiker gebruiker)
        {
            try
            {

                IMongoDatabase database = client.GetDatabase("Colruyt");
                IMongoCollection<Gebruiker> gebruikers = database.GetCollection<Gebruiker>("Users");
                IMongoCollection<GebruikerLijst> collection = database.GetCollection<GebruikerLijst>("Userlists");
                collection.InsertOne(gebruikerLijst);


                var filter = Builders<Gebruiker>.Filter.Eq("_id", gebruiker.Id);

                var update = Builders<Gebruiker>.Update
                    .Push<BsonObjectId>(e => e.lists, gebruikerLijst.Id);

                gebruikers.FindOneAndUpdate(filter, update);
                return true;
            }
            catch (Exception ex)
            {
                FileOperations.Foutloggen(ex);
                return false;
            }

        }
        public static bool LijstUpdaten(GebruikerLijst gebruikerLijst)
        {
            try
            {

                IMongoDatabase database = client.GetDatabase("Colruyt");
                IMongoCollection<GebruikerLijst> collection = database.GetCollection<GebruikerLijst>("Userlists");

                var filter = Builders<GebruikerLijst>.Filter.Eq("_id", gebruikerLijst.Id);

                collection.FindOneAndReplaceAsync(filter, gebruikerLijst);
                return true;
            }
            catch (Exception ex)
            {
                FileOperations.Foutloggen(ex);
                return false;
            }

        }

        public static bool ProductAantalToevoegen(ProductAantal product)
        {
            try
            {
                IMongoDatabase database = client.GetDatabase("Colruyt");
                IMongoCollection<ProductAantal> collection = database.GetCollection<ProductAantal>("ProductQuantitys");
                collection.InsertOne(product);
                return true;
            }
            catch (Exception ex)
            {

                FileOperations.Foutloggen(ex);
                return false;
            }
        }

        public static bool LijstVerwijderen(GebruikerLijst gebruikerLijst, Gebruiker gebruiker)
        {
            try
            {

                IMongoDatabase database = client.GetDatabase("Colruyt");
                IMongoCollection<Gebruiker> gebruikers = database.GetCollection<Gebruiker>("Users");
                IMongoCollection<GebruikerLijst> collection = database.GetCollection<GebruikerLijst>("Userlists");
                var filterDelete = Builders<GebruikerLijst>.Filter.Eq("_id", gebruikerLijst.Id);
                collection.DeleteOne(filterDelete);


                var filter = Builders<Gebruiker>.Filter.Eq("_id", gebruiker.Id);

                var update = Builders<Gebruiker>.Update
                    .Pull<BsonObjectId>(e => e.lists, gebruikerLijst.Id);

                gebruikers.FindOneAndUpdate(filter, update);

                return true;
            }
            catch (Exception ex)
            {

                FileOperations.Foutloggen(ex);
                return false;
            }

        }

        public static GebruikerLijst VerwijderProductUitGebruikerslijst(BsonObjectId gebruikerslijstId, BsonObjectId ProductAantalId)
        {
            try
            {
                IMongoDatabase database = client.GetDatabase("Colruyt");
                IMongoCollection<ProductAantal> productAantalLijsten = database.GetCollection<ProductAantal>("ProductQuantitys");
                IMongoCollection<GebruikerLijst> gebruikersLijsten = database.GetCollection<GebruikerLijst>("Userlists");


                var filterGerbruikersLijst = Builders<GebruikerLijst>.Filter.Eq("_id", gebruikerslijstId);
                var update = Builders<GebruikerLijst>.Update.Pull<BsonObjectId>(e => e.Producten, ProductAantalId);

                var document = gebruikersLijsten.FindOneAndUpdate(filterGerbruikersLijst, update);

                var filterProductAantal = Builders<ProductAantal>.Filter.Eq("_id", ProductAantalId);
                productAantalLijsten.DeleteOne(filterProductAantal);


                return document;
            }
            catch (Exception ex)
            {
                FileOperations.Foutloggen(ex);
                return null;
            }
            
        }


    }
}


