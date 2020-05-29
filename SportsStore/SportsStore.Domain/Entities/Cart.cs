using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
   public class Cart
    {
        private List<CartLine> LineCollection = new List<CartLine>();
        public void AdddItem(Product product,int quantity)
        {
            CartLine line = LineCollection.Where(p => p.Product.ProductId == product.ProductId).FirstOrDefault();

            if (line == null)
            {
                LineCollection.Add(new CartLine { Product = product, Quantity = quantity });
            }
            else
                line.Quantity += quantity;
        }

        public void RemoveLine(Product product)
        {
            LineCollection.RemoveAll(l => l.Product.ProductId == product.ProductId);
        }
        public Decimal ComputeToatalValue()
        {
            return LineCollection.Sum(e => e.Product.Price * e.Quantity);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {

            LineCollection.Clear();
        }
     
        public IEnumerable<CartLine> Lines
        {
            get { return LineCollection; }
        }
    }
}
