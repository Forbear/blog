using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BlogMain.Models
{
    public class DellPost
    {
        public void DellOldPost(int PostID)
        {
            //DateTime date = DateTime.Now;
            using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["mssql"].ConnectionString))
            {
                using (var sqlCommand = new SqlCommand(@"delete from Comments where PostID = @PostID"))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("PostID", PostID));
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                
                using (var sqlCommand2 = new SqlCommand(@"delete from Post where PostId = @PostID"))
                {
                    sqlCommand2.Parameters.Add(new SqlParameter("PostID", PostID));
                    sqlCommand2.Connection = sqlConnection;
                    sqlConnection.Open();
                    sqlCommand2.ExecuteNonQuery();
                }
            }
        }
    }
}