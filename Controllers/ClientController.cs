using Microsoft.AspNetCore.Mvc;
using ResolutionsPsych.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Encodings.Web;

namespace ResolutionsPsych.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public SqlCode CreateClient([FromBody] Classes.Client Client)
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

        [HttpPost("{id}")]
        public SqlCode UpdateClient([FromBody] Classes.Client Client)
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
        [HttpGet]
        public List<Client> GetClients()
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
        [HttpGet("{id}")]
        public Client GetClientByID(int ClientID)
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
        [HttpGet("{id}")]
        public Client GetClientByName(string FirstName, string? MiddleName, string LastName)
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

            if (MiddleName != null)
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

            Classes.Client client = new Classes.Client();
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


    }
}
