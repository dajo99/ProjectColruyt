using NUnit.Framework;
using Project_Colruyt_WPF.ViewModels;
namespace UnitTests
{
    [TestFixture]
    public class Tests
    {
        RegistreerViewModel registratie = new RegistreerViewModel();
        AanmeldenViewModel aanmelden = new AanmeldenViewModel();
        MainViewModel main = new MainViewModel();

        [Test]
        public void EncryptString_HashedValueNotEqualToValue()
        {
            //arrange
            string wachtwoord = "Ditiseentest1!";

            //act 
           string vergelijk = registratie.EncryptString(wachtwoord);

            //assert
            Assert.AreNotEqual(wachtwoord, vergelijk);
        }
        [Test]
        public void EncryptString_HashedValueNotEqualToNull()
        {
            //arrange
            string wachtwoord = "BlablablaMonster";

            //act
            string vergelijk = registratie.EncryptString(wachtwoord);

            //assert
            Assert.AreNotEqual("", vergelijk);
        }

        [Test]
        public void DecodePassword_DeHashedValueIsEqualToValue()
        {
            //arrange
            string wachtwoord = "PlopRules!";
            string vergelijk = registratie.EncryptString(wachtwoord);
            //act
            string deHashed = aanmelden.DecodePassword(vergelijk);

            //assert

            Assert.AreEqual(wachtwoord,deHashed );
        }
      
    }
}