using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;

namespace SportsStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IProductRepository repository;
        public NavController(IProductRepository repo)
        {
            repository = repo;


        }
   public PartialViewResult Menu(string category=null)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> Categories = repository.Products.Select(x => x.category).Distinct().OrderBy(x => x);
            return PartialView(Categories);
        }
        // GET: Nav
        //public string Menu()
        //{
        //    return " Hello from navigarter";
        //}
    }
}