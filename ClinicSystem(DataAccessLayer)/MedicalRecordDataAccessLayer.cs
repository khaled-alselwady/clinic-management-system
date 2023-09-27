using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem_DataAccessLayer_
{
    public class clsMedicalRecordDataAccessLayer
    {
        public static bool GetMedicalRecordInfo(int MedicalRecordID, ref string VisitDescription,
                                                ref string Diagnosis, ref string AdditionalNotes)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from MedicalRecords where MedicalRecordID = @MedicalRecordID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@MedicalRecordID", MedicalRecordID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    // Nullable Columns
                    VisitDescription = reader["VisitDescription"] != DBNull.Value ? (string)reader["VisitDescription"] : string.Empty;
                    Diagnosis = reader["Diagnosis"] != DBNull.Value ? (string)reader["Diagnosis"] : string.Empty;
                    AdditionalNotes = reader["AdditionalNotes"] != DBNull.Value ? (string)reader["AdditionalNotes"] : string.Empty;
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

        public static int AddNewMedicalRecord(string VisitDescription, string Diagnosis, string AdditionalNotes)
        {
            int MedicalRecordID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"insert into MedicalRecords (VisitDescription ,Diagnosis ,AdditionalNotes)
                             values (@VisitDescription ,@Diagnosis ,@AdditionalNotes)
                             select scope_identity()";

            SqlCommand command = new SqlCommand(query, connection);

            // Nullable Columns
            if (string.IsNullOrWhiteSpace(VisitDescription))
            {
                command.Parameters.AddWithValue("@VisitDescription", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@VisitDescription", VisitDescription);
            }

            if (string.IsNullOrWhiteSpace(Diagnosis))
            {
                command.Parameters.AddWithValue("@Diagnosis", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Diagnosis", Diagnosis);
            }

            if (string.IsNullOrWhiteSpace(AdditionalNotes))
            {
                command.Parameters.AddWithValue("@AdditionalNotes", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@AdditionalNotes", AdditionalNotes);
            }

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertID))
                {
                    MedicalRecordID = InsertID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return MedicalRecordID;
        }


        public static bool UpdateMedicalRecord(int MedicalRecordID, string VisitDescription,
                                               string Diagnosis, string AdditionalNotes)
        {
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"update MedicalRecords
                             set    VisitDescription = @VisitDescription,
                                    Diagnosis        = @Diagnosis,
                                    AdditionalNotes  = @AdditionalNotes
                             where  MedicalRecordID  = @MedicalRecordID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@MedicalRecordID", MedicalRecordID);

            // Nullable Columns
            if (string.IsNullOrWhiteSpace(VisitDescription))
            {
                command.Parameters.AddWithValue("@VisitDescription", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@VisitDescription", VisitDescription);
            }

            if (string.IsNullOrWhiteSpace(Diagnosis))
            {
                command.Parameters.AddWithValue("@Diagnosis", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Diagnosis", Diagnosis);
            }

            if (string.IsNullOrWhiteSpace(AdditionalNotes))
            {
                command.Parameters.AddWithValue("@AdditionalNotes", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@AdditionalNotes", AdditionalNotes);
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

        public static bool DeleteMedicalRecord(int MedicalRecordID)
        {
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"delete from MedicalRecords where MedicalRecordID = @MedicalRecordID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@MedicalRecordID", MedicalRecordID);

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


        public static bool IsMedicalRecordExists(int MedicalRecordID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select found = 1 from MedicalRecords where MedicalRecordID = @MedicalRecordID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@MedicalRecordID", MedicalRecordID);

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


        public static DataView GetAllMedicalRecords()
        {
            DataTable dtMedicalRecords = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from MedicalRecords";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtMedicalRecords.Load(reader);
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

            return dtMedicalRecords.DefaultView;
        }


        public static DataView GetAllMedicalRecordsOfSpecificPatient(int PatientID)
        {
            DataTable dtMedicalRecords = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select MedicalRecords.* from MedicalRecords
                             inner join Appointments on Appointments.MedicalRecordID = MedicalRecords.MedicalRecordID
                             inner join Patients on Patients.PatientID = Appointments.PatientID
                             where Patients.PatientID = @PatientID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PatientID", PatientID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtMedicalRecords.Load(reader);
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

            return dtMedicalRecords.DefaultView;
        }
    }
}
