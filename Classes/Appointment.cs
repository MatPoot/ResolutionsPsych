using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResolutionsPsych.Classes
{
    public class Appointment
    {
        //public string ClientName, CounsellorName, Notes;
        public int AppointmentID;
        public DateTime AppointmentDate;
        public int ClientID;
        public int CounsellorID;
        public string Notes;
        
        public void Print()
        {
            System.Diagnostics.Debug.WriteLine($"AppointmentID: {AppointmentID}");
            System.Diagnostics.Debug.WriteLine($"AppointmentDate: {AppointmentDate}");
            System.Diagnostics.Debug.WriteLine($"ClientID: {ClientID}");
            System.Diagnostics.Debug.WriteLine($"CounsellorID: {CounsellorID}");
            System.Diagnostics.Debug.WriteLine($"Notes: {Notes}");
        }

    }
}
