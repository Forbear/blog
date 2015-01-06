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
            Post = new Post();
        }
        public Post Post { get; set; }
        public string Url { get; set; }
        public CollectionPost ColPost { get; set; }
        public CollectionComment ColCom { get; set; }
    }
}