using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Project_Colruyt_WPF.ViewModels
{
    public class TestViewModel : BasisViewModel
    {
        static MongoClient client = new MongoClient("mongodb+srv://dbdajo:vandoninck@cluster0.zvqn2.gcp.mongodb.net/Colruyt?retryWrites=true&w=majority");
        static IMongoDatabase database = client.GetDatabase("Colruyt");
        IMongoCollection<TestUserDocument> collection = database.GetCollection<TestUserDocument>("testuser");

        private TestUserDocument _userRecord;
        private string _foutmelding;

        private ObservableCollection<TestUserDocument> _users;




        private TestUserDocument _geselecteerdeUser;
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

        public string Foutmelding
        {
            get { return _foutmelding; }
            set { _foutmelding = value; NotifyPropertyChanged(); }
        }


        public ObservableCollection<TestUserDocument> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                NotifyPropertyChanged();
            }
        }






        public TestUserDocument GeselecteerdeUser
        {
            get { return _geselecteerdeUser; }
            set
            {
                _geselecteerdeUser = value;
                UserRecordInstellen();
                NotifyPropertyChanged();

            }
        }

        public TestUserDocument UserRecord
        {
            get { return _userRecord; }
            set
            {
                _userRecord = value;
                NotifyPropertyChanged();

            }
        }
        public TestViewModel()
        {
            List<TestUserDocument> resultList = collection.AsQueryable().ToList<TestUserDocument>();
            // Bind result data to WPF view.
            if (resultList.Count() > 0)
            {
                Users = new ObservableCollection<TestUserDocument>(resultList);

            }

            UserRecord = new TestUserDocument();
        }

        public void ReadAllDocuments()
        {
            List<TestUserDocument> resultList = collection.AsQueryable().ToList<TestUserDocument>();
            Users = new ObservableCollection<TestUserDocument>(resultList);
            Wissen();
        }

        public override string this[string columnName]
        {
            get
            {


                return "";
            }
        }


        public void Toevoegen()
        {





            
            

                TestUserDocument user = new TestUserDocument();
                user.username = UserRecord.username;
                user.password = UserRecord.password;
                collection.InsertOne(user);

                ReadAllDocuments();
                

            






        }

        public void Aanpassen()
        {
            if (GeselecteerdeUser != null)
            {
                
                
                    

                    
                    var updateUser = Builders<TestUserDocument>.Update.Set("username", GeselecteerdeUser.username).Set("password", GeselecteerdeUser);
                    collection.UpdateOne(x => x.Id == GeselecteerdeUser.Id, updateUser);
                    ReadAllDocuments();
                


            }
            else
            {
                Foutmelding = "Eerst een user selecteren!";
            }


        }


        public void Verwijder()
        {

            if (GeselecteerdeUser != null)
            {
                
                collection.DeleteOne(x => x.Id == GeselecteerdeUser.Id);
                ReadAllDocuments();
            }
            else
            {
                Foutmelding = "Eerst Werknemer selecteren!";
            }

        }


        private void UserRecordInstellen()
        {
            if (GeselecteerdeUser != null)
            {
                UserRecord = GeselecteerdeUser;
            }
            else
            {
                UserRecord = new TestUserDocument();
            }
        }

        public void Wissen()
        {
            GeselecteerdeUser = null;
            UserRecordInstellen();
            Foutmelding = "";
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            //Via parameter kom je te weten op welke knop er gedrukt is,  
            //instelling via CommandParameter in xaml
            switch (parameter.ToString())
            {
                case "Verwijderen": Verwijder(); break;
                case "Toevoegen": Toevoegen(); break;
                case "Aanpassen": Aanpassen(); break;
                case "Annuleren": Wissen(); break;
            }
        }
    }
}
