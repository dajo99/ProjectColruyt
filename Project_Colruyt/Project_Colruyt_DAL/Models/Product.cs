using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Colruyt_DAL
{
    public class Product
    {
        [BsonId]
        public BsonObjectId ProductID { get; set; }

        [BsonElement("Price")]
        public BsonDouble Price { get; set; }

        [BsonElement("Name")]
        public BsonString Name { get; set; }

        [BsonElement("Location")]
        public ObjectId LocationID { get; set; }

        


    }
}
