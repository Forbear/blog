using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogMain.Models;

namespace BlogMain.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index(int? PostID)
        {
            var read = new ToDBPosts();
            if (PostID > 200 || PostID < 1) PostID = 1;
            return View(read.GetPost(Convert.ToInt32(PostID)));
        }

        [HttpGet]
        public ActionResult FullPost(int? PostID)
        {
            var read = new ToDBComments();
            if (PostID > 200 || PostID < 1) PostID = 1;
            return View(read.GetPostAndComments(Convert.ToInt32(PostID)));
        }

        [HttpPost]
        public ActionResult FullPost(string Comment, string Name, int PostID=2)
        {
            var read = new ToDBPosts();
            if (PostID > 200 || PostID < 1) PostID = 1;
            return View(read.GetPost(PostID));
        }
    }
}
