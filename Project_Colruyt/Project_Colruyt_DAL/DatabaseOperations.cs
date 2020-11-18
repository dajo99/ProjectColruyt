using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
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
            public ObjectId Id { get; set; }

            [BsonElement("Email")]
            public string email { get; set; }

            [BsonElement("Password")]
            public string password { get; set; }

            [BsonElement("Lists")]
            public string[] lists { get; set; }

            /*public TestUserDocument(string username, string password)
            {
                this.username = username;
                this.password = password;
            }*/
        }




        public static string Connectionstring = "mongodb+srv://dbdajo:vandoninck@cluster0.zvqn2.gcp.mongodb.net/Colruyt?retryWrites=true&w=majority";

        public static IMongoCollection<Gebruikers> GetUsers()
        {

            MongoClient client = new MongoClient(Connectionstring);

            IMongoDatabase database = client.GetDatabase("Colruyt");
            IMongoCollection<Gebruikers> collection = database.GetCollection<Gebruikers>("Users"); ;

            //Environment.Exit(1);

            return collection;
        }

        public static IMongoCollection<Product> GetProducts()
        {

            MongoClient client = new MongoClient(Connectionstring);

            IMongoDatabase database = client.GetDatabase("Colruyt");
            IMongoCollection<Product> collection = database.GetCollection<Product>("Products"); ;

            //Environment.Exit(1);

            return collection;
        }

        public static IMongoCollection<Location> GetLocations()
        {

            MongoClient client = new MongoClient(Connectionstring);

            IMongoDatabase database = client.GetDatabase("Colruyt");
            IMongoCollection<Location> collection = database.GetCollection<Location>("Locations"); ;

            //Environment.Exit(1);

            return collection;
        }



    }

}
