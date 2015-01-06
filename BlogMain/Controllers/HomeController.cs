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
            return View(read.GetPost(Convert.ToInt32(PostID)));
        }

        [HttpGet]
        public ActionResult FullPost(int? PostID)
        {
            var read = new ToDBComments();
            return View(read.GetPostAndComments(Convert.ToInt32(PostID)));
        }

        [HttpPost]
        public ActionResult FullPost(string Comment, string Name, int? PostID)
        {
            var read = new ToDBComments();
            Comment obj = new Comment();
            obj.AddComment(Name, Comment, Convert.ToInt32(PostID));
            return View(read.GetPostAndComments(Convert.ToInt32(PostID)));
        }

        [HttpGet]
        public ActionResult AllPosts()
        {
            var read = new ToDBAllPosts();
            return View(read.GetAllPosts());
        }

        [HttpGet]
        public ActionResult AdminPanel()
        {
            var read = new Panel();
            return View(read.AdminPanel());
        }

        [HttpPost]
        public ActionResult AdminPanel(string Comment, string Name)
        {
            var read = new Panel();
            AddPost obj = new AddPost();
            obj.AddNewPost(Name, Comment);
            var read2 = new ToDBPosts();
            return View(read2.GetPost(1));
            //return View(new MainPost());
        }
    }
}
