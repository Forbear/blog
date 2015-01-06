using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace BlogMain.Models
{
    public class CollectionComment
    {
        public CollectionComment()
        {
            CommentItems = new Collection<Comment>();
        }
        public void AddItem( DateTime data, string name, string text, int id )
        {
            CommentItems.Add(new Comment(data, name, text, id));
        }
        public ICollection<Comment> CommentItems { get; set; }
    }
}