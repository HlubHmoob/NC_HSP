using NC_HSP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NC_HSP.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(string currentFilter, string searchString, int? page)
        {

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            var postList = from s in db.Posts
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                postList = postList.Where(s => s.Title.Contains(searchString)
                                       || s.BodyText.Contains(searchString)
                                       || s.Comments.Any(c => c.BodyText.Contains(searchString))
                                       || s.Comments.Any(c => c.Author.UserName.Contains(searchString)));
            }
            else
            {
                Console.WriteLine("No results");
            }

            ViewBag.CurrentFilter = searchString;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}