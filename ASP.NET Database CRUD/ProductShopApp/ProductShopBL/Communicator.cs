using ProductShopDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShopBL
{
    public class Communicator
    {
        private ProductShopContext context = new ProductShopContext();
        public string Test()
        {
            context.Categories.Add(new Category()
            {
                Name = "Test",
                Products = new List<Product>() { }
            });

            context.SaveChanges();


            return context.Categories.First().Name;
        }
    }
}
