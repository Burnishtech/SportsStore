using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;
namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        public int pageSize = 3;
        private IProductRepository repository;
        public ProductController(IProductRepository productRepository)

        {
            repository = productRepository;


        }
        // GET: Product
        public ActionResult List(string category,int page=1)
        {
            ProductlistViewModel model = new ProductlistViewModel
            {
                Products = repository.Products
                .Where(p=>category==null || p.category==category)
                .OrderBy(p=> p.ProductId)
                .Skip((page-1)*pageSize)
                .Take(pageSize),
                PgingInfo = new PagingInfo
                {
                    CurrentPages=page,ItemsPerPage=pageSize,

                    TotalItems = category==null? repository.Products.Count(): repository.Products.Where(e=>e.category==category).Count()
                }
                ,
                CurrentCategory=category

            };
            return View(model);
           // return View(repository.Products.OrderBy(P=>P.ProductId).Skip((page - 1)* pageSize).Take(pageSize));
        }
    }
}