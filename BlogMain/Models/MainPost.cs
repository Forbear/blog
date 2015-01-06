using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        }
        public Post Post { get; set; }
        public CollectionPost AllPosts { get; set; }
        public CollectionPost ColPost { get; set; }
        public CollectionComment ColCom { get; set; }
        public CollectionComment LastCom { get; set; }
    }
}