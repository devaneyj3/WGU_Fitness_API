using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using System;
using Npgsql;
using Microsoft.Maui.ApplicationModel.Communication;
using DotNetEnv;
using System.Reflection;

namespace Fit_Fitness_Client.Services
{
	public class DatabaseConnection
	{
        public static NpgsqlConnection OpenConnection(string connectionString)
        {
            var connection = new NpgsqlConnection(connectionString);

            connection.Open();
            return connection;
        }

        public static bool ExecuteQuery(string query, NpgsqlConnection connection, List<NpgsqlParameter> parameters = null
            )
        {
            try
            {
                //Execute the query
                using (var command = new NpgsqlCommand(query, connection))
                {
                    // Add parameters if they are provided
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }
        public static string LoadENV()
        {
            string connectionString = null;
            try
            {
                // Load .env file as an embedded resource
                var assembly = Assembly.GetExecutingAssembly();
                using (Stream stream = assembly.GetManifestResourceStream("Fit_Fitness_Client.env"))
                {
                    
                    DotNetEnv.Env.Load(stream);

                }


                connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");


                if (string.IsNullOrEmpty(connectionString))
                {
                    Console.WriteLine("DB_CONNECTION_STRING not found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return connectionString;
        }
    }
}
