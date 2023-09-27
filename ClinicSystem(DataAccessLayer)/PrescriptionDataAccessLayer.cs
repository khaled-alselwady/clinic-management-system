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
    public class clsPrescriptionDataAccessLayer
    {
        public static bool GetPrescriptionInfo(int PrescriptionID, ref int MedicalRecordID,
                                               ref string MedicationName, ref string Dosage,
                                               ref string Frequency, ref DateTime StartDate,
                                               ref DateTime EndDate, ref string SpecialInstructions)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from Prescriptions where PrescriptionID = @PrescriptionID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PrescriptionID", PrescriptionID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    MedicalRecordID = (int)reader["MedicalRecordID"];
                    MedicationName = (string)reader["MedicationName"];
                    Dosage = (string)reader["Dosage"];
                    Frequency = (string)reader["Frequency"];
                    StartDate = (DateTime)reader["StartDate"];
                    EndDate = (DateTime)reader["EndDate"];

                    //Nullable Columns
                    SpecialInstructions = reader["SpecialInstructions"] != DBNull.Value ? (string)reader["SpecialInstructions"] : string.Empty;
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


        public static int AddNewPrescription(int MedicalRecordID, string MedicationName, string Dosage, string Frequency,
                                              DateTime StartDate, DateTime EndDate, string SpecialInstructions)
        {
            int PrescriptionID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"if not exists (select MedicalRecordID from Prescriptions where MedicalRecordID = @MedicalRecordID)
                             begin
                                    insert into Prescriptions (MedicalRecordID, MedicationName, Dosage, Frequency, StartDate, EndDate, SpecialInstructions)
                                    values (@MedicalRecordID, @MedicationName, @Dosage, @Frequency, @StartDate, @EndDate, @SpecialInstructions)
                                    select scope_identity()
                             end";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@MedicalRecordID", MedicalRecordID);
            command.Parameters.AddWithValue("@MedicationName", MedicationName);
            command.Parameters.AddWithValue("@Dosage", Dosage);
            command.Parameters.AddWithValue("@Frequency", Frequency);
            command.Parameters.AddWithValue("@StartDate", StartDate);
            command.Parameters.AddWithValue("@EndDate", EndDate);

            // Nullable Columns
            if (string.IsNullOrWhiteSpace(SpecialInstructions))
            {
                command.Parameters.AddWithValue("@SpecialInstructions", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@SpecialInstructions", SpecialInstructions);
            }


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertID))
                {
                    PrescriptionID = InsertID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return PrescriptionID;
        }


        public static bool UpdatePrescription(int PrescriptionID, int MedicalRecordID, string MedicationName, string Dosage,
                                              string Frequency, DateTime StartDate, DateTime EndDate,
                                              string SpecialInstructions)
        {
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"update Prescriptions
                             set    MedicalRecordID     = @MedicalRecordID,
                                    MedicationName      = @MedicationName,
                                    Dosage              = @Dosage,
                                    Frequency           = @Frequency,
                                    StartDate           = @StartDate,
                                    EndDate             = @EndDate,
                                    SpecialInstructions = @SpecialInstructions
                             where  PrescriptionID      = @PrescriptionID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@MedicalRecordID", MedicalRecordID);
            command.Parameters.AddWithValue("@MedicationName", MedicationName);
            command.Parameters.AddWithValue("@Dosage", Dosage);
            command.Parameters.AddWithValue("@Frequency", Frequency);
            command.Parameters.AddWithValue("@StartDate", StartDate);
            command.Parameters.AddWithValue("@EndDate", EndDate);
            command.Parameters.AddWithValue("@PrescriptionID", PrescriptionID);

            // Nullable Columns
            if (string.IsNullOrWhiteSpace(SpecialInstructions))
            {
                command.Parameters.AddWithValue("@SpecialInstructions", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@SpecialInstructions", SpecialInstructions);
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

        public static bool DeletePrescription(int PrescriptionID)
        {
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"delete from Prescriptions where PrescriptionID = @PrescriptionID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PrescriptionID", PrescriptionID);

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


        public static bool IsPrescriptionExists(int PrescriptionID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select found = 1 from Prescriptions where PrescriptionID = @PrescriptionID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PrescriptionID", PrescriptionID);

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


        public static DataView GetAllPrescriptions()
        {
            DataTable dtPrescriptions = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from Prescriptions";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtPrescriptions.Load(reader);
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

            return dtPrescriptions.DefaultView;
        }


        public static DataView GetAllPrescriptionsOfSpecificPatient(int PatientID)
        {
            DataTable dtPrescriptions = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select Prescriptions.* from Prescriptions
                             inner join MedicalRecords on MedicalRecords.MedicalRecordID = Prescriptions.MedicalRecordID
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
                    dtPrescriptions.Load(reader);
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

            return dtPrescriptions.DefaultView;
        }
    }
}
