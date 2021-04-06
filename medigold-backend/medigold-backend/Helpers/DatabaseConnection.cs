using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using medigold_backend.Models;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace medigold_backend.Helpers
{
    public class DatabaseConnection
    {
        public string ConnectionString { get; set; }

        public DatabaseConnection(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<Patient> GetAllPatients() {

            List<Patient> patients = new List<Patient>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from Patient", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        patients.Add(new Patient()
                        {
                            Id = int.Parse(reader["Id"].ToString()),
                            Name = reader["Name"].ToString(),
                            DoB = DateTime.ParseExact(reader["dob"].ToString(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                            InfectionDate = DateTime.ParseExact(reader["infectionDate"].ToString(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                            OutcomeDate = string.IsNullOrEmpty(reader["outcomeDate"].ToString()) ? DateTime.MinValue.AddHours(1) : DateTime.ParseExact(reader["outcomeDate"].ToString(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                            Status = reader["Status"].ToString(),
                        });
                    }
                }
            }

            return patients;
        }

        public string UpdatePatient (int Id, string updatedName, DateTime? updatedOutcomeDate, string updatedStatus)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE patient SET Name=@updatedName, OutcomeDate=@updatedOutcomeDate, Status=@updatedStatus WHERE Id=@Id", conn);

                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@updatedName", updatedName);
                cmd.Parameters.AddWithValue("@updatedOutcomeDate", updatedOutcomeDate);
                cmd.Parameters.AddWithValue("@updatedStatus", updatedStatus);

                cmd.ExecuteNonQuery();
            }

            return "ok";
        }

        public string InsertPatient (string Name, DateTime DoB, DateTime InfectionDate)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO patient(name, dob, infectionDate, outcomeDate, status) VALUES(@Name, @DoB, @InfectionDate, null, 'Pending');", conn);

                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@DoB", DoB);
                cmd.Parameters.AddWithValue("@InfectionDate", InfectionDate);

                cmd.ExecuteNonQuery();
            }

            return "ok";
        }

        public string DeletePatient (int Id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM patient WHERE Id=@Id", conn);

                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.ExecuteNonQuery();
            }

            return "ok";
        }

        public List<CovidTrend> GetInfectionsData() 
        {
            List<CovidTrend> infectionsPerDay = new List<CovidTrend>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) as Total, infectionDate as Date FROM patient GROUP BY (infectionDate) ORDER BY infectionDate;", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        infectionsPerDay.Add(new CovidTrend()
                        {
                            Total = int.Parse(reader["Total"].ToString()),
                            Date = DateTime.ParseExact(reader["Date"].ToString(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                        });
                    }
                }
            }

            return infectionsPerDay;
        }
    }
}
