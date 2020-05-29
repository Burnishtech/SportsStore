using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EssentialTool.Models;
using Ninject;
namespace EssentialTool.Controllers
{
    public class HomeController : Controller
    {


      private IValueCalculator Calc;
        public HomeController(IValueCalculator CalCparam)
        {
            Calc = CalCparam;

        }
        private Product[] products = {
                                        new Product{Name="Tapas",Category="WaterSports",Price=275M},
                                        new Product{Name="Tapas",Category="Soccer",Price=12M},
                                        new Product{Name="Tapas",Category="Cricket",Price=123M},
                                        new Product{Name="Tapas",Category="Scoccer",Price=275M},
                                        new Product{Name="Tapas",Category="WaterSports",Price=275M},
                                    };
        public ActionResult Index()
        {
            //   LinqValueCalculator Calc = new LinqValueCalculator();

            IKernel nijectKernel = new StandardKernel();
            nijectKernel.Bind<IValueCalculator>().To<LinqValueCalculator>();
           // IValueCalculator calcualtor = nijectKernel.Get<IValueCalculator>();

           // IValueCalculator Calc = new LinqValueCalculator();
            ShoppingCart cart = new ShoppingCart(Calc) { Products = products };
            decimal totalValue = cart.CalculateProductTotal();
            return View(totalValue);
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