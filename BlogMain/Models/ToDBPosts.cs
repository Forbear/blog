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

            var connect3 = new SqlConnection(ConfigurationManager.ConnectionStrings["mssql"].ConnectionString);
            connect3.Open();
            var command3 = new SqlCommand(String.Format("select * from Post WHERE PostID > 0 ORDER by Date  DESC"));
            command3.Connection = connect3;
            var reader3 = command3.ExecuteReader();
            int r = 0;
            while (reader3.Read() && r < 3)
            {
                Post PostObj = new Post();
                PostObj.Title = reader3["Title"].ToString();
                PostObj.Id = Convert.ToInt32(reader3["PostID"].ToString()); ;
                r++;
                RetPost.ColPost.PostItems.Add(PostObj);
            }
            connect3.Dispose();
            command3.Dispose();
            reader3.Dispose();
            return RetPost;
        }
    }
}