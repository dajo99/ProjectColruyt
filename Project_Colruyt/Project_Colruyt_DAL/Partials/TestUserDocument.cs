using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Project_Colruyt_DAL.BasisModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Colruyt_DAL.Partials
{
    public class TestUserDocument
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("username")]
        public string username { get; set; }

        [BsonElement("password")]
        public string password { get; set; }

        /*public TestUserDocument(string username, string password)
        {
            this.username = username;
            this.password = password;
        }*/
    }
}
