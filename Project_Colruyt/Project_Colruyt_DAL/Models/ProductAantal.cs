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
        public Product Product { get; set; }

        [BsonElement("Quantity")]
        public int Quantity { get; set; }

        public double? TotalPrice { get; set; }

    }
}
