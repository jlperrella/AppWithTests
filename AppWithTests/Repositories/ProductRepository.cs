using AppWithTests.Interfaces;
using AppWithTests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWithTests.Repositories
{
    public class ProductRepository : IProductRepository
    {
        // Here we create some fake data to make thigs easier but 
        // this could be swapped out easily so the application connects
        // to a live database.
        private static List<Product> products = new List<Product> {
        new Product { ID = 1, Name = "Apples",  Price = 1.50m },
        new Product { ID = 2, Name = "Bananas", Price = 2.00m }
    };

        public List<Product> ProductList()
        {
            return products;
        }

        public Product ProductDetails(int id)
        {
            return products.Find(products => products.ID == id);
        }


    }
}
