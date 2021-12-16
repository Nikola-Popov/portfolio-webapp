using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Post.Models;

namespace portfolio.Controllers
{
    public class PostController : Controller
    {
        private PostContext _db = new PostContext();

        // GET: Post

        [HttpPost]
        public ActionResult Forum(PostEntry postEntry)
        {
            postEntry.PostDate = DateTime.Now;
            _db.Entries.Add(postEntry);
            _db.SaveChanges();
            return RedirectToAction("Forum");
        }

        public ActionResult Forum()
        {
            ViewData["hasPermission"] = User.Identity.IsAuthenticated;
           var mostRecentPosts = from post in _db.Entries orderby post.PostDate descending select post;
           ViewBag.Entries = mostRecentPosts.ToList();

            return View();
        }

        [HttpPost]
        public ActionResult Delete(string PostId)
        {
            var post = _db.Entries.Find(Int32.Parse(PostId));
            bool hasPermission = User.Identity.Name == post.AuthorName;
            if(hasPermission) { 
                _db.Entries.Remove(post);
                _db.SaveChanges();
            }
            return RedirectToAction("Forum");
        }
    }
}