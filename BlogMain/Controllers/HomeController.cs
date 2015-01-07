using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BlogMain.Models;

namespace BlogMain.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var read = new ToDBPosts();
            return View(read.GetPost());
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
        [Authorize]
        public ActionResult AdminPanel(string Comment, string Name)
        {
            AddPost obj = new AddPost();
            obj.AddNewPost(Name, Comment);
            var read2 = new ToDBPosts();
            return View(read2.GetPost());
        }

        [HttpGet]
        public ActionResult Autorise()
        {
            var read = new Autorise();
            return View(read.LeftStuff());
        }
        [HttpPost]
        public ActionResult Autorise(string Name, string Password)
        {
            if(Name == "Forbear" && Password == "1234")
            {
                FormsAuthentication.SetAuthCookie("Admin", false);
                return Index();
            }
            var read = new Autorise();
            return View(read.LeftStuff());
        }
    }
}
