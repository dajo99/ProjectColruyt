using MongoDB.Driver;
using Project_Colruyt_DAL.Partials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Colruyt_DAL
{
    public static class DatabaseOperations
    {
        public static MongoClient client = new MongoClient("mongodb+srv://dbdajo:vandoninck@cluster0.zvqn2.gcp.mongodb.net/Colruyt?retryWrites=true&w=majority");
        public static IMongoDatabase database = client.GetDatabase("Colruyt");
        



        public static List<Userlist> OphalenUserlists()
        {
            IMongoCollection<Userlist> collection = database.GetCollection<Userlist>("testuser");
            return collection.AsQueryable().ToList<Userlist>();
        }





    }
}
