using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Colruyt_DAL.Partials
{
    public class Location
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("category")]
        public string Category { get; set; }
    }
}
