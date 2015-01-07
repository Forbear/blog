using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BlogMain.Models
{
    public class MainPost
    {
        public MainPost()
        {
            ColPost = new CollectionPost();
            ColCom = new CollectionComment();
            LastCom = new CollectionComment();
            AllPosts = new CollectionPost();
            Post = new Post();

            CreateLeftPosts();
            CreateLeftComments();
             
        }

        public void CreateLeftPosts()
        {
            var connect = new SqlConnection(ConfigurationManager.ConnectionStrings["mssql"].ConnectionString);
            connect.Open();
            var command = new SqlCommand(String.Format("select * from Post WHERE PostID > 0 ORDER by Date  DESC"));
            command.Connection = connect;
            var reader = command.ExecuteReader();
            int r = 0;
            while (reader.Read() && r < 3)
            {
                Post PostObj = new Post();
                PostObj.Title = reader["Title"].ToString();
                PostObj.Id = Convert.ToInt32(reader["PostID"].ToString()); ;
                r++;
                ColPost.PostItems.Add(PostObj);
            }
            connect.Dispose();
            command.Dispose();
            reader.Dispose();
        }

        public void CreateLeftComments()
        {
            var connect = new SqlConnection(ConfigurationManager.ConnectionStrings["mssql"].ConnectionString);
            connect.Open();
            var command = new SqlCommand(String.Format("select * from Comments WHERE PostID > 0 ORDER by Date  DESC"));
            command.Connection = connect;
            var reader = command.ExecuteReader();
            int r = 0;
            while (reader.Read() && r < 3)
            {
                Comment ComObj = new Comment();
                ComObj.Name = reader["Name"].ToString();
                ComObj.Text = reader["Text"].ToString();
                ComObj.Data = DateTime.Parse(reader["Date"].ToString());
                ComObj.PostId = Convert.ToInt32(reader["PostID"].ToString());
                LastCom.CommentItems.Add(ComObj);
                r++;
            }
            connect.Dispose();
            command.Dispose();
            reader.Dispose();
        }

        public Post Post { get; set; }
        public CollectionPost AllPosts { get; set; }
        public CollectionPost ColPost { get; set; }
        public CollectionComment ColCom { get; set; }
        public CollectionComment LastCom { get; set; }
    }
}