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
        public static string Connectionstring = "mongodb+srv://dbdajo:vandoninck@cluster0.zvqn2.gcp.mongodb.net/Colruyt?retryWrites=true&w=majority";

        public static IMongoCollection<Userlist> GetUserlists()
        {

            MongoClient client = new MongoClient(Connectionstring);

            IMongoDatabase database = client.GetDatabase("Colruyt");
            IMongoCollection<Userlist> collection = database.GetCollection<Userlist>("Userlists"); ;

            //Environment.Exit(1);

            return collection;
        }


    }
}
