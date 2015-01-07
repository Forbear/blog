using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BlogMain.Models
{
    public class ToDBAllPosts
    {
        public MainPost GetAllPosts()
        {
            MainPost RetPost = new MainPost();

            var connect = new SqlConnection(ConfigurationManager.ConnectionStrings["mssql"].ConnectionString);
            connect.Open();
            var command = new SqlCommand(String.Format("select * from Post where PostID > 0 ORDER by Date  DESC"));
            command.Connection = connect;
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Post PostObj = new Post();
                PostObj.Id = Convert.ToInt32(reader["PostID"].ToString());
                PostObj.Title = reader["Title"].ToString();
                PostObj.Text = reader["Text"].ToString();
                PostObj.Data = DateTime.Parse(reader["Date"].ToString());
                RetPost.AllPosts.PostItems.Add(PostObj);
            }
            reader.Dispose();
            command.Dispose();
            connect.Dispose();
            return RetPost;
        }
        
    }
}