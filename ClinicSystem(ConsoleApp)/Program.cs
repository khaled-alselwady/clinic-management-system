using ClinicSystem_BusinessLayer_;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem_ConsoleApp_
{
    internal class Program
    {

        //Person
        private static void FindPerson(int PersonID)
        {
            clsPerson Person = clsPerson.FindPerson(PersonID);

            if (Person != null)
            {
                Console.WriteLine($"Person ID    : {Person.PersonID}");
                Console.WriteLine($"Name         : {Person.Name}");
                Console.WriteLine($"Date Of Birth: {Person.DateOfBirth}");
                Console.WriteLine($"Gender       : {Person.Gender}");
                Console.WriteLine($"Phone Number : {Person.PhoneNumber}");
                Console.WriteLine($"Email        : {Person.Email}");
                Console.WriteLine($"Address      : {Person.Address}");
            }
            else
            {
                Console.WriteLine("Error");
            }

        }
        private static void AddNewPerson()
        {
            clsPerson Person = new clsPerson();

            Person.Name = "Test Test";
            Person.DateOfBirth = DateTime.Now;
            Person.Gender = 'F';
            Person.PhoneNumber = "12345";

            if (Person.Save())
            {
                Console.WriteLine("Done");
            }
            else
            {
                Console.WriteLine("Error");
            }

        }
        private static void UpdatePerson(int PersonID)
        {
            clsPerson Person = clsPerson.FindPerson(PersonID);

            if (Person != null)
            {
                Person.Name = "Test";
                Person.Email = "Test@gamil.com";
                Person.Address = "Amman";

                if (Person.Save())
                {
                    Console.WriteLine("Done");
                }
                else
                {
                    Console.WriteLine("Error");
                }

            }

        }
        private static void DeletePerson(int PersonID)
        {
            if (clsPerson.IsPersonExists(PersonID))
            {
                if (clsPerson.DeletePerson(PersonID))
                {
                    Console.WriteLine("Done");
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
            else
            {
                Console.WriteLine("Not Found");
            }

        }


        //Patient
        private static void FindPatient(int PatientID)
        {
            clsPatient Patient = clsPatient.FindPatient(PatientID);

            if (Patient != null)
            {

                Console.WriteLine($"Patient ID   : {Patient.PatientID}");
                Console.WriteLine($"Name         : {Patient.Name}");
                Console.WriteLine($"Date Of Birth: {Patient.DateOfBirth}");
                Console.WriteLine($"Gender       : {Patient.Gender}");
                Console.WriteLine($"Phone Number : {Patient.PhoneNumber}");
                Console.WriteLine($"Email        : {Patient.Email}");
                Console.WriteLine($"Address      : {Patient.Address}");
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }
        private static void AddNewPatient()
        {
            clsPatient Patient = new clsPatient();

            Patient.Name = "Test Test";
            Patient.DateOfBirth = DateTime.Now;
            Patient.Gender = 'F';
            Patient.PhoneNumber = "12345";

            if (Patient.Save())
            {
                Console.WriteLine("Done");
            }
            else
            {
                Console.WriteLine("Error");
            }

        }
        private static void UpdatePatient(int PatientID)
        {
            clsPatient Patient = clsPatient.FindPatient(PatientID);

            if (Patient != null)
            {
                Patient.Name = "Test";
                Patient.DateOfBirth = DateTime.Now;
                Patient.Gender = 'M';
                Patient.PhoneNumber = "123fgf45";

                if (Patient.Save())
                {
                    Console.WriteLine("Done");
                }
                else
                {
                    Console.WriteLine("Error");
                }

            }

        }
        private static void DeletePatient(int PatientID)
        {
            if (clsPatient.IsPatientExists(PatientID))
            {
                if (clsPatient.DeletePatient(PatientID))
                {
                    Console.WriteLine("Done");
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }
        private static void GetAllPatients()
        {
            DataView dvPatients = clsPatient.GetAllPatients();

            for (int i = 0; i < dvPatients.Count; i++)
            {
                Console.WriteLine("Patient ID: {0} \t Name: {1} \t DataOfBirth: {2} \t Gender: {3} \t PhoneNumber: {4} \t Email: {5} \t Address: {6}",
                                   dvPatients[i]["PatientID"], dvPatients[i]["Name"], dvPatients[i]["DateOfBirth"], dvPatients[i]["Gender"], dvPatients[i]["PhoneNumber"], dvPatients[i]["Email"], dvPatients[i]["Address"]);
            }
        }


        //Doctor
        private static void FindDoctor(int DoctorID)
        {
            clsDoctor Doctor = clsDoctor.FindDoctor(DoctorID);

            if (Doctor != null)
            {
                Console.WriteLine($"Doctor ID    : {Doctor.DoctorID}");
                Console.WriteLine($"Name         : {Doctor.Name}");
                Console.WriteLine($"Date Of Birth: {Doctor.DateOfBirth}");
                Console.WriteLine($"Gender       : {Doctor.Gender}");
                Console.WriteLine($"Phone Number : {Doctor.PhoneNumber}");
                Console.WriteLine($"Email        : {Doctor.Email}");
                Console.WriteLine($"Address      : {Doctor.Address}");
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }
        private static void AddNewDoctor()
        {
            clsDoctor Doctor = new clsDoctor();

            Doctor.Name = "Test Test";
            Doctor.DateOfBirth = DateTime.Now;
            Doctor.Gender = 'F';
            Doctor.PhoneNumber = "12345";
            // Doctor.Specialization

            if (Doctor.Save())
            {
                Console.WriteLine("Done");
            }
            else
            {
                Console.WriteLine("Error");
            }

        }
        private static void UpdateDoctor(int DoctorID)
        {
            clsDoctor Doctor = clsDoctor.FindDoctor(DoctorID);

            if (Doctor != null)
            {
                Doctor.Name = "Test Test";
                Doctor.DateOfBirth = DateTime.Now;
                Doctor.Gender = 'M';
                Doctor.PhoneNumber = "12345";

                if (Doctor.Save())
                {
                    Console.WriteLine("Done");
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }

            else
            {
                Console.WriteLine("Not Found");
            }
        }
        private static void DeleteDoctor(int DoctorID)
        {
            if (clsDoctor.IsDoctorExists(DoctorID))
            {

                if (clsDoctor.DeleteDoctor(DoctorID))
                {
                    Console.WriteLine("Done");
                }
                else
                {
                    Console.WriteLine("Error");
                }

            }

            else
            {
                Console.WriteLine("Not Found");
            }
        }
        private static void GetAllDoctors()
        {
            DataView dvDoctors = clsDoctor.GetAllDoctors();

            for (int i = 0; i < dvDoctors.Count; i++)
            {
                Console.WriteLine("Doctor ID: {0} \t Name: {1} \t DataOfBirth: {2} \t Gender: {3} \t PhoneNumber: {4} \t Email: {5} \t Address: {6} \t Specialization: {7}",
                                   dvDoctors[i]["DoctorID"], dvDoctors[i]["Name"], dvDoctors[i]["DateOfBirth"], dvDoctors[i]["Gender"], dvDoctors[i]["PhoneNumber"], dvDoctors[i]["Email"], dvDoctors[i]["Address"], dvDoctors[i]["Specialization"]);
            }

        }


        //User
        private static void FindUser(int UserID)
        {
            clsUser User = clsUser.FindUser(UserID);

            if (User != null)
            {
                Console.WriteLine($"User ID      : {User.UserID}");
                Console.WriteLine($"Username     : {User.Username}");
                Console.WriteLine($"Password     : {User.Password}");
                Console.WriteLine($"Permissions  : {User.Permissions}");
                Console.WriteLine($"Name         : {User.Name}");
                Console.WriteLine($"Date Of Birth: {User.DateOfBirth}");
                Console.WriteLine($"Gender       : {User.Gender}");
                Console.WriteLine($"Phone Number : {User.PhoneNumber}");
                Console.WriteLine($"Email        : {User.Email}");
                Console.WriteLine($"Address      : {User.Address}");
            }
            else
            {
                Console.WriteLine("Not Found");
            }

        }
        private static void FindUser(string Username)
        {
            clsUser User = clsUser.FindUser(Username);

            if (User != null)
            {
                Console.WriteLine($"User ID      : {User.UserID}");
                Console.WriteLine($"Username     : {User.Username}");
                Console.WriteLine($"Password     : {User.Password}");
                Console.WriteLine($"Permissions  : {User.Permissions}");
                Console.WriteLine($"Name         : {User.Name}");
                Console.WriteLine($"Date Of Birth: {User.DateOfBirth}");
                Console.WriteLine($"Gender       : {User.Gender}");
                Console.WriteLine($"Phone Number : {User.PhoneNumber}");
                Console.WriteLine($"Email        : {User.Email}");
                Console.WriteLine($"Address      : {User.Address}");
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }
        private static void FindUser(string Username, string Password)
        {
            clsUser User = clsUser.FindUser(Username, Password);

            if (User != null)
            {
                Console.WriteLine($"User ID      : {User.UserID}");
                Console.WriteLine($"Username     : {User.Username}");
                Console.WriteLine($"Password     : {User.Password}");
                Console.WriteLine($"Permissions  : {User.Permissions}");
                Console.WriteLine($"Name         : {User.Name}");
                Console.WriteLine($"Date Of Birth: {User.DateOfBirth}");
                Console.WriteLine($"Gender       : {User.Gender}");
                Console.WriteLine($"Phone Number : {User.PhoneNumber}");
                Console.WriteLine($"Email        : {User.Email}");
                Console.WriteLine($"Address      : {User.Address}");
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }
        private static void AddNewUser()
        {
            clsUser User = new clsUser();

            User.Name = "Test";
            User.DateOfBirth = DateTime.Now;
            User.Gender = 'F';
            User.PhoneNumber = "12345";
            User.Username = "user6";
            User.Password = "1234";
            User.Permissions = 5;
            //User.Specialization

            if (User.Save())
            {
                Console.WriteLine("Done");
            }
            else
            {
                Console.WriteLine("Error");
            }

        }
        private static void UpdateUser(int UserID)
        {
            clsUser User = clsUser.FindUser(UserID);

            if (User != null)
            {
                User.Name = "Test";
                User.DateOfBirth = DateTime.Now;
                User.Gender = 'M';
                User.PhoneNumber = "1234500";
                User.Username = "user4";
                User.Password = "12345";
                User.Permissions = -1;
                User.Address = "Amman";

                if (User.Save())
                {
                    Console.WriteLine("Done");
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }
        private static void DeleteUser(int UserID)
        {
            if (clsUser.IsUserExists(UserID))
            {
                if (clsUser.DeleteUser(UserID))
                {
                    Console.WriteLine("Done");
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }
        private static void IsUserExists(string Username)
        {
            if (clsUser.IsUserExists(Username))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
        private static void IsUserExists(string Username, string Password)
        {
            if (clsUser.IsUserExists(Username, Password))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
        private static void GetUsersInfo()
        {
            DataView dvUsers = clsUser.GetAllUsers();

            for (int i = 0; i < dvUsers.Count; i++)
            {
                Console.WriteLine("User ID: {0} \t Name: {1} \t Username: {2} \t Password: {3} \t Permissions: {4} \t DataOfBirth: {5} \t Gender: {6} \t PhoneNumber: {7} \t Email: {8} \t Address: {9}",
                                   dvUsers[i]["UserID"], dvUsers[i]["Name"], dvUsers[i]["Username"], dvUsers[i]["Password"], dvUsers[i]["Permissions"], dvUsers[i]["DateOfBirth"], dvUsers[i]["Gender"], dvUsers[i]["PhoneNumber"], dvUsers[i]["Email"], dvUsers[i]["Address"]);
            }


        }


        //Medical Record
        private static void FindMedicalRecord(int MedicalRecordID)
        {
            clsMedicalRecord MedicalRecord = clsMedicalRecord.FindMedicalRecord(MedicalRecordID);

            if (MedicalRecord != null)
            {
                Console.WriteLine($"Medical Record ID: {MedicalRecord.MedicalRecordID}");
                Console.WriteLine($"VisitDescription : {MedicalRecord.VisitDescription}");
                Console.WriteLine($"Diagnosis        : {MedicalRecord.Diagnosis}");
                Console.WriteLine($"AdditionalNotes  : {MedicalRecord.AdditionalNotes}");
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }
        private static void AddNewMedicalRecord()
        {
            clsMedicalRecord MedicalRecord = new clsMedicalRecord();

            MedicalRecord.VisitDescription = "Description";
            MedicalRecord.Diagnosis = "Diagnosis";
            MedicalRecord.AdditionalNotes = "AdditionalNotes";

            if (MedicalRecord.Save())
            {
                Console.WriteLine("Done");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
        private static void UpdateMedicalRecord(int MedicalRecordID)
        {
            clsMedicalRecord MedicalRecord = clsMedicalRecord.FindMedicalRecord(MedicalRecordID);

            if (MedicalRecord != null)
            {
                MedicalRecord.VisitDescription = "Test";
                MedicalRecord.Diagnosis = "Test";
                MedicalRecord.AdditionalNotes = "AdditionalNotes";

                if (MedicalRecord.Save())
                {
                    Console.WriteLine("Done");
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }
        private static void DeleteMedicalRecord(int MedicalRecordID)
        {
            if (clsMedicalRecord.IsMedicalRecordExists(MedicalRecordID))
            {
                if (clsMedicalRecord.DeleteMedicalRecord(MedicalRecordID))
                {
                    Console.WriteLine("Done");
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }
        private static void GetAllMedicalRecord()
        {
            DataView dvMedicalRecords = clsMedicalRecord.GetAllMedicalRecords();

            for (int i = 0; i < dvMedicalRecords.Count; i++)
            {

                Console.WriteLine("Medical Record ID: {0} \t VisitDescription: {1} \t Diagnosis: {2} \t AdditionalNotes: {3}",
                                   dvMedicalRecords[i]["MedicalRecordID"], dvMedicalRecords[i]["VisitDescription"], dvMedicalRecords[i]["Diagnosis"], dvMedicalRecords[i]["AdditionalNotes"]);

            }

        }


        //Prescription
        private static void FindPrescription(int PrescriptionID)
        {
            clsPrescription Prescription = clsPrescription.FindPrescription(PrescriptionID);

            if (Prescription != null)
            {
                Console.WriteLine($"Prescription ID      : {Prescription.PrescriptionID}");
                Console.WriteLine($"MedicalRecord ID     : {Prescription.MedicalRecordID}");
                Console.WriteLine($"Medication Name      : {Prescription.MedicationName}");
                Console.WriteLine($"Dosage               : {Prescription.Dosage}");
                Console.WriteLine($"Frequency            : {Prescription.Frequency}");
                Console.WriteLine($"Start Date           : {Prescription.StartDate}");
                Console.WriteLine($"End Date             : {Prescription.EndDate}");
                Console.WriteLine($"Special Instructions : {Prescription.SpecialInstructions}");
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }
        private static void AddNewPrescription()
        {
            clsPrescription Prescription = new clsPrescription();

            Prescription.MedicalRecordID = 1;
            Prescription.MedicationName = "Name";
            Prescription.Dosage = "3 times";
            //Prescription.Frequency = "";
            Prescription.StartDate = DateTime.Now;
            Prescription.EndDate = DateTime.Now;
            Prescription.SpecialInstructions = "";

            if (Prescription.Save())
            {
                Console.WriteLine("Done");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
        private static void UpdatePrescription(int PrescriptionID)
        {
            clsPrescription Prescription = clsPrescription.FindPrescription(PrescriptionID);

            if (Prescription != null)
            {

                Prescription.Frequency = "4 Times";


                if (Prescription.Save())
                {
                    Console.WriteLine("Done");
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }
        private static void DeletePrescription(int PrescriptionID)
        {
            if (clsPrescription.IsPrescriptionExists(PrescriptionID))
            {
                if (clsPrescription.DeletePrescription(PrescriptionID))
                {
                    Console.WriteLine("Done");
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }
        private static void GetAllPrescriptions()
        {
            DataView dvPrescriptions = clsPrescription.GetAllPrescriptions();

            for (int i = 0; i < dvPrescriptions.Count; i++)
            {

                Console.WriteLine("Prescription ID: {0} \t Medical Record ID: {1} \t Medication Name: {2} \t Dosage: {3} \t Frequency: {4} \t Start Date: {5} \t End Date: {6} \t Special Instructions: {7}",
                                   dvPrescriptions[i]["PrescriptionID"], dvPrescriptions[i]["MedicalRecordID"],
                                   dvPrescriptions[i]["MedicationName"], dvPrescriptions[i]["Dosage"],
                                   dvPrescriptions[i]["Frequency"], dvPrescriptions[i]["StartDate"],
                                   dvPrescriptions[i]["EndDate"], dvPrescriptions[i]["SpecialInstructions"]);

            }

        }


        //Payment
        private static void FindPayment(int PaymentID)
        {
            clsPayment Payment = clsPayment.FindPayment(PaymentID);

            if (Payment != null)
            {
                Console.WriteLine($"Payment ID      : {Payment.PaymentID}");
                Console.WriteLine($"Payment Date    : {Payment.PaymentDate}");
                Console.WriteLine($"Payment Method  : {Payment.PaymentMethod}");
                Console.WriteLine($"Amount Paid     : {Payment.AmountPaid}");
                Console.WriteLine($"Additional Notes: {Payment.AdditionalNotes}");
            }
            else
            {
                Console.WriteLine("Not Found");
            }

        }
        private static void AddNewPayment()
        {
            clsPayment Payment = new clsPayment();

            Payment.PaymentDate = DateTime.Now;
            Payment.PaymentMethod = "Cash";
            Payment.AmountPaid = 10;

            if (Payment.Save())
            {
                Console.WriteLine("Done");
            }
            else
            {
                Console.WriteLine("Error");
            }

        }
        private static void UpdatePayment(int PaymentID)
        {
            clsPayment Payment = clsPayment.FindPayment(PaymentID);

            if (Payment != null)
            {
                Payment.PaymentDate = DateTime.Now;
                Payment.PaymentMethod = "Credit Card";
                Payment.AmountPaid = 25;
                Payment.AdditionalNotes = "Test";

                if (Payment.Save())
                {
                    Console.WriteLine("Done");
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }
        private static void DeletePayment(int PaymentID)
        {
            if (clsPayment.IsPaymentExists(PaymentID))
            {
                if (clsPayment.DeletePayment(PaymentID))
                {
                    Console.WriteLine("Done");
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }
        private static void GetAllPayments()
        {
            DataView dvPayments = clsPayment.GetAllPayments();

            for (int i = 0; i < dvPayments.Count; i++)
            {
                Console.WriteLine("Payment ID: {0} \t Payment Date: {1} \t Payment Method: {2} \t Amount Paid: {3} \t Additional Notes: {4}",
                                   dvPayments[i]["PaymentID"], dvPayments[i]["PaymentDate"], dvPayments[i]["PaymentMethod"], dvPayments[i]["AmountPaid"], dvPayments[i]["AdditionalNotes"]);
            }

        }


        //AppointmentStatus
        private static void FindStatus(sbyte StatusID)
        {
            clsAppointmentStatus Status = clsAppointmentStatus.FindStatus(StatusID);

            if (Status != null)
            {
                Console.WriteLine($"Status ID: {Status.StatusID}");
                Console.WriteLine($"Status   : {Status.Status}");
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }
        private static void FindStatus(string Status)
        {
            clsAppointmentStatus Statuss = clsAppointmentStatus.FindStatus(Status);

            if (Statuss != null)
            {
                Console.WriteLine($"Status ID: {Statuss.StatusID}");
                Console.WriteLine($"Status   : {Statuss.Status}");
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }
        private static void AddNewStatus()
        {
            clsAppointmentStatus Status = new clsAppointmentStatus();

            Status.Status = "Test";

            if (Status.Save())
            {
                Console.WriteLine("Done");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
        private static void UpdateStatus(sbyte StatusID)
        {
            clsAppointmentStatus Status = clsAppointmentStatus.FindStatus(StatusID);

            if (Status != null)
            {
                Status.Status = "Test3";

                if (Status.Save())
                {
                    Console.WriteLine("Done");
                }
                else
                {
                    Console.WriteLine("Error");
                }

            }
            else
            {
                Console.WriteLine("Not Found");
            }

        }
        private static void DeleteStatus(sbyte StatusID)
        {
            if (clsAppointmentStatus.IsStatusExists(StatusID))
            {
                if (clsAppointmentStatus.DeleteStatus(StatusID))
                {
                    Console.WriteLine("Done");
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }
        private static void IsStatusExists(string Status)
        {
            if (clsAppointmentStatus.IsStatusExists(Status))
            {
                Console.WriteLine("Done");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
        private static void GetAllStatus()
        {
            DataView dvStatus = clsAppointmentStatus.GetAllStatus();

            for (int i = 0; i < dvStatus.Count; i++)
            {
                Console.WriteLine("Status ID: {0} \t Status: {1}",
                                   dvStatus[i]["StatusID"], dvStatus[i]["Status"]);
            }

        }
        private static void GetAllStatusName()
        {
            DataView dvStatus = clsAppointmentStatus.GetAllStatusName();

            for (int i = 0; i < dvStatus.Count; i++)
            {
                Console.WriteLine("Status: {00}",
                                   dvStatus[i]["Status"]);
            }

        }


        //Appointment
        private static void FindAppointment(int AppointmentID)
        {
            clsAppointment Appointment = clsAppointment.FindAppointment(AppointmentID);

            if (Appointment != null)
            {
                Console.WriteLine($"Appointment ID  : {Appointment.AppointmentID}");
                Console.WriteLine($"Patient ID      : {Appointment.PatientID}");
                Console.WriteLine($"Doctor ID       : {Appointment.DoctorID}");
                Console.WriteLine($"Date Time       : {Appointment.AppointmentDateTime}");
                Console.WriteLine($"MedicalRecord ID: {Appointment.MedicalRecordID}");
                Console.WriteLine($"Payment ID      : {Appointment.PaymentID}");
            }
            else
            {
                Console.WriteLine("Not Found");
            }

        }
        private static void AddNewAppointment()
        {
            clsAppointment Appointment = new clsAppointment();

            Appointment.PatientID = 3;
            Appointment.DoctorID = 3;
            Appointment.AppointmentDateTime = new DateTime(2023, 9, 8);
            Appointment.StatusID = 3;

            if (Appointment.Save())
            {
                Console.WriteLine("Done");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
        private static void UpdateAppointment(int AppointmentID)
        {
            clsAppointment Appointment = clsAppointment.FindAppointment(AppointmentID);

            if (Appointment != null)
            {
                Appointment.PatientID = 4;
                Appointment.DoctorID = 3;
                Appointment.AppointmentDateTime = new DateTime(2023, 9, 18);
                Appointment.StatusID = 1;

                if (Appointment.Save())
                {
                    Console.WriteLine("Done");
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }
        private static void DeleteFormAppointment(int AppointmentID)
        {
            if (clsAppointment.IsAppointmentExists(AppointmentID))
            {
                if (clsAppointment.DeleteAppointment(AppointmentID))
                {
                    Console.WriteLine("Done");
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }
        private static void GetAllAppointments()
        {
            DataView dvAppointments = clsAppointment.GetAllAppointments();

            for (int i = 0; i < dvAppointments.Count; i++)
            {
                Console.WriteLine("Appointment ID: {0} \t Patient ID = {1} \t Doctor ID: {2} \t Date: {3} \t MedicalRecord ID: {4} \t Payment ID: {5} \t Status ID: {6}",
                                   dvAppointments[i]["AppointmentID"], dvAppointments[i]["PatientID"],
                                   dvAppointments[i]["DoctorID"], dvAppointments[i]["AppointmentDateTime"],
                                   dvAppointments[i]["MedicalRecordID"], dvAppointments[i]["PaymentID"], dvAppointments[i]["StatusID"]);
            }

        }


        static void Main(string[] args)
        {
            //FindPerson(40);
            //AddNewPerson();
            //UpdatePerson(40);
            //DeletePerson(22);

            //FindPatient(30);
            //AddNewPatient();
            //UpdatePatient(101);
            //DeletePatient(11);
            //GetAllPatients();

            //FindDoctor(10);
            //AddNewDoctor();
            //UpdateDoctor(60);
            //DeleteDoctor(6);
            //GetAllDoctors();

            //FindUser(5);
            //FindUser("user1");
            //FindUser("user1", "1234");
            //UpdateUser(70);
            //DeleteUser(7);
            //IsUserExists("user1");
            //IsUserExists("user1", "1234");
            //GetUsersInfo();

            //FindMedicalRecord(10);
            //AddNewMedicalRecord();
            //UpdateMedicalRecord(6);
            //DeleteMedicalRecord(6);
            //GetAllMedicalRecord();

            //FindPrescription(40);
            //AddNewPrescription();
            //UpdatePrescription(60);
            //DeletePrescription(6);
            //GetAllPrescriptions();

            //FindPayment(10);
            //AddNewPayment();
            //UpdatePayment(6);
            //DeletePayment(6);
            //GetAllPayments();

            //FindStatus(10);
            //FindStatus("Pending");
            //AddNewStatus();
            //UpdateStatus(7);
            //DeleteStatus(7);
            //IsStatusExists("pending");
            //GetAllStatus();
            //GetAllStatusName();


            //FindAppointment(1);
            //AddNewAppointment();
            //UpdateAppointment(30);
            //DeleteFormAppointment(3);
            //GetAllAppointments();

            Console.ReadKey();
        }
    }
}
