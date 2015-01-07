using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMain.Models
{
    public class Post
    {
        public Post(string text = "Post deleted", string title = "Post deleted", int id = 0)
        {
            Id = id;
            Text = text;
            Title = title;
            Data = DateTime.Now;
        }
        public int Id { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
        public DateTime Data { get; set; }
    }
}