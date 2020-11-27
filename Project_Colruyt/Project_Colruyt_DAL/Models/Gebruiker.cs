using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Colruyt_DAL.Models
{
    public class Gebruiker
    {
        [BsonId]
        public BsonObjectId Id { get; set; }

        [BsonElement("Email")]
        public BsonString email { get; set; }

        [BsonElement("Password")]
        public BsonString password { get; set; }

        [BsonElement("Lists")]
        public BsonObjectId[] lists { get; set; }

        /*public TestUserDocument(string username, string password)
        {
            this.username = username;
            this.password = password;
        }*/
    }
}
