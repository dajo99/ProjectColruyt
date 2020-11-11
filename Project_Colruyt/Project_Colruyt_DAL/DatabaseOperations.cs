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
 
        public class TestUserDocument
        {
            [BsonId]
            public ObjectId Id { get; set; }

            [BsonElement("username")]
            public string username { get; set; }

            [BsonElement("password")]
            public string password { get; set; }

            /*public TestUserDocument(string username, string password)
            {
                this.username = username;
                this.password = password;
            }*/
        }




        public static string Connectionstring = "mongodb+srv://dbdajo:vandoninck@cluster0.zvqn2.gcp.mongodb.net/Colruyt?retryWrites=true&w=majority";
        
        public static IMongoCollection<TestUserDocument> GetUsers()
        { 

            MongoClient client = new MongoClient(Connectionstring);

            IMongoDatabase database = client.GetDatabase("Colruyt");
            IMongoCollection<TestUserDocument> collection = database.GetCollection<TestUserDocument>("testuser"); ;

            //Environment.Exit(1);

            return collection;
        }

    }
   
}
