using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BlogMain.Models
{
    public class ToDBComments
    {
        public MainPost GetPostAndComments(int PostID)
        {
            MainPost RetPost = new MainPost();

            var connect = new SqlConnection(ConfigurationManager.ConnectionStrings["mssql"].ConnectionString);
            connect.Open();
            var command = new SqlCommand(String.Format("select * from Post where PostID = {0}", PostID));
            command.Connection = connect;
            var reader = command.ExecuteReader();
            if (reader.Read())
            {
                RetPost.Post.Title = reader["Title"].ToString();
                RetPost.Post.Text = reader["Text"].ToString();
                RetPost.Post.Id = Convert.ToInt32(reader["PostID"].ToString());
                RetPost.Post.Data = DateTime.Parse(reader["Date"].ToString());
            }
            connect.Dispose();
            command.Dispose();
            reader.Dispose();

            var connect2 = new SqlConnection(ConfigurationManager.ConnectionStrings["mssql"].ConnectionString);
            connect2.Open();
            var command2 = new SqlCommand(String.Format("select * from Comments where PostID = {0}", PostID));
            command2.Connection = connect2;
            var reader2 = command2.ExecuteReader();
            while (reader2.Read())
            {
                Comment obj = new Comment();
                obj.Text = reader2["Text"].ToString();
                obj.Name = reader2["Name"].ToString();
                obj.Data = DateTime.Parse(reader2["Date"].ToString());
                obj.CommentId = Convert.ToInt32(reader2["CommentId"].ToString());
                obj.PostId = PostID;
                RetPost.ColCom.CommentItems.Add(obj);
            }
            connect2.Dispose();
            command2.Dispose();
            reader2.Dispose();
            return RetPost;
        }
    }
}