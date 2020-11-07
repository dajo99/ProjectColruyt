using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Colruyt_DAL.Partials
{
    public class Userlist
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("ListName")]
        public string Name { get; set; }

        [BsonElement("Date")]
        public DateTime Date { get; set; }

        [BsonElement("Products")]
        public List<Product> Products { get; set; }
    }
}
