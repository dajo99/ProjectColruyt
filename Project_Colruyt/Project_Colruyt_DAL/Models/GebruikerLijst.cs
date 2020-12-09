using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Colruyt_DAL.Models
{
    public class GebruikerLijst
    {
        [BsonId]
        public BsonObjectId Id { get; set; }

        [BsonElement("Name")]
        public BsonString Lijstnaam { get; set; }

        [BsonElement("Date")]
        public DateTime Datum { get; set; }

        [BsonElement("Products")]
        public List<BsonObjectId>Producten { get; set; }

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
}
