using MVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVCDemo.DAL
{
    public class RegisterDataAccessLayer
    {
        public string SignUpUser(UserModel model)
        {
            SqlConnection connection = new SqlConnection("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=MVCDemo;Integrated Security=True");
            try
            {
                SqlCommand command = new SqlCommand("proc_RegisterUser", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserName", model.UserName);
                command.Parameters.AddWithValue("@Mobile", model.Mobile);
                command.Parameters.AddWithValue("@Email", model.Email);
                command.Parameters.AddWithValue("@Password", model.Password);
                command.Parameters.AddWithValue("@Gender", model.Gender);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                return ("Data Save Successfully");
            }
            catch(Exception ex)
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                return (ex.Message.ToString());
            }
        }
    }
}