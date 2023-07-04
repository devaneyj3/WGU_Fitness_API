
namespace Fit_Fitness_Client.Models
{
    public class Client
    {
        public static List<FitnessClass> clientFitnessClassesList = new List<FitnessClass>();
        public static int SignedInClientId = 0;
        public static string SignedInClientName = "";
        public static string SignedInClientEmail = "";
        public static string SignedInClientPhone = "";

        public static string clientURL = $"{DatabaseConnection.ConnectionURL}clients";


        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public Client()
        {

        }

        public Client(int id, string name, string email, string phone, string username, string password)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.phone = phone;
            this.username = username;
            this.password = password; //Encrypt before production

        }
    }
}

