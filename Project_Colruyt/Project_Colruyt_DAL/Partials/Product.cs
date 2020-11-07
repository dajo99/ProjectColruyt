using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Colruyt_DAL.Partials
{
    public class Product
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("Price")]
        public Double Price { get; set; }

        [BsonElement("Location")]
        public Location LocationId { get; set; }

}
}
