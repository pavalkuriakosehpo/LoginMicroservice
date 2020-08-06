using Login.Interfaces;
using Login.Models.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Login.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly IConfiguration _configuration;
        public LoginRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public UserAuth UserAuthenticate(string userName, string password, string hno, string requesttype, string fullnameinputfromtc)
        {
            UserAuth userAuth = new UserAuth();
            string connectionstring = _configuration["DataConnection:DefaultConnection"];

            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "[123].[123]";
            cmd.Connection = connection;


            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "@username";
            param1.Value = userName;

            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "@pwd";
            param2.Value = password;

            SqlParameter param6 = new SqlParameter();
            param6.ParameterName = "@hno";
            param6.Value = hno;


            SqlParameter param3 = new SqlParameter();
            param3.ParameterName = "@requesttype";
            param3.Value = requesttype;

            SqlParameter param8 = new SqlParameter();
            param8.ParameterName = "@fullnameinputfromtc";
            param8.Value = fullnameinputfromtc;



            SqlParameter param4 = new SqlParameter();
            param4.ParameterName = "@ok";
            param4.SqlDbType = System.Data.SqlDbType.Int;
            param4.Size = 4000;
            param4.Direction = System.Data.ParameterDirection.Output;

            SqlParameter param5 = new SqlParameter();
            param5.ParameterName = "@err";
            param5.SqlDbType = System.Data.SqlDbType.VarChar;
            param5.Size = 4000;
            param5.Direction = System.Data.ParameterDirection.Output;

            SqlParameter param7 = new SqlParameter();
            param7.ParameterName = "@fullname";
            param7.SqlDbType = System.Data.SqlDbType.VarChar;
            param7.Size = 50;
            param7.Direction = System.Data.ParameterDirection.Output;




            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            cmd.Parameters.Add(param6); //hno
            cmd.Parameters.Add(param3);//-- login Only:1 means Login button clicked ; Terms Accepted:2 means Terms accepted button clicked;
            cmd.Parameters.Add(param4);
            cmd.Parameters.Add(param5);
            cmd.Parameters.Add(param7);
            cmd.Parameters.Add(param8);


            try
            {
                cmd.ExecuteNonQuery();
                userAuth.Ok = param4.Value != null ? int.Parse(param4.Value.ToString()) : 0;
                userAuth.Error = param5.Value != null ? param5.Value.ToString() : "";
                userAuth.Fullname = param7.Value != null ? param7.Value.ToString() : "";

            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
            }
            finally
            {
                connection.Close();
            }


            return userAuth;
        }

        public async Task<UserAuth> UserAuthenticateAsync(string userName, string password, string hno, string requesttype, string fullnameinputfromtc)
        {
            return await Task.Run(() => UserAuthenticate(userName, password, hno, requesttype, fullnameinputfromtc));
        }


        public async Task<UserAuth> UserAuthenticate2Async(string userName, string password, string hno, string requesttype, string fullnameinputfromtc)
        {
            UserAuth userAuth = new UserAuth();
            string connectionstring = _configuration["DataConnection:DefaultConnection"];

            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "[123].[123]";
            cmd.Connection = connection;


            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "@username";
            param1.Value = userName;

            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "@pwd";
            param2.Value = password;

            SqlParameter param6 = new SqlParameter();
            param6.ParameterName = "@hno";
            param6.Value = hno;


            SqlParameter param3 = new SqlParameter();
            param3.ParameterName = "@requesttype";
            param3.Value = requesttype;

            SqlParameter param8 = new SqlParameter();
            param8.ParameterName = "@fullnameinputfromtc";
            param8.Value = fullnameinputfromtc;



            SqlParameter param4 = new SqlParameter();
            param4.ParameterName = "@ok";
            param4.SqlDbType = System.Data.SqlDbType.Int;
            param4.Size = 4000;
            param4.Direction = System.Data.ParameterDirection.Output;

            SqlParameter param5 = new SqlParameter();
            param5.ParameterName = "@err";
            param5.SqlDbType = System.Data.SqlDbType.VarChar;
            param5.Size = 4000;
            param5.Direction = System.Data.ParameterDirection.Output;

            SqlParameter param7 = new SqlParameter();
            param7.ParameterName = "@fullname";
            param7.SqlDbType = System.Data.SqlDbType.VarChar;
            param7.Size = 50;
            param7.Direction = System.Data.ParameterDirection.Output;




            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            cmd.Parameters.Add(param6); //hno
            cmd.Parameters.Add(param3);//-- login Only:1 means Login button clicked ; Terms Accepted:2 means Terms accepted button clicked;
            cmd.Parameters.Add(param4);
            cmd.Parameters.Add(param5);
            cmd.Parameters.Add(param7);
            cmd.Parameters.Add(param8);


            try
            {
                await cmd.ExecuteNonQueryAsync();
                userAuth.Ok = param4.Value != null ? int.Parse(param4.Value.ToString()) : 0;
                userAuth.Error = param5.Value != null ? param5.Value.ToString() : "";
                userAuth.Fullname = param7.Value != null ? param7.Value.ToString() : "";

            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
            }
            finally
            {
                connection.Close();
            }


            return userAuth;
        }

    }
}
