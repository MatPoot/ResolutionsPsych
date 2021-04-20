using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ResolutionsPsych.SqlClasses
{
    public class Clients
    {
        public SqlCode CreateClient(Classes.Client Client)
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

        public SqlCode UpdateClient(Classes.Client Client)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Util.GetConnectionString();
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "UpdateClient";

            SqlParameter parameter = new SqlParameter
            {
                ParameterName = "@ClientID",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = (int)Client.ClientID
            };
            command.Parameters.Add(parameter);

            parameter = new SqlParameter
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

        public SqlCode DeleteClient(Classes.Client Client)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Util.GetConnectionString();
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            //command.CommandText = "SoftDeleteClient"; Soft delete = not removed from db?
            command.CommandText = "DeleteClient";

            SqlParameter parameter = new SqlParameter
            {
                ParameterName = "@ClientID",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = (int)Client.ClientID
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

        public List<Classes.Client> GetClients()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Util.GetConnectionString();
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "GetClients";

            List<Classes.Client> clients = new List<Classes.Client>();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Classes.Client client = new Classes.Client()
                {
                    ClientID = int.Parse(reader["ClientID"].ToString()),
                    FirstName = reader["FirstName"].ToString(),
                    MiddleName = reader["MiddleName"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    Email = reader["Email"].ToString(),
                    Phone = reader["Phone"].ToString(),
                    Address = reader["Address"].ToString()
                };

                clients.Add(client);
            }

            return clients;
        }

        public Classes.Client GetClientByID(int ClientID)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Util.GetConnectionString();
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "GetClientByID";

            SqlParameter parameter = new SqlParameter()
            {
                ParameterName = "@ClientID",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = ClientID
            };
            command.Parameters.Add(parameter);

            SqlDataReader reader = command.ExecuteReader();

            Classes.Client client = new Classes.Client();

            reader.Read();
            if (reader.HasRows)
            {
                client = new Classes.Client()
                {
                    ClientID = int.Parse(reader["ClientID"].ToString()),
                    FirstName = reader["FirstName"].ToString(),
                    MiddleName = reader["MiddleName"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    Email = reader["Email"].ToString(),
                    Phone = reader["Phone"].ToString(),
                    Address = reader["Address"].ToString()
                };
            }

            return client;
        }

        public Classes.Client GetClientByName(string FirstName, string MiddleName, string LastName)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Util.GetConnectionString();
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "GetClientByName";

            SqlParameter parameter = new SqlParameter()
            {
                ParameterName = "@FirstName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = FirstName
            };
            command.Parameters.Add(parameter);

            parameter = new SqlParameter()
            {
                ParameterName = "@LastName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = LastName
            };
            command.Parameters.Add(parameter);

            if(MiddleName != string.Empty)
            {
                parameter = new SqlParameter()
                {
                    ParameterName = "@MiddleName",
                    SqlDbType = SqlDbType.VarChar,
                    Direction = ParameterDirection.Input,
                    SqlValue = MiddleName
                };
                command.Parameters.Add(parameter);
            }

            SqlDataReader reader = command.ExecuteReader();
            reader.Read();

            Classes.Client client = new Classes.Client();
            if (reader.HasRows)
            {
                System.Diagnostics.Debug.WriteLine($"Reader[0]: {reader[0].ToString()}");

                int clientID = int.Parse(reader["ClientID"].ToString());
                System.Diagnostics.Debug.WriteLine($"ClientID: {clientID}");
                System.Diagnostics.Debug.WriteLine($"MiddleName: {MiddleName}");
                client = new Classes.Client()
                {
                    ClientID = int.Parse(reader["ClientID"].ToString()),
                    FirstName = reader["FirstName"].ToString(),
                    MiddleName = reader["MiddleName"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    Email = reader["Email"].ToString(),
                    Phone = reader["Phone"].ToString(),
                    Address = reader["Address"].ToString()
                };
            }

            return client;
        }

        
    }
}
