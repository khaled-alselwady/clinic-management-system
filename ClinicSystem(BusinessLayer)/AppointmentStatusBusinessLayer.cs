using ClinicSystem_DataAccessLayer_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem_BusinessLayer_
{
    public class clsAppointmentStatus
    {
        enum enMode { AddNew, Update }
        enMode _Mode = enMode.AddNew;

        public short StatusID { get; set; }
        public string Status { get; set; }

        public clsAppointmentStatus()
        {
            this.StatusID = -1;
            this.Status = string.Empty;

            this._Mode = enMode.AddNew;
        }

        private clsAppointmentStatus(short StatusID, string Status)
        {
            this.StatusID = StatusID;
            this.Status = Status;

            this._Mode = enMode.Update;
        }

        private bool _AddNewStatus()
        {
            this.StatusID = clsAppointmentStatusDataAccessLayer.AddNewAppointmentStatus(this.Status);

            return (this.StatusID != -1);
        }
        private bool _UpdateStatus()
        {
            return clsAppointmentStatusDataAccessLayer.UpdateAppointmentStatus(this.StatusID, this.Status);
        }
        public bool Save()
        {
            switch (this._Mode)
            {

                case enMode.AddNew:
                    return _AddNewStatus();

                case enMode.Update:
                    return _UpdateStatus();

            }

            return false;
        }

        public static clsAppointmentStatus FindStatus(short StatusID)
        {
            string Status = string.Empty;

            if (clsAppointmentStatusDataAccessLayer.GetAppointmentStatusInfo(StatusID, ref Status))
            {
                return new clsAppointmentStatus(StatusID, Status);
            }

            return null;
        }
        public static clsAppointmentStatus FindStatus(string Status)
        {
            short StatusID = -1;

            if (clsAppointmentStatusDataAccessLayer.GetAppointmentStatusInfo(Status, ref StatusID))
            {
                return new clsAppointmentStatus(StatusID, Status);
            }

            return null;
        }

        public static bool DeleteStatus(short StatusID)
        {
            return clsAppointmentStatusDataAccessLayer.DeleteAppointmentStatus(StatusID);
        }

        public static bool IsStatusExists(short StatusID)
        {
            return clsAppointmentStatusDataAccessLayer.IsStatusExists(StatusID);
        }
        public static bool IsStatusExists(string Status)
        {
            return clsAppointmentStatusDataAccessLayer.IsStatusExists(Status);
        }

        public static DataView GetAllStatus()
        {
            return clsAppointmentStatusDataAccessLayer.GetAllStatus();
        }

        public static DataView GetAllStatusName()
        {
            return clsAppointmentStatusDataAccessLayer.GetAllStatusName();
        }

    }
}
