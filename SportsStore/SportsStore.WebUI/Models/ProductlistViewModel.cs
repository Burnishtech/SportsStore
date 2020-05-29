using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SportsStore.Domain.Entities;
namespace SportsStore.WebUI.Models
{
    public class ProductlistViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PgingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}