using Microsoft.AspNetCore.Mvc;
using ResolutionsPsych.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ResolutionsPsych.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CounsellorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public SqlCode CreateCounsellor([FromBody] Classes.Counsellor Counsellor)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Util.GetConnectionString();
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "CreateCounsellor";

            SqlParameter parameter = new SqlParameter
            {
                ParameterName = "@Name",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = Counsellor.Name
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
        public SqlCode UpdateCounsellor([FromBody] Counsellor Counsellor)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Util.GetConnectionString();
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "UpdateCounsellor";

            SqlParameter parameter = new SqlParameter
            {
                ParameterName = "@CounsellorID",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = Counsellor.CounsellorID
            };
            command.Parameters.Add(parameter);

            parameter = new SqlParameter
            {
                ParameterName = "@Name",
                SqlDbType = SqlDbType.DateTime,
                Direction = ParameterDirection.Input,
                SqlValue = Counsellor.Name
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
        [HttpDelete("{id}")]
        public SqlCode DeleteCounsellor(int CounsellorID)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Util.GetConnectionString();
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "UpdateCounsellor";

            SqlParameter parameter = new SqlParameter
            {
                ParameterName = "@CounsellorID",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = CounsellorID
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
        [HttpDelete("{id}")]
        public int GetCounsellor(string CounsellorName)
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
        [HttpGet]
        public List<Counsellor> GetCounsellors()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Util.GetConnectionString();
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "GetCounsellors";

            List<Classes.Counsellor> counsellors = new List<Classes.Counsellor>();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Classes.Counsellor counsellor = new Classes.Counsellor()
                {
                    CounsellorID = int.Parse(reader["CounsellorID"].ToString()),
                    Name = reader["Name"].ToString()
                };
                counsellors.Add(counsellor);
            }

            return counsellors;
        }
    }
}
