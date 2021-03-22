using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResolutionsPsych
{
    public class ResolutionsSystem
    {
        #region Appointments

        public SqlCode BookAppointment(Classes.Appointments Appointment)
        {
            SqlCode code = SqlHelper.BookSQL(Appointment);
            return code;
        }

        public SqlCode UpdateAppointment(Classes.Appointments Appointment)
        {
            SqlCode code = SqlHelper.UpdateAppointment(Appointment);
            return code;
        }

        public SqlCode DeleteAppointment(int AppointmentID)
        {
            SqlCode code = SqlHelper.DeleteAppoinment(AppointmentID);
            return code;
        }

        #endregion
    }
}
