using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using Npgsql;
using Fit_Fitness_Client.Models;


namespace Fit_Fitness_Client.Services
{
    public class DatabaseServices
    {

        static string connectionString = DatabaseConnection.LoadENV();

        #region create table

        public static bool Create(string query, List<NpgsqlParameter> parameters = null)
        {

            using (var connection = DatabaseConnection.OpenConnection(connectionString))
            {

                // Execute create query
                bool isSuccessfull = DatabaseConnection.ExecuteQuery(query, connection, parameters);
                if (isSuccessfull)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
        #endregion
        #region Get Clients
        public static List<Client> GetClients()
        {
            List<Client> list = new List<Client>();
            using (var connection = DatabaseConnection.OpenConnection(connectionString))
            {
                string query = $"SELECT * FROM clients";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Client client = new Client(reader.GetInt32(reader.GetOrdinal("Id")), reader.GetString(reader.GetOrdinal("name")), reader.GetString(reader.GetOrdinal("email")), reader.GetString(reader.GetOrdinal("phone")), reader.GetString(reader.GetOrdinal("username")), reader.GetString(reader.GetOrdinal("password"))
                            );
                            list.Add(client);
                        }
                    }
                }

            }
            return list;
        }
        #endregion

        #region Get Fitness Classes
        public static List<FitnessClass> GetFitnessClasses(string tableName, string instructorId = null)
        {
            List<FitnessClass> list = new List<FitnessClass>();
            using (var connection = DatabaseConnection.OpenConnection(connectionString))
            {
                string query = "";
                if (!string.IsNullOrEmpty(instructorId))
                {
                    query = $"SELECT * FROM {tableName} WHERE instructor_id = {instructorId}";
                }

                query = $"SELECT * FROM {tableName}";

                using (var command = new NpgsqlCommand(query, connection))
                {
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
        public static bool ReserveClass(string query)
        {


            using (var connection = DatabaseConnection.OpenConnection(connectionString))
            {

                // Execute create query
                bool isSuccessfull = DatabaseConnection.ExecuteQuery(query, connection);
                if (isSuccessfull)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
    }

}
