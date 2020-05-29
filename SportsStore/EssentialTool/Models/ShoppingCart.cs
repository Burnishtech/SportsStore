using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EssentialTool.Models
{
    public class ShoppingCart
    {
        //  private LinqValueCalculator Calc;
       private IValueCalculator Calc;
       // private LinqValueCalculator calc;

        public ShoppingCart(IValueCalculator calParam)
        {

            Calc = calParam;
        }

        //public ShoppingCart(LinqValueCalculator calc)
        //{
        //    this.calc = calc;
        //}

        public IEnumerable<Product> Products { get; set; }
        public decimal CalculateProductTotal()
        {
            return Calc.ValueProduct(Products);
        }
    }
}