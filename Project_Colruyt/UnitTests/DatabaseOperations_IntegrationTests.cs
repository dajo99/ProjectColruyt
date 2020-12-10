using FakeItEasy;
using MongoDB.Bson;
using MongoDB.Driver;
using NUnit.Framework;
using Project_Colruyt_DAL;
using Project_Colruyt_DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests
{
    [TestFixture]
    public class DatabaseOperations_IntegrationTests
    {
        
        [Test]
        public void OphalenProducten_ReturnsAlleProducten()
        {
            //Arrange
            IMongoCollection<Product> producten;

            //Act
            producten = DatabaseOperations.GetProducts();


            //Assert
            Assert.NotNull(producten);
            Assert.IsInstanceOf<IMongoCollection<Product>>(producten);
        }


        [Test]
        public void OphalenGebruikers_ReturnsAlleGebruikers()
        {
            //Arrange
            IMongoCollection<Gebruiker> gebruikers;

            //Act
            gebruikers = DatabaseOperations.GetUsers();


            //Assert
            Assert.NotNull(gebruikers);
            Assert.IsInstanceOf<IMongoCollection<Gebruiker>>(gebruikers);

        }

    }

            


}

