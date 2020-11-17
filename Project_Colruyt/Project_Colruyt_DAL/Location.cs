using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Colruyt_DAL
{
    public class Locations
    {
        [BsonId]
        public ObjectId Id { get; set; }


        [BsonElement("Category")]
        public string Category { get; set; }
    }
}
