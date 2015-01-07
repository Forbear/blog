using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace BlogMain.Models
{
    public class ToDBPosts
    {
        public MainPost GetPost()
        {
            MainPost RetPost = new MainPost();

            var connect = new SqlConnection(ConfigurationManager.ConnectionStrings["mssql"].ConnectionString);
            connect.Open();
            var command = new SqlCommand(String.Format("select * from Post where PostID > 0 ORDER by Date  DESC"));
            command.Connection = connect;
            var reader = command.ExecuteReader();
            if (reader.Read())
            {
                RetPost.Post.Title = reader["Title"].ToString();
                RetPost.Post.Text = reader["Text"].ToString();
                RetPost.Post.Data = DateTime.Parse(reader["Date"].ToString());
                RetPost.Post.Id = Convert.ToInt32(reader["PostID"].ToString());
            }
            reader.Dispose();
            command.Dispose();
            connect.Dispose();
            return RetPost;
        }
    }
}