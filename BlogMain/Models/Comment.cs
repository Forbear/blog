using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BlogMain.Models
{
    public class Comment
    {
        public Comment(DateTime data, string name, string text, int id)
        {
            Name = name;
            Text = text;
            Data = data;
            PostId = id;
        }

        public Comment()
        {
            Data = DateTime.Now;
        }
        public void AddComment(string name, string text, int PostID)
        {
            DateTime date = DateTime.Now;
            using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["mssql"].ConnectionString))
            {
                using (var sqlCommand = new SqlCommand(@"INSERT INTO Comments
                SELECT @title, @Text, @date, @PostID AS MyPost 
                FROM Post 
                WHERE PostID = @PostID"))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("Text", text));
                    sqlCommand.Parameters.Add(new SqlParameter("date", date));
                    sqlCommand.Parameters.Add(new SqlParameter("title", name));
                    sqlCommand.Parameters.Add(new SqlParameter("PostID", PostID));
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }
        public int PostId { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime Data { get; set; }
    }
}