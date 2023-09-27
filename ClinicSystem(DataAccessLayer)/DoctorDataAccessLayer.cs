using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem_DataAccessLayer_
{
    public class clsDoctorDataAccessLayer
    {

        public static bool GetDoctorInfo(int DoctorID, ref int PersonID, ref string Specialization)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from Doctors where DoctorID = @DoctorID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DoctorID", DoctorID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    PersonID = (int)reader["PersonID"];

                    // Nullable column
                    Specialization = reader["Specialization"] != System.DBNull.Value ? (string)reader["Specialization"] : string.Empty;
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

        public static int GetPersonIDByDoctorID(int DoctorID)
        {
            int PersonID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select PersonID from Doctors where DoctorID = @DoctorID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DoctorID", DoctorID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int ID))
                {
                    PersonID = ID;
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

        public static int AddNewDoctor(int PersonID, string Specialization)
        {
            int DoctorID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"insert into Doctors (PersonID, Specialization)
                             values (@PersonID, @Specialization)
                             select scope_identity()";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            //Nullable Column
            if (string.IsNullOrWhiteSpace(Specialization))
            {
                command.Parameters.AddWithValue("@Specialization", System.DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Specialization", Specialization);
            }

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertID))
                {
                    DoctorID = InsertID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return DoctorID;
        }

        public static bool UpdateDoctor(int DoctorID, int PersonID, string Specialization)
        {
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"update Doctors
                             set    PersonID = @PersonID,
                                    Specialization = @Specialization
                             where  DoctorID = @DoctorID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@DoctorID", DoctorID);

            //Nullable Column
            if (string.IsNullOrWhiteSpace(Specialization))
            {
                command.Parameters.AddWithValue("@Specialization", System.DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Specialization", Specialization);
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

        public static bool DeleteDoctor(int DoctorID)
        {
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"delete from Doctors where  DoctorID = @DoctorID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DoctorID", DoctorID);

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

        public static bool IsDoctorExists(int DoctorID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select found = 1 from Doctors where DoctorID = @DoctorID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DoctorID", DoctorID);

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

        public static DataView GetAllDoctors()
        {
            DataTable dtDoctors = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select Doctors.DoctorID,Persons.Name,Persons.DateOfBirth, Gender =
                             case
                             	when Persons.Gender = 'M' then 'Male'
                             	when Persons.Gender = 'F' then 'Female'
                             end,
                             Persons.PhoneNumber, Persons.Email, Persons.Address, Doctors.Specialization
                             
                             from Doctors 
                             inner join Persons on Persons.PersonID = Doctors.PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtDoctors.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return dtDoctors.DefaultView;
        }

        public static DataView SearchDoctorsContainByDoctorID(string Contain)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT subQuery.*
                             FROM (
                                    select Doctors.DoctorID,Persons.Name,Persons.DateOfBirth, Gender =
                                    case
                                    	when Persons.Gender = 'M' then 'Male'
                                    	when Persons.Gender = 'F' then 'Female'
                                    end,
                                    Persons.PhoneNumber, Persons.Email, Persons.Address, Doctors.Specialization
                                    
                                    from Doctors 
                                    inner join Persons on Persons.PersonID = Doctors.PersonID
                                    where (Doctors.DoctorID) LIKE @Contain + '%'
                                  ) AS subQuery;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Contain", Contain);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return dt.DefaultView;

        }

        public static DataView SearchDoctorsContainByName(string Contain)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT subQuery.*
                             FROM (
                                    select Doctors.DoctorID,Persons.Name,Persons.DateOfBirth, Gender =
                                    case
                                    	when Persons.Gender = 'M' then 'Male'
                                    	when Persons.Gender = 'F' then 'Female'
                                    end,
                                    Persons.PhoneNumber, Persons.Email, Persons.Address, Doctors.Specialization
                                    
                                    from Doctors 
                                    inner join Persons on Persons.PersonID = Doctors.PersonID
                                    where (Persons.Name) LIKE '%' + @Contain + '%'
                                  ) AS subQuery;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Contain", Contain);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return dt.DefaultView;

        }

        public static int GetTotalDoctors()
        {
            int Total = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select count(*) from Doctors";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int total))
                {
                    Total = total;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return Total;
        }


    }
}
