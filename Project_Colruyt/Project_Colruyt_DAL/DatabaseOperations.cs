using MongoDB.Driver;
using Project_Colruyt_DAL.Partials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Project_Colruyt_DAL
{
    public static class DatabaseOperations
    {
        public static MongoClient client;


        public static IMongoDatabase database;
        

        static DatabaseOperations()
        {
            client = new MongoClient("mongodb+srv://dbdajo:vandoninck@cluster0.zvqn2.gcp.mongodb.net/Colruyt?retryWrites=true&w=majority");
            database = client.GetDatabase("Colruyt");
        }


        public static List<Userlist> OphalenUserlist()
        {
            IMongoCollection<Userlist> collection = database.GetCollection<Userlist>("Userlists");
            List<Userlist>  resultList = collection.AsQueryable().ToList<Userlist>();

            return resultList;
        }


    }
}
