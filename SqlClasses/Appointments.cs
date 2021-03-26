using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ResolutionsPsych.SqlClasses
{
    public class Appointments
    {
        public SqlCode CreateAppointment(Classes.Appointment Appointment)
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

        public SqlCode UpdateAppointment(Classes.Appointment Appointment)
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
                SqlValue = Appointment.AppointmentID
            };
            command.Parameters.Add(parameter);

            parameter = new SqlParameter
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

        public SqlCode DeleteAppoinment(int AppointmentID)
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

        public List<Classes.Appointment> GetAppointments()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Util.GetConnectionString();
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "GetAppointments";

            List<Classes.Appointment> appointments = new List<Classes.Appointment>();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Classes.Appointment newAppt = new Classes.Appointment()
                {
                    AppointmentID = int.Parse(reader["AppointmentID"].ToString()),
                    AppointmentDate = DateTime.Parse(reader["AppointmentDate"].ToString()),
                    ClientID = int.Parse(reader["ClientID"].ToString()),
                    CounsellorID = int.Parse(reader["CounsellorID"].ToString()),
                    Notes = reader["Notes"].ToString(),
                };

                appointments.Add(newAppt);
            }

            return appointments;
        }

        public List<Classes.Appointment> GetAppointmentsByClient(int ClientID)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Util.GetConnectionString();
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "GetAppointmentsByClient";

            SqlParameter parameter = new SqlParameter
            {
                ParameterName = "@ClientID",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = ClientID
            };
            command.Parameters.Add(parameter);

            List<Classes.Appointment> appointments = new List<Classes.Appointment>();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Classes.Appointment newAppt = new Classes.Appointment()
                {
                    AppointmentID = int.Parse(reader["AppointmentID"].ToString()),
                    AppointmentDate = DateTime.Parse(reader["AppointmentDate"].ToString()),
                    ClientID = int.Parse(reader["ClientID"].ToString()),
                    CounsellorID = int.Parse(reader["CounsellorID"].ToString()),
                    Notes = reader["Notes"].ToString(),
                };

                appointments.Add(newAppt);
            }

            return appointments;
        }
    }
}
