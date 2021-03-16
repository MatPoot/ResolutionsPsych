using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PsychApp.Pages
{
    public class BookAppointmentModel : PageModel
    {
        [BindProperty]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [BindProperty]
        [DataType(DataType.Time)]
        public TimeSpan Time { get; set; }

        //public List<SelectListItem> AvailableTimes { get; set; }

        [BindProperty]
        public string TimeSelected { get; set; }


        [BindProperty]
        public string FirstName { get; set; }

        [BindProperty]
        public string MiddleName { get; set; }

        [BindProperty]
        public string LastName { get; set; }

        [BindProperty]
        public string Phone { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Address { get; set; }

        [BindProperty]
        public string CounsellorName { get; set; }

        public string Message { get; set; }

        public void OnGet()
        {
            PopulateFields();
            //AvailableTimes = GetAvailableTimes();

        }

        public IActionResult OnPost()
        {
            int clientID = SqlHelper.GetClient(FirstName, MiddleName, LastName);
            int counsellorID;

            SqlCode code;
            if (clientID == -1) //Client doesn't exist
            {
                System.Diagnostics.Debug.WriteLine("Client doesn't exist");
                //client doesn't exist, so insert a new client into the database
                code = SqlHelper.CreateClient(GetClient());
                if (code == SqlCode.Failure)
                {
                    System.Diagnostics.Debug.WriteLine("Failed to create client");

                    Message = "Failed to create client";
                    return Page();
                }

            }

            //client now exists
            clientID = SqlHelper.GetClient(FirstName, MiddleName, LastName);
            counsellorID = SqlHelper.GetCounsellor(CounsellorName);

            if (counsellorID == -1)
            {
                Message = "That counsellor doesn't exist";
                return Page();
            }

            System.Diagnostics.Debug.WriteLine($"TimeSelected: {TimeSelected}");
            //TimeSpan appointmentTime = TimeSpan.Parse(TimeSelected);
            //DateTime appointmentDateTime = Date.Add(appointmentTime);
            DateTime appointmentDateTime = Date.Add(Time);

            Classes.Appointments newAppointment = new Classes.Appointments()
            {
                AppointmentDate = appointmentDateTime,
                ClientID = clientID,
                CounsellorID = counsellorID
            };

            code = SqlHelper.BookSQL(newAppointment);

            if (code == SqlCode.Failure)
            {
                Message = "Failed to create appointment";
                return Page();
            }

            return new RedirectToPageResult("Index");
        }

        int GetClientID()
        {
            return 1;
        }

        #region Helper Methods
        private Classes.Client GetClient()
        {
            Classes.Client newClient = new Classes.Client()
            {
                FirstName = this.FirstName,
                MiddleName = this.MiddleName,
                LastName = this.LastName,
                Phone = this.Phone,
                Email = this.Email,
                Address = this.Address
            };

            return newClient;
        }

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
            FirstName = "James";
            MiddleName = "Mark";
            LastName = "Dean";
            Address = "1234 56 Street";
            Phone = "(780)-123-4567";
            Email = "abc123@mail.com";
            CounsellorName = "Mangodude";
        }

        #endregion
    }
}
