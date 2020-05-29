using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Concrete
{
   public class EFProductRepository : IProductRepository
    {
        private EFDbcontext Context = new EFDbcontext();
        public IEnumerable<Product> Products {
            get { return Context.product; } }

        public void SaveProduct(Product product)
        {
            if (product.ProductId == 0)
            {
                Context.product.Add(product);
            }
            else
            {
                Product dbEntry = Context.product.Find(product.ProductId);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.category = product.category;
                }
              
            }
            Context.SaveChanges();
        }

       public Product DeleteProduct(int productID)
        {
            Product dbEntry = Context.product.Find(productID);
            if (dbEntry != null)
            {

                Context.product.Remove(dbEntry);
                Context.SaveChanges();
            }
            return dbEntry;

        }

        //  IEnumerable<Entities.Product> IProductRepository.Products => throw new NotImplementedException();
    }
}

