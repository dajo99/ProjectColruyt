
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Colruyt_WPF.Usercontrols;
using ProjectColruyt_MODELS;
using System.Windows.Forms;
using System.Drawing;
using OpenQA.Selenium.Interactions;

namespace E2E
{
    [TestFixture]
    public class NieuwProductUsercontrolTests
    {
        string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        string WpfAppId = @"C:\Users\alain\Desktop\Colruyt\Project_Colruyt\Project_Colruyt_WPF\bin\Debug\Project_Colruyt_WPF.exe";

        WindowsDriver<WindowsElement> session;

        WindowsElement email,wachtwoord,aanmelden;
        [SetUp]
        public void Setup()
        {
            if (session == null)
            {
                var appiumOptions = new AppiumOptions();
                appiumOptions.AddAdditionalCapability("app", WpfAppId);
                session = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appiumOptions);
                
                

                email = session.FindElementByAccessibilityId("Email");
                wachtwoord = session.FindElementByAccessibilityId("Wachtwoord");
                aanmelden = session.FindElementByAccessibilityId("Aanmelden");



            }
        }


        [Test]
        public void Aanmelden()
        {
            // Act

            email.("mitchvr@thomasmore.be");
            wachtwoord.SendKeys("projectcolruyt");
            aanmelden.Click();

            Assert.AreNotEqual(null, GebruikerStatic.Gebruiker);


        }


        [TearDown]
        public void TearDown()
        {
            email.Clear();
            wachtwoord.Clear();
        }


        [OneTimeTearDown]
        public void CloseSession()
        {
            session.Close();
        }

    }

}