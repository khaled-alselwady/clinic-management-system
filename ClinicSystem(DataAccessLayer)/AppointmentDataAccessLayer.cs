using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem_DataAccessLayer_
{
    public class clsAppointmentDataAccessLayer
    {
        public static bool GetAppointmentInfo(int AppointmentID, ref int PatientID, ref int DoctorID,
                                              ref DateTime AppointmentDateTime, ref short StatusID,
                                              ref int MedicalRecordID, ref int PaymentID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from Appointments where AppointmentID = @AppointmentID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AppointmentID", AppointmentID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    PatientID = (int)reader["PatientID"];
                    DoctorID = (int)reader["DoctorID"];
                    AppointmentDateTime = (DateTime)reader["AppointmentDateTime"];
                    (StatusID) = (byte)reader["StatusID"];

                    //Nullable Columns
                    MedicalRecordID = reader["MedicalRecordID"] != DBNull.Value ? (int)reader["MedicalRecordID"] : -1;
                    PaymentID = reader["PaymentID"] != DBNull.Value ? (int)reader["PaymentID"] : -1;
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


        public static int AddNewAppointment(int PatientID, int DoctorID, DateTime AppointmentDateTime,
                                            short StatusID, int MedicalRecordID, int PaymentID)
        {
            int AppointmentID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"insert into Appointments (PatientID, DoctorID, AppointmentDateTime, StatusID, MedicalRecordID, PaymentID)
                             values (@PatientID, @DoctorID, @AppointmentDateTime, @StatusID, @MedicalRecordID, @PaymentID)
                             select scope_identity()";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PatientID", PatientID);
            command.Parameters.AddWithValue("@DoctorID", DoctorID);
            command.Parameters.AddWithValue("@AppointmentDateTime", AppointmentDateTime);
            command.Parameters.AddWithValue("@StatusID", Convert.ToByte(StatusID));

            // Nullable Columns
            if (MedicalRecordID <= 0)
            {
                command.Parameters.AddWithValue("@MedicalRecordID", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@MedicalRecordID", MedicalRecordID);
            }

            if (PaymentID <= 0)
            {
                command.Parameters.AddWithValue("@PaymentID", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@PaymentID", PaymentID);
            }

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertID))
                {
                    AppointmentID = InsertID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return AppointmentID;
        }


        public static bool UpdateAppointment(int AppointmentID, int PatientID, int DoctorID, DateTime AppointmentDateTime,
                                             short StatusID, int MedicalRecordID, int PaymentID)
        {
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"update Appointments
                             set    PatientID           = @PatientID,
                                    DoctorID            = @DoctorID,
                                    AppointmentDateTime = @AppointmentDateTime,
                                    StatusID            = @StatusID,
                                    MedicalRecordID     = @MedicalRecordID,
                                    PaymentID           = @PaymentID
                             where  AppointmentID       = @AppointmentID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PatientID", PatientID);
            command.Parameters.AddWithValue("@DoctorID", DoctorID);
            command.Parameters.AddWithValue("@AppointmentDateTime", AppointmentDateTime);
            command.Parameters.AddWithValue("@StatusID", StatusID);
            command.Parameters.AddWithValue("@AppointmentID", AppointmentID);

            // Nullable Columns
            if (MedicalRecordID <= 0)
            {
                command.Parameters.AddWithValue("@MedicalRecordID", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@MedicalRecordID", MedicalRecordID);
            }

            if (PaymentID <= 0)
            {
                command.Parameters.AddWithValue("@PaymentID", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@PaymentID", PaymentID);
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


        public static bool DeleteAppointment(int AppointmentID)
        {
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"delete from Appointments where AppointmentID = @AppointmentID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AppointmentID", AppointmentID);

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



        public static bool IsAppointmentExists(int AppointmentID)
        {
            bool IsFount = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select found = 1 from Appointments where AppointmentID = @AppointmentID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AppointmentID", AppointmentID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                IsFount = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                IsFount = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFount;
        }



        public static DataView GetAllAppointments()
        {
            DataTable dtAppointments = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Appointments.AppointmentID, Appointments.PatientID,
                             Appointments.DoctorID, Appointments.AppointmentDateTime,
                             AppointmentStatus.Status, Appointments.MedicalRecordID,
                             Appointments.PaymentID
                             FROM Appointments
                             INNER JOIN AppointmentStatus ON Appointments.StatusID = AppointmentStatus.StatusID";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtAppointments.Load(reader);
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

            return dtAppointments.DefaultView;
        }



        public static DataView SearchAppointmentsContainByAppointmentID(string Contain)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Appointments.AppointmentID, Appointments.PatientID,
                             Appointments.DoctorID, Appointments.AppointmentDateTime,
                             AppointmentStatus.Status, Appointments.MedicalRecordID,
                             Appointments.PaymentID
                             FROM Appointments
                             INNER JOIN AppointmentStatus ON Appointments.StatusID = AppointmentStatus.StatusID
                             where Appointments.AppointmentID LIKE @Contain + '%'";

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



        public static DataView SearchAppointmentsContainByPatientID(string Contain)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Appointments.AppointmentID, Appointments.PatientID,
                             Appointments.DoctorID, Appointments.AppointmentDateTime,
                             AppointmentStatus.Status, Appointments.MedicalRecordID,
                             Appointments.PaymentID
                             FROM Appointments
                             INNER JOIN AppointmentStatus ON Appointments.StatusID = AppointmentStatus.StatusID
                             where Appointments.PatientID LIKE @Contain + '%'";

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




        public static DataView SearchAppointmentsContainByDoctorID(string Contain)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Appointments.AppointmentID, Appointments.PatientID,
                             Appointments.DoctorID, Appointments.AppointmentDateTime,
                             AppointmentStatus.Status, Appointments.MedicalRecordID,
                             Appointments.PaymentID
                             FROM Appointments
                             INNER JOIN AppointmentStatus ON Appointments.StatusID = AppointmentStatus.StatusID
                             where Appointments.DoctorID LIKE @Contain + '%'";

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



        public static int GetTotalAppointments()
        {
            int Total = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select count(*) from Appointments";

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
