using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Colruyt_DAL
{
    public class Location
    {
        [BsonId]
        public ObjectId LocationID { get; set; }


        [BsonElement("Category")]
        public string Category { get; set; }
    }
}
