﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PsychApp
{
    public static class SqlHelper
    {
        #region Appointments
        public static SqlCode BookSQL(Classes.Appointments Appointment)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Util.GetConnectionString();
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "CreateAppointment";

            SqlParameter parameter = new SqlParameter
            {
                ParameterName = "@AppointmentDate",
                SqlDbType = SqlDbType.DateTime,
                Direction = ParameterDirection.Input,
                SqlValue = Appointment.AppointmentDate
            };
            command.Parameters.Add(parameter);

            parameter = new SqlParameter
            {
                ParameterName = "@ClientID",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = Appointment.ClientID
            };
            command.Parameters.Add(parameter);

            parameter = new SqlParameter
            {
                ParameterName = "@CounsellorID",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = Appointment.CounsellorID
            };
            command.Parameters.Add(parameter);

            parameter = new SqlParameter
            {
                ParameterName = "@Notes",
                SqlDbType = SqlDbType.NText,
                Direction = ParameterDirection.Input,
                SqlValue = Appointment.Notes
            };
            command.Parameters.Add(parameter);

            int returnVal;
            SqlCode code;
            try
            {
                returnVal = command.ExecuteNonQuery();
                code = SqlCode.Success;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine($"e: {e.Message}");
                code = SqlCode.Failure;
            }

            connection.Close();
            return code;
        }

        public static SqlCode UpdateAppointment(int appointmentid, DateTime appointmentDate,int clientID, int counsellorID, string notes)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Util.GetConnectionString();
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "UpdateAppointment";

            SqlParameter parameter = new SqlParameter
            {
                ParameterName = "@AppointmentID",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = appointmentid
            };
            command.Parameters.Add(parameter);

             parameter = new SqlParameter
            {
                ParameterName = "@AppointmentDate",
                SqlDbType = SqlDbType.DateTime,
                Direction = ParameterDirection.Input,
                SqlValue = appointmentDate
             };
            command.Parameters.Add(parameter);

            parameter = new SqlParameter
            {
                ParameterName = "@ClientID",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = clientID
            };
            command.Parameters.Add(parameter);

            parameter = new SqlParameter
            {
                ParameterName = "@CounsellorID",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = counsellorID
            };
            command.Parameters.Add(parameter);

            parameter = new SqlParameter
            {
                ParameterName = "@Notes",
                SqlDbType = SqlDbType.NText,
                Direction = ParameterDirection.Input,
                SqlValue = notes
            };
            command.Parameters.Add(parameter);

            int returnVal;
            SqlCode code;
            try
            {
                returnVal = command.ExecuteNonQuery();
                code = SqlCode.Success;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine($"e: {e.Message}");
                code = SqlCode.Failure;
            }

            connection.Close();
            return code;
        }

        public static SqlCode DeleteAppoinment(int AppointmentID)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Util.GetConnectionString();
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "DeleteAppointment";

            SqlParameter param = new SqlParameter
            {
                ParameterName = "@AppointmentID",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = AppointmentID
            };
            command.Parameters.Add(param);

            int returnVal;
            SqlCode code;
            try
            {
                returnVal = command.ExecuteNonQuery();
                code = SqlCode.Success;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine($"e: {e.Message}");
                code = SqlCode.Failure;
            }

            connection.Close();
            return code;
        }

        public static List<Classes.Appointments> GetAppointments()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Util.GetConnectionString();
            connection.Open();

            string query = $"SELECT * FROM Appointments";

            SqlCommand command = new SqlCommand(query, connection);
            List<Classes.Appointments> appointments = new List<Classes.Appointments>();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Classes.Appointments newAppt = new Classes.Appointments()
                {
                    AppointmentID = int.Parse(reader[0].ToString()),
                    AppointmentDate = DateTime.Parse(reader[1].ToString()),
                    ClientID = int.Parse(reader[2].ToString()),
                    CounsellorID = int.Parse(reader[3].ToString()),
                    Notes = reader[4].ToString(),
                };

                appointments.Add(newAppt);
            }

            return appointments;
        }
        #endregion

        #region Logins
        public static Classes.Login GetLogin(string Username)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Util.GetConnectionString();

            System.Diagnostics.Debug.WriteLine($"Connection string: {connection.ConnectionString}");
            connection.Open();

            string query = $"SELECT * FROM Logins WHERE Username = '{Username}'";

            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();

            string retrievedRole = string.Empty;
            string retrievedUsername = string.Empty;

            Classes.Login login = new Classes.Login();
            if (reader.HasRows)
            {
                reader.Read();

                login.Username = reader[0].ToString();
                login.Password = reader[1].ToString();
                login.StaffType = reader[2].ToString();
            }

            connection.Close();

            return login;
        }

        #endregion

        #region Clients

        public static SqlCode CreateClient(Classes.Client Client)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Util.GetConnectionString();
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "CreateClient";

            SqlParameter parameter = new SqlParameter
            {
                ParameterName = "@FirstName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = Client.FirstName
            };
            command.Parameters.Add(parameter);

            parameter = new SqlParameter
            {
                ParameterName = "@MiddleName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = Client.MiddleName
            };
            command.Parameters.Add(parameter);

            parameter = new SqlParameter
            {
                ParameterName = "@LastName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = Client.LastName
            };
            command.Parameters.Add(parameter);

            parameter = new SqlParameter
            {
                ParameterName = "@Email",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = Client.Email
            };
            command.Parameters.Add(parameter);

            parameter = new SqlParameter
            {
                ParameterName = "@Phone",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = Client.Phone
            };
            command.Parameters.Add(parameter);

            parameter = new SqlParameter
            {
                ParameterName = "@Address",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = Client.Address
            };
            command.Parameters.Add(parameter);

            int returnVal;
            SqlCode code;
            try
            {
                returnVal = command.ExecuteNonQuery();
                code = SqlCode.Success;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine($"e: {e.Message}");
                code = SqlCode.Failure;
            }

            connection.Close();
            return code;
        }
        public static int GetClient(string FirstName, string MiddleName, string LastName)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Util.GetConnectionString();
            connection.Open();

            string query;

            if (MiddleName == string.Empty || MiddleName == "" || MiddleName == null)
                query = $"SELECT ClientID FROM Clients WHERE FirstName = '{FirstName}' AND MiddleName IS NULL AND LastName = '{LastName}'";
            else
                query = $"SELECT ClientID FROM Clients WHERE FirstName = '{FirstName}' AND MiddleName = '{MiddleName}' AND LastName = '{LastName}'";


            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();

            int clientID = -1;
            while (reader.Read())
            {
                clientID = int.Parse(reader[0].ToString());

            }

            return clientID;
        }
        #endregion

        #region Counsellors
        public static int GetCounsellor(string CounsellorName)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Util.GetConnectionString();
            connection.Open();

            string query = $"SELECT * FROM Counsellors WHERE Name = '{CounsellorName}'";

            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();

            int counsellorID = -1;

            while (reader.Read())
            {
                int.TryParse(reader[0].ToString(), out counsellorID);
            }

            return counsellorID;
        }
        #endregion
    }
}
