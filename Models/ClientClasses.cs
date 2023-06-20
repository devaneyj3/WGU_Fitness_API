using System;
using Fit_Fitness_Client.Services;

namespace Fit_Fitness_Client.Models
{
    public class ClientClasses
    {
        public static int Id { get; set; }
        public static int class_id { get; set; }
        public static int client_id { get; set; }


        public static void MakeClientClassesTable()
        {
            {
                string createTableQuery = @"
                 CREATE TABLE client_classes (
                    client_id INT REFERENCES clients(client_id),
                    class_id INT REFERENCES classes(class_id),
                    PRIMARY KEY (client_id, class_id)
                );";
                DatabaseServices.Create(createTableQuery);
            }
        }
    }
}

