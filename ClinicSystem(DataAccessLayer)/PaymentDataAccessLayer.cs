using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem_DataAccessLayer_
{
    public class clsPaymentDataAccessLayer
    {
        public static bool GetPaymentInfo(int PaymentID, ref DateTime PaymentDate, ref string PaymentMethod,
                                          ref decimal AmountPaid, ref string AdditionalNotes)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from Payments where PaymentID = @PaymentID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PaymentID", PaymentID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    PaymentDate = (DateTime)reader["PaymentDate"];
                    AmountPaid = (decimal)reader["amountPaid"];

                    // Nullable Columns
                    PaymentMethod = reader["PaymentMethod"] != DBNull.Value ? (string)reader["PaymentMethod"] : "";
                    AdditionalNotes = reader["AdditionalNotes"] != DBNull.Value ? (string)reader["AdditionalNotes"] : "";
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


        public static int AddNewPayment(DateTime PaymentDate, string PaymentMethod, decimal AmountPaid,
                                        string AdditionalNotes)
        {
            int PaymentID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"insert into Payments (PaymentDate, PaymentMethod, AmountPaid, AdditionalNotes)
                             values (@PaymentDate, @PaymentMethod, @AmountPaid, @AdditionalNotes)
                             select scope_identity()";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PaymentDate", PaymentDate);
            command.Parameters.AddWithValue("@AmountPaid", AmountPaid);

            // Nullable Columns
            if (string.IsNullOrWhiteSpace(PaymentMethod))
            {
                command.Parameters.AddWithValue("@PaymentMethod", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@PaymentMethod", PaymentMethod);
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
                    PaymentID = InsertID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return PaymentID;
        }


        public static bool UpdatePayment(int PaymentID, DateTime PaymentDate, string PaymentMethod,
                                         decimal AmountPaid, string AdditionalNotes)
        {
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"update Payments
                             set    PaymentDate     = @PaymentDate,
                                    PaymentMethod   = @PaymentMethod,
                                    AmountPaid      = @AmountPaid,
                                    AdditionalNotes = @AdditionalNotes
                             where  PaymentID       = @PaymentID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PaymentDate", PaymentDate);
            command.Parameters.AddWithValue("@AmountPaid", AmountPaid);
            command.Parameters.AddWithValue("@PaymentID", PaymentID);

            // Nullable Columns
            if (string.IsNullOrWhiteSpace(PaymentMethod))
            {
                command.Parameters.AddWithValue("@PaymentMethod", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@PaymentMethod", PaymentMethod);
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


        public static bool DeletePayment(int PaymentID)
        {
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"delete from Payments where PaymentID = @PaymentID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PaymentID", PaymentID);

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



        public static bool IsPaymentExists(int PaymentID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select found = 1 from Payments where PaymentID = @PaymentID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("PaymentID", PaymentID);

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



        public static DataView GetAllPayments()
        {
            DataTable dtPayments = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from Payments";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtPayments.Load(reader);
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

            return dtPayments.DefaultView;
        }



        public static DataView GetAllPaymentsOfSpecificPatient(int PatientID)
        {
            DataTable dtPayments = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Payments.* FROM Payments
                             INNER JOIN Appointments ON Payments.PaymentID = Appointments.PaymentID
                             INNER JOIN Patients ON Appointments.PatientID = Patients.PatientID
                             where Patients.PatientID = @PatientID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PatientID", PatientID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtPayments.Load(reader);
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

            return dtPayments.DefaultView;
        }



        public static DataView SearchPaymentsContainByPaymentID(string Contain)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from Payments where PaymentID LIKE @Contain + '%'";
                                 

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


        public static DataView SearchPaymentsContainByPaymentMethod(string Contain)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from Payments where PaymentMethod LIKE @Contain + '%'";


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


    }
}
