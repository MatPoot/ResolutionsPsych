using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResolutionsPsych
{
    public class ResolutionsSystem
    {
        #region Appointments

        public SqlCode BookAppointment(Classes.Appointment Appointment)
        {
            SqlClasses.Appointments appHelper = new SqlClasses.Appointments();
            SqlCode code = appHelper.CreateAppointment(Appointment);
            return code;
        }

        public SqlCode UpdateAppointment(Classes.Appointment Appointment)
        {
            SqlClasses.Appointments appHelper = new SqlClasses.Appointments();
            SqlCode code = appHelper.UpdateAppointment(Appointment);
            return code;
        }

        public SqlCode DeleteAppointment(int AppointmentID)
        {
            SqlClasses.Appointments appHelper = new SqlClasses.Appointments();
            SqlCode code = appHelper.DeleteAppoinment(AppointmentID);
            return code;
        }

        public List<Classes.Appointment> GetAppointments()
        {
            SqlClasses.Appointments appHelper = new SqlClasses.Appointments();
            List<Classes.Appointment> appointments = appHelper.GetAppointments();
            return appointments;
        }

        #endregion

        #region Clients
        public SqlCode CreateClient(Classes.Client Client)
        {
            SqlClasses.Clients clientHelper = new SqlClasses.Clients();
            SqlCode code = clientHelper.CreateClient(Client);
            return code;
        }

        public SqlCode DeleteClient(Classes.Client Client)
        {
            SqlClasses.Clients clientHelper = new SqlClasses.Clients();
            SqlCode code = clientHelper.DeleteClient(Client);
            return code;
        }

        public Classes.Client GetClient(int ClientID)
        {
            SqlClasses.Clients clientHelper = new SqlClasses.Clients();
            Classes.Client client = clientHelper.GetClientByID(ClientID);
            return client;
        }

        public Classes.Client GetClient(string FirstName, string LastName)
        {
            SqlClasses.Clients clientHelper = new SqlClasses.Clients();
            Classes.Client client = clientHelper.GetClientByName(FirstName, string.Empty, LastName);
            return client;
        }

        public Classes.Client GetClient(string FirstName, string MiddleName, string LastName)
        {
            SqlClasses.Clients clientHelper = new SqlClasses.Clients();
            Classes.Client client = clientHelper.GetClientByName(FirstName, MiddleName, LastName);
            return client;
        }

        public List<Classes.Client> GetClients()
        {
            SqlClasses.Clients clientHelper = new SqlClasses.Clients();
            List<Classes.Client> clients = clientHelper.GetClients();
            return clients;
        }

        #endregion

        #region Counsellors
        public SqlCode CreateCounsellor(Classes.Counsellor Counsellor)
        {
            SqlClasses.Counsellors counsellorHelper = new SqlClasses.Counsellors();
            SqlCode code = counsellorHelper.CreateCounsellor(Counsellor);
            return code;
        }

        public SqlCode UpdateCounsellor(Classes.Counsellor Counsellor)
        {
            SqlClasses.Counsellors counsellorHelper = new SqlClasses.Counsellors();
            SqlCode code = counsellorHelper.UpdateCounsellor(Counsellor);
            return code;
        }

        public SqlCode DeleteCounsellor (int CounsellorID)
        {
            SqlClasses.Counsellors counsellorHelper = new SqlClasses.Counsellors();
            SqlCode code = counsellorHelper.DeleteCounsellor(CounsellorID);
            return code;
        }

        public List<Classes.Counsellor> GetCounsellors()
        {
            SqlClasses.Counsellors counsellorHelper = new SqlClasses.Counsellors();
            List<Classes.Counsellor> counsellors = counsellorHelper.GetCounsellors();
            return counsellors;
        }
        #endregion

        #region Logins
        public SqlCode CreateLogin(Classes.Login Login)
        {
            SqlClasses.Logins loginHelper = new SqlClasses.Logins();
            SqlCode code = loginHelper.CreateLogin(Login);
            return code;
        }

        public SqlCode UpdateLogin(Classes.Login Login)
        {
            SqlClasses.Logins loginHelper = new SqlClasses.Logins();
            SqlCode code = loginHelper.UpdateLogin(Login);
            return code;
        }

        public SqlCode DeleteLogin(string Username)
        {
            SqlClasses.Logins loginHelper = new SqlClasses.Logins();
            SqlCode code = loginHelper.DeleteLogin(Username);
            return code;
        }

        public Classes.Login GetLogin(string Username)
        {
            SqlClasses.Logins loginHelper = new SqlClasses.Logins();
            Classes.Login login = loginHelper.GetLogin(Username);
            return login;
        }

        public List<Classes.Login> GetLogins()
        {
            SqlClasses.Logins loginHelper = new SqlClasses.Logins();
            List<Classes.Login> logins = loginHelper.GetLogins();
            return logins;
        }
        #endregion
    }
}
