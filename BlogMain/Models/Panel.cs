using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BlogMain.Models
{
    public class Panel
    {
        public MainPost AdminPanel()
        {
            MainPost RetPost = new MainPost();
            return RetPost;
        }
    }
}