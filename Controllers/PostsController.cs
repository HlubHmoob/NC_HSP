using NC_HSP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NC_HSP.Controllers
{
    public class PostsController : Controller
    {
        // *** GET: All Posts ***
        public ActionResult Index()
        {
            ViewBag.Posts = "Posts";
            PostsDBHandler PHandler = new PostsDBHandler();
            ModelState.Clear();

            return View(PHandler.GetPostItem());
        }

        // *** Add new Post ***
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PostsViewModels iPost)
        {
            if (ModelState.IsValid)
            {
                PostsDBHandler PHandler = new PostsDBHandler();
                if (PHandler.PostItem(iPost))
                {
                    ViewBag.Message = "Item Added Successfully";
                    ModelState.Clear();
                }
            }
            return View();
        }

        // *** Update Post Details ***
        [HttpGet]
        public ActionResult Edit(int id)
        {
            PostsDBHandler PHandler = new PostsDBHandler();
            return View(PHandler.GetPostItem().Find(itemmodel => itemmodel.Id == id));
        }
        [HttpPost]
        public ActionResult Edit(int id, PostsViewModels iPost)
        {
            try
            {
                PostsDBHandler PHandler = new PostsDBHandler();
                PHandler.UpdateItem(iPost);
                return RedirectToAction("Index");
            }
            catch { return View(); }
        }

        // *** Delete Item Details ***
        public ActionResult Delete(int id)
        {
            try
            {
                PostsDBHandler PHandler = new PostsDBHandler();
                if (PHandler.DeletePostItem(id))
                {
                    ViewBag.AlertMsg = "Item Deleted Successfully";
                }
                return RedirectToAction("Index");
            }
            catch { return View(); }
        }

        public ActionResult Details(int id)
        {
            PostsDBHandler PHandler = new PostsDBHandler();
            return View(PHandler.GetPostItem().Find(itemmodel => itemmodel.Id == id));
        }


    }
}