using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ResolutionsPsych.Pages
{
    public class UpdateAppointmentModel : PageModel
    {
        [BindProperty, DataType(DataType.Date), Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }

        [BindProperty, DataType(DataType.Time), Required(ErrorMessage = "Time is required")]
        public TimeSpan Time { get; set; }

        [BindProperty]
        public string TimeSelected { get; set; }

        [BindProperty]
        public int AppointmentID { get; set; }

        [BindProperty, Required(ErrorMessage = "Client ID is required"), RegularExpression(@"^[0-9]+$", ErrorMessage = "Client ID must be a number")]
        public int ClientID { get; set; }

        [BindProperty, Required(ErrorMessage = "Counsellor ID is required"), RegularExpression(@"^[0-9]+$", ErrorMessage = "Counsellor ID must be a number")]
        public int CounsellorID { get; set; }

        [BindProperty]
        public string Notes { get; set; }

        public string Message { get; set; }

        public void OnGet()
        {
            PopulateFields();
       
        }

        public IActionResult OnPost()
        {
           
            SqlCode code;

            System.Diagnostics.Debug.WriteLine($"TimeSelected: {TimeSelected}");
            //TimeSpan appointmentTime = TimeSpan.Parse(TimeSelected);
            //DateTime appointmentDateTime = Date.Add(appointmentTime);
            DateTime appointmentDateTime = Date.Add(Time);


            Classes.Appointments appointment = new Classes.Appointments()
            {
                AppointmentID = AppointmentID,
                AppointmentDate = appointmentDateTime,
                ClientID = ClientID,
                CounsellorID = CounsellorID,
                Notes = Notes
            };

            code = SqlHelper.UpdateAppointment(appointment);

            if (code == SqlCode.Failure)
            {
                Message = "Failed to Update appointment";
                return Page();
            }

            return new RedirectToPageResult("ViewAppointments");
        }

    
        #region Helper Methods


        private List<SelectListItem> GetAvailableTimes()
        {
            List<TimeSpan> times = new List<TimeSpan>();
            TimeSpan startTime = new TimeSpan(8, 0, 0); //8 AM
            TimeSpan endTime = new TimeSpan(16, 0, 0);  //4 PM

            for (TimeSpan time = startTime; time < endTime; time += new TimeSpan(0, 30, 0))
            {
                times.Add(time);
            }

            List<SelectListItem> selectListTimes = new List<SelectListItem>();
            foreach (TimeSpan time in times)
            {
                SelectListItem newItem = new SelectListItem()
                {
                    Text = TimeSpanToString(time),
                    Value = time.ToString()
                };

                selectListTimes.Add(newItem);
            }

            return selectListTimes;
        }

        private string TimeSpanToString(TimeSpan time)
        {
            int hours;
            int minutes;
            bool isAM;

            if (time.Hours < 12)
            {
                isAM = true;
                hours = time.Hours;
            }
            else
            {
                isAM = false;
                hours = time.Hours - 12;
            }

            minutes = time.Minutes;

            if (hours == 0)
                hours = 12;

            string timeString = $"{hours}:{minutes.ToString().PadLeft(2, '0')} ";

            if (isAM)
                timeString += "AM";
            else
                timeString += "PM";

            return timeString;
        }

        private void PopulateFields()
        {
            Date = DateTime.Now;
            Time = new TimeSpan(8, 0, 0);
           
        }

        #endregion
    }
}
