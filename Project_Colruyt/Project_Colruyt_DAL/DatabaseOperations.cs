using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
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

        public class Gebruikers
        {
            [BsonId]
            public BsonObjectId Id { get; set; }

            [BsonElement("Email")]
            public BsonString email { get; set; }

            [BsonElement("Password")]
            public BsonString password { get; set; }

            [BsonElement("Lists")]
            public BsonValue[] lists { get; set; }

            /*public TestUserDocument(string username, string password)
            {
                this.username = username;
                this.password = password;
            }*/
        }

        public class GebruikerLijst
        {
            [BsonId]
            public BsonObjectId Id { get; set; }

            [BsonElement("Name")]
            public BsonString Lijstnaam { get; set; }

            [BsonElement("Date")]
            public BsonDateTime Datum { get; set; }

            [BsonElement("Products")]
            public BsonValue[] Producten { get; set; }

            /*public TestUserDocument(string username, string password)
            {
                this.username = username;
                this.password = password;
            }*/
            public override string ToString()
            {
                
                return Datum.ToString() + Lijstnaam.ToString();
            }
        }



        // CONNECTIONSTRING TOEVOEGEN VOOR HET STARTEN VAN DATABASEOPERATIONS (connectionstring.txt)!!! 


        public static string Connectionstring = "mongodb+srv://dbdajo:vandoninck@cluster0.zvqn2.gcp.mongodb.net/Colruyt?retryWrites=true&w=majority";
        public static MongoClient client = new MongoClient(Connectionstring);
        public static IMongoCollection<Gebruikers> GetUsers()
        {


            IMongoDatabase database = client.GetDatabase("Colruyt");
            IMongoCollection<Gebruikers> collection = database.GetCollection<Gebruikers>("Users"); 

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
        public static ObservableCollection<GebruikerLijst> lijst = new ObservableCollection<GebruikerLijst>();
        public static ObservableCollection<GebruikerLijst> GetListByUserId(BsonObjectId id)
        {

            IMongoDatabase database = client.GetDatabase("Colruyt");
            IMongoCollection<Gebruikers> collection = database.GetCollection<Gebruikers>("Users");
            Gebruikers gebruiker = collection.Find(x => x.Id == id).FirstOrDefault();
            var list = database.GetCollection<GebruikerLijst>("Userlists");
            foreach (var item in gebruiker.lists)
            {
                GebruikerLijst gbl = new GebruikerLijst();
                if (item.IsObjectId)
                {
                    gbl = list.Find(x => x.Id == item.AsObjectId).SingleOrDefault();
                }
                lijst.Add(gbl);
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

        public static IMongoCollection<Location> GetLocations()
        {

            IMongoDatabase database = client.GetDatabase("Colruyt");
            IMongoCollection<Location> collection = database.GetCollection<Location>("Locations"); 

            //Environment.Exit(1);

            return collection;
        }

        public static Gebruikers GetUserByEmail(string email)
        {

            IMongoDatabase database = client.GetDatabase("Colruyt");
            IMongoCollection<Gebruikers> collection = database.GetCollection<Gebruikers>("Users");
            Gebruikers gebruiker =  collection.Find(x => x.email == email).FirstOrDefault();

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
            catch(Exception ex)
            {
                FileOperations.Foutloggen(ex);
                return false;
            }
           
        }

    }

}
