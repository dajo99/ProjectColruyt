using MongoDB.Bson;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using Project_Colruyt_DAL;
using 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E2E_Tests.Views
{
    [TestFixture]
    public class NieuwProductUsercontrolTests
    {
        string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        string WpfAppId = @"C:\Users\alain\Desktop\Colruyt\Project_Colruyt\Project_Colruyt_WPF\bin\Debug\Project_Colruyt_WPF.exe";

        WindowsDriver<WindowsElement> session;

        WindowsElement productnaam, addProduct, resultDatagrid, comboBoxElement;
        [SetUp]
        public void Setup()
        {
            if (session == null)
            {
                var appiumOptions = new AppiumOptions();
                appiumOptions.AddAdditionalCapability("app", WpfAppId);
                session = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appiumOptions);
                comboBoxElement = session.FindElementByName("Afdeling");
                productnaam = session.FindElementByAccessibilityId("Productnaam");

                addProduct = session.FindElementByAccessibilityId("AddProduct");
                

                resultDatagrid = session.FindElementByAccessibilityId("ResultDatagrid");
                

            }
        }


        [Test]
        public void AddProduct()
        {
            // Act
            Product product = new Product();
            comboBoxElement.Click();
            var item = comboBoxElement.FindElementByAccessibilityId("Dranken");
            MessageBox.Show(item.Text);


        }


        [TearDown]
        public void TearDown()
        {
            comboBoxElement.Clear();
            productnaam.Clear();
        }


        [OneTimeTearDown]
        public void CloseSession()
        {
            session.Close();
        }

    }
}
