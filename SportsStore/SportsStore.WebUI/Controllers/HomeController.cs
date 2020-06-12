using SportsStore.WebUI.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class HomeController : Controller
    {

        //protected override void OnException(ExceptionContext filterContext)
        //{
        //    //base.OnException(filterContext);  
        //    ViewResult view = new ViewResult();
        //    view.ViewName = "Error";
        //    filterContext.Result = view;
        //    filterContext.ExceptionHandled = true;
        //}

        [CustomErrorHandling]
        public ActionResult Index()
        {
            int i = 10;
            i = i / 0;
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