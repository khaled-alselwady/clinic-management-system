using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem_DataAccessLayer_
{
    public class clsPersonDataAccessLayer
    {
        public static bool GetPersonInfo(int PersonID, ref string Name, ref DateTime DateOfBirth, ref char Gender,
                                         ref string PhoneNumber, ref string Email, ref string Address)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from Persons where PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    Name = (string)reader["Name"];
                    Gender = Convert.ToChar(reader["Gender"]);
                    PhoneNumber = (string)reader["PhoneNumber"];

                    // Nullable fields
                    DateOfBirth = (reader["DateOfBirth"] != System.DBNull.Value) ? (DateTime)reader["DateOfBirth"] : new DateTime();
                    Email = (reader["Email"] != System.DBNull.Value) ? (string)reader["Email"] : string.Empty;
                    Address = (reader["Address"] != System.DBNull.Value) ? (string)reader["Address"] : string.Empty;

                }
                else
                {
                    IsFound = false;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }


        public static int AddNewPerson(string Name, DateTime DateOfBirth, char Gender,
                                       string PhoneNumber, string Email, string Address)
        {
            int PersonID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"insert into Persons (Name, DateOfBirth, Gender, PhoneNumber, Email, Address)
                             Values (@Name, @DateOfBirth, @Gender, @PhoneNumber, @Email, @Address)
                             select scope_identity()";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);

            // Nullable fields
            if (DateOfBirth == new DateTime())
            {
                command.Parameters.AddWithValue("@DateOfBirth", System.DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            }

            if (string.IsNullOrWhiteSpace(Email))
            {
                command.Parameters.AddWithValue("@Email", System.DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Email", Email);
            }

            if (string.IsNullOrWhiteSpace(Address))
            {
                command.Parameters.AddWithValue("@Address", System.DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("Address", Address);
            }


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertID))
                {
                    PersonID = InsertID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return PersonID;
        }


        public static bool UpdatePerson(int PersonID, string Name, DateTime DateOfBirth, char Gender,
                                        string PhoneNumber, string Email, string Address)
        {
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"update Persons
                             set    Name = @Name,
                                    DateOfBirth = @DateOfBirth,
                                    Gender = @Gender,
                                    PhoneNumber = @PhoneNumber,
                                    Email = @Email,
                                    Address = @Address
                             where  PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            // Nullable fields
            if (DateOfBirth == new DateTime())
            {
                command.Parameters.AddWithValue("@DateOfBirth", System.DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            }

            if (string.IsNullOrWhiteSpace(Email))
            {
                command.Parameters.AddWithValue("@Email", System.DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Email", Email);
            }

            if (string.IsNullOrWhiteSpace(Address))
            {
                command.Parameters.AddWithValue("@Address", System.DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("Address", Address);
            }


            try
            {
                connection.Open();

                AffectedRows = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return (AffectedRows > 0);
        }


        public static bool DeletePerson(int PersonID)
        {
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"delete from persons where  PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                AffectedRows = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return (AffectedRows > 0);
        }



        public static bool IsPersonExists(int PersonID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select found = 1 from Persons where PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                IsFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

    }
}
