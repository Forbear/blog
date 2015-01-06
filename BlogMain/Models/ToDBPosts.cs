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
        public MainPost GetPost(int PostID)
        {
            MainPost RetPost = new MainPost();
            int Id = 0;
            var connect0 = new SqlConnection(ConfigurationManager.ConnectionStrings["mssql"].ConnectionString);
            connect0.Open();
            var command0 = new SqlCommand(String.Format("SELECT Count(*) as Id from post"));
            command0.Connection = connect0;
            var reader0 = command0.ExecuteReader();
            if (reader0.Read()) Id = Convert.ToInt32(reader0["Id"].ToString());
            reader0.Dispose();
            command0.Dispose();
            connect0.Dispose();

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
                RetPost.Post.Id = Id;
            }
            reader.Dispose();
            command.Dispose();
            connect.Dispose();

            var connect3 = new SqlConnection(ConfigurationManager.ConnectionStrings["mssql"].ConnectionString);
            connect3.Open();
            var command3 = new SqlCommand(String.Format("select Title from Post WHERE PostID > 0 ORDER by Date  DESC"));
            command3.Connection = connect3;
            var reader3 = command3.ExecuteReader();
            int r = 0;
            while (reader3.Read() && r < 3)
            {
                Post PostObj = new Post();
                PostObj.Title = reader3["Title"].ToString();
                PostObj.Id = Id;
                Id--;
                RetPost.ColPost.PostItems.Add(PostObj);
            }
            connect3.Dispose();
            command3.Dispose();
            reader3.Dispose();
            return RetPost;
        }
    }
}