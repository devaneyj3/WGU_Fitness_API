using System;
using Fit_Fitness_Client.Services;
using Npgsql;

namespace Fit_Fitness_Client.Models
{
    public class ClientClasses
    {
        public static int Id { get; set; }
        public static int class_id { get; set; }
        public static int client_id { get; set; }

        public static void GetClientClasses()
        {
            var apiUrl = $"{Client.clientURL}/{Client.SignedInClientId}/fitness_classes";
            try
            {
                var fitnessClassListResponse = DatabaseServices.GetData<object, FitnessClass>(apiUrl);

                // change label text based on class list count
                if (fitnessClassListResponse != null)
                {
                    Client.clientFitnessClassesList = fitnessClassListResponse.Data;
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());
            }
        }
    }
}

