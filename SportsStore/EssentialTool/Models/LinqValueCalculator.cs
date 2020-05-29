using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EssentialTool.Models
{
    public class LinqValueCalculator:IValueCalculator
    {
        private IDiscountHelper Discounter;
        public LinqValueCalculator(IDiscountHelper discountParameter)
        {

            Discounter = discountParameter;
        }
        public decimal ValueProduct(IEnumerable<Product> products)
        {
           
            return Discounter.ApplyDiscount(products.Sum(p => p.Price));
           //  return products.Sum(p => p.Price);
        }
    }
}