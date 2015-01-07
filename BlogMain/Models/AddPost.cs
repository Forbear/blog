using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BlogMain.Models
{
    public class AddPost
    {
        public void AddNewPost(string title, string text)
        {
            DateTime date = DateTime.Now;
            using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["mssql"].ConnectionString))
            {
                using (var sqlCommand = new SqlCommand(@"INSERT INTO Post values(@Text, @Title, @date)"))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("Text", text));
                    sqlCommand.Parameters.Add(new SqlParameter("date", date));
                    sqlCommand.Parameters.Add(new SqlParameter("Title", title));
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }
    }
}