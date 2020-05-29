using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace SportsStore.Domain.Entities
{
    public class Product
    {
        [HiddenInput(DisplayValue =false)]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please enter the product Name")]
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]

        [Required(ErrorMessage = "Please enter the product Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter the product Price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please enter the product category")]
        public string category { get; set; }
    }
}