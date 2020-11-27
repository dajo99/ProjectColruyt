using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Colruyt_DAL.Models
{
    public class ProductAantal
    {
        [BsonId]
        public BsonObjectId Id { get; set; }

        [BsonElement("Product")]
        public BsonValue Product { get; set; }

        [BsonElement("Quantity")]
        public BsonInt32 Quantity { get; set; }
        
        public double? TotalPrice { get; set; }
    }
}
