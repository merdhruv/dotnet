using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppRevision.Models;

namespace WebAppRevision.Controllers
{
    public class HomeController : Controller
    {
        IRepo repo;
        public HomeController()
        {
            repo = new ActualRepo();
        }
        public ActionResult Index()
        {

            return View(repo.GetAllEmployees());
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