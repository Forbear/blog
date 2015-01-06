using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace BlogMain.Models
{
    public class CollectionPost
    {
        public CollectionPost()
        {
            PostItems = new Collection<Post>();
        }
        public ICollection<Post> PostItems { get; set; }
    }
}