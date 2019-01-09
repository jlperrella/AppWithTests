using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AppWithTests.Models;
using AppWithTests.Interfaces;

namespace AppWithTests.Controllers
{
    public class HomeController : Controller
    {


        // Class level instance of the product repository.
        // using AppWithTests.Interfaces;
        private IProductRepository _productRepo;

        // This constructor overload receives an instance of 
        // the ProductRepo class. 
        public HomeController(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        // Show listing of products.
        public IActionResult Index()
        {
            var products = _productRepo.ProductList();
            return View(products);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Details(int id)
        {
            var product = _productRepo.ProductDetails(id);
            return View(product);

        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
