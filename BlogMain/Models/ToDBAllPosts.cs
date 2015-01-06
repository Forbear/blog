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

            var connect4 = new SqlConnection(ConfigurationManager.ConnectionStrings["mssql"].ConnectionString);
            connect4.Open();
            var command4 = new SqlCommand(String.Format("select * from Comments WHERE PostID > 0 ORDER by Date  DESC"));
            command4.Connection = connect4;
            var reader4 = command4.ExecuteReader();
            r = 0;
            while (reader4.Read() && r < 3)
            {
                Comment ComObj = new Comment();
                ComObj.Name = reader4["Name"].ToString();
                ComObj.Text = reader4["Text"].ToString();
                ComObj.Data = DateTime.Parse(reader4["Date"].ToString());
                ComObj.PostId = Convert.ToInt32(reader4["PostID"].ToString());
                RetPost.LastCom.CommentItems.Add(ComObj);
                r++;
            }
            connect4.Dispose();
            command4.Dispose();
            reader4.Dispose();
            return RetPost;
        }
        
    }
}