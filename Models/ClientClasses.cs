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


        public static void MakeClientClassesTable()
        {
            {
                string createTableQuery = @"
                 CREATE TABLE client_classes (
                    client_id INT REFERENCES clients(id),
                    class_id INT REFERENCES fitness_classes(id),
                    PRIMARY KEY (client_id, class_id)
                );";
                DatabaseServices.ExecuteNonQuery(createTableQuery);
            }
        }
        #region Get Client Classes
        public static List<FitnessClass> GetClientClasses()
        {
            List<FitnessClass> list = new List<FitnessClass>();
            using (var connection = DatabaseConnection.OpenConnection(DatabaseConnection.connectionString))
            {
                string query = "";


                query = $"SELECT * FROM fitness_classes JOIN client_classes ON fitness_classes.id = client_classes.class_id JOIN instructors ON fitness_classes.instructor_id = instructors.id WHERE client_classes.client_id = @client_id";


                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@client_id", Client.SignedInClientId);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            FitnessClass fitnessClass = new FitnessClass(reader.GetInt32(reader.GetOrdinal("Id")), reader.GetString(reader.GetOrdinal("name")), reader.GetString(reader.GetOrdinal("location")), reader.GetString(reader.GetOrdinal("details")), reader.GetString(reader.GetOrdinal("instructorname")), reader.GetString(reader.GetOrdinal("instructoremail")), reader.GetString(reader.GetOrdinal("instructorphone")), reader.GetDateTime(reader.GetOrdinal("start_time")), reader.GetDateTime(reader.GetOrdinal("end_time")), reader.GetInt32(reader.GetOrdinal("capacity")), reader.GetInt32(reader.GetOrdinal("enrollment")),
                      reader.GetInt32(reader.GetOrdinal("instructor_id"))
                    );

                            list.Add(fitnessClass);
                        }
                    }
                }

            }
            return list;
        }
        #endregion

        #region Check if enrolled
        public static bool IsEnrolled(int fitnessClassId)
        {
            using (var connection = DatabaseConnection.OpenConnection(DatabaseConnection.connectionString))
            {
                string query = "SELECT COUNT(*) FROM client_classes WHERE class_id = @class_id AND client_id = @client_id";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@class_id", fitnessClassId);
                    command.Parameters.AddWithValue("@client_id", Client.SignedInClientId);

                    int count = Convert.ToInt32(command.ExecuteScalar());

                    return count > 0;
                }
            }
        }

        #endregion
    }
}

