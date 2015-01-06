using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMain.Models
{
    public class Comment
    {
        public Comment(
            DateTime data,
            string name = "Steve",
            string text = "Phasellus mattis tellus eu risusLorem ipsum dolor sit amet, consectetur adipiscing elit.",
            int id = 0
            )
        {
            Id = id;
            Name = name;
            Text = text;
            Data = data;
        }

        public Comment()
        {
            Data = DateTime.Now;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime Data { get; set; }
    }
}