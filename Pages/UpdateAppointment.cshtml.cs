using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using ResolutionsPsych.Classes;
using Microsoft.AspNetCore.Http;

namespace ResolutionsPsych.Pages
{
    public class UpdateAppointmentModel : PageModel
    {
        //[BindProperty, DataType(DataType.Date), Required(ErrorMessage = "Date is required")]
        //public DateTime Date { get; set; }

        //[BindProperty, DataType(DataType.Time), Required(ErrorMessage = "Time is required")]
        //public TimeSpan Time { get; set; }

        [BindProperty]
        public string TimeSelected { get; set; }

        [BindProperty, Required(ErrorMessage = "AppointmentID is required")]
        public int AppointmentID { get; set; }

        [BindProperty]
        public DateTime AppointmentDate { get; set; }

        [BindProperty]
        public int ClientID { get; set; }

        [BindProperty]
        public string ClientFullName { get; set; }

        [BindProperty]
        public int CounsellorID { get; set; }

        [BindProperty]
        public string Notes { get; set; }

        //[BindProperty]
        //public int SelectedID { get; set; }
        //[BindProperty]
        //public int SelectedClientID { get; set; }
        [BindProperty]
        public string CounsellorName { get; set; }
        //[BindProperty]
        //public string FirstName { get; set; }
        //[BindProperty]
        //public List<SelectListItem> SelectCounsellorList { get; set; }
        //[BindProperty]
        //public List<Counsellor> ListOfCounsellors { get; set; }
        //[BindProperty]
        //public List<SelectListItem> SelectClientList { get; set; }
        //[BindProperty]
        //public List<Client> ListOfClients { get; set; }
        public string Message { get; set; }

        public IActionResult OnGet()
        {
            string username = GetSessionValue("Username");
            if (username == null || username == string.Empty)
                return new RedirectToPageResult("Index");

            int appointmentID = int.Parse(HttpContext.Session.GetString("UpdateAppointmentID"));

            System.Diagnostics.Debug.WriteLine($"UpdateAppointment: Updating appointment: {appointmentID}");
            
            ResolutionsSystem rs = new ResolutionsSystem();
            Classes.Appointment app = rs.GetAppointment(appointmentID);
            AppointmentID = app.AppointmentID;
            AppointmentDate = app.AppointmentDate;

            Classes.Client client = rs.GetClient(app.ClientID);
            ClientID = (int)client.ClientID;
            if(client.MiddleName == null)
                ClientFullName = $"{client.FirstName} {client.LastName}";
            else
                ClientFullName = $"{client.FirstName} {client.MiddleName} {client.LastName}";

            Classes.Counsellor counsellor = rs.GetCounsellor(app.CounsellorID);
            CounsellorID = counsellor.CounsellorID;
            CounsellorName = counsellor.Name;
            //Message = $"Updating appointment {appointmentID}\n" +
            //    $"Date: {app.AppointmentDate}\n" +
            //    $"Client Name: {clientName} ({client.ClientID})\n" +
            //    $"Counsellor: {counsellor.Name} ({counsellor.CounsellorID})";

            System.Diagnostics.Debug.WriteLine($"Updated appointment: {(int)AppointmentID}");
            //PopulateFields(app);

            //counsellors dropdownlist
            //PopulateSelectList();

            
            //ListOfCounsellors = rs.GetCounsellors();

            //client dropdownlist
            //PopulateSelectListForClient();

            //ListOfClients = rs.GetClients();

            return Page();
        }

        public IActionResult OnPost()
        {
            SqlCode code;

            //System.Diagnostics.Debug.WriteLine($"TimeSelected: {TimeSelected}");
            //DateTime appointmentDateTime = Date.Add(Time);

            //counsellorID = SelectedID;
            //clientID = SelectedClientID;

            Classes.Appointment appointment = new Classes.Appointment()
            {
                AppointmentID = (int)AppointmentID,
                AppointmentDate = AppointmentDate,
                ClientID = ClientID,
                CounsellorID = CounsellorID,
                Notes = Notes
            };

            System.Diagnostics.Debug.WriteLine("Displaying updated appointment");
            appointment.Print();

            ResolutionsSystem rs = new ResolutionsSystem();
            code = rs.UpdateAppointment(appointment);

            if (code == SqlCode.Failure)
            {
                Message = "Failed to Update appointment";
                //return Page();
            }

            return new RedirectToPageResult("ViewAppointments");
        }


        #region Helper Methods

        /*
        private void PopulateSelectList()
        {
            ResolutionsSystem rs = new ResolutionsSystem();
            //ListOfCounsellors = rs.GetCounsellors();

            //SelectCounsellorList = new List<SelectListItem>();

            foreach (Counsellor p in ListOfCounsellors)
            {
                SelectListItem item = new SelectListItem()
                {
                    Text = p.Name,
                    Value = p.CounsellorID.ToString()
                };
                SelectCounsellorList.Add(item);
            }
        }
        private void PopulateSelectListForClient()
        {
            ResolutionsSystem rs = new ResolutionsSystem();
            ListOfClients = rs.GetClients();

            SelectClientList = new List<SelectListItem>();

            foreach (Client p in ListOfClients)
            {
                SelectListItem item = new SelectListItem()
                {
                    Text = p.FirstName,
                    Value = p.ClientID.ToString()
                };
                SelectClientList.Add(item);
            }
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
        */

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

        private void PopulateFields(Classes.Appointment Appointment)
        {
            AppointmentID = Appointment.AppointmentID;
            AppointmentDate = Appointment.AppointmentDate;
            Notes = Appointment.Notes;
            //Date = DateTime.Now;
            //Time = new TimeSpan(8, 0, 0);
           
        }

        private string GetSessionValue(string Key)
        {
            byte[] valueArray;
            string valueString;
            HttpContext.Session.TryGetValue(Key, out valueArray);

            if (valueArray != null)
                valueString = Util.ByteArrayToString(valueArray);
            else
                valueString = string.Empty;

            return valueString;
        }

        #endregion
    }
}
