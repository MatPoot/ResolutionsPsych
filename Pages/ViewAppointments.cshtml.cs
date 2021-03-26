using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ResolutionsPsych.Classes;

namespace ResolutionsPsych.Pages
{
    [BindProperties(SupportsGet =true)]
    public class ViewAppointmentsModel : PageModel
    {
        public List<Appointment> ListOfAppointments { get; set; }
       
        public void OnGet()
        {
            /*
            for (int i = 0; i < 4; i++)
            {
                Appointments testobject = new Appointments();
                testobject.AppointmentDate = DateTime.Now;
                testobject.ClientName = "BananaMan";
                testobject.CounsellorName = "BananaCounsellor";
                testobject.Notes = "Banana feels like he's going bad";


                ListOfAppointments.Add(testobject);
                
            }
            */

            // call SQLhelper and get the list of records
            ListOfAppointments = SqlHelper.GetAppointments();

        }
    }
}
