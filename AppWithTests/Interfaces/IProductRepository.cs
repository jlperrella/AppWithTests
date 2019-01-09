using AppWithTests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWithTests.Interfaces
{
    public interface IProductRepository
    {
            List<Product> ProductList();
            Product ProductDetails(int id);
    }
}
