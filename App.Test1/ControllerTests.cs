using AppWithTests.Controllers;
using AppWithTests.Interfaces;
using AppWithTests.Models;
using AppWithTests.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace App.Test1
{
    public class ControllerTests
    {
        [Fact]
        public void IndexViewHas2Products()
        {
            //make controller
            var productRepository = new ProductRepository();
            var controller = new HomeController(productRepository);
            int expected = 2;
            var viewResult = Assert.IsType<ViewResult>(controller.Index());
            var model = Assert.IsType<List<Product>>(viewResult.Model);
            int actual = model.Count;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ProductDetail1IsNamedApples()
        {
            var productRepository = new ProductRepository();
            var controller = new HomeController(productRepository);
            string expected = "apples";
            var viewResult = Assert.IsType<ViewResult>(controller.Details(1));
            var model = Assert.IsType<Product>(viewResult.Model);
            string actual = model.Name.ToLower();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ProductDetail1IsNamedPumpkins()
        {
            var productRepository = new ProductRepository();
            var controller = new HomeController(productRepository);
            string expected = "bananas";
            var viewResult = Assert.IsType<ViewResult>(controller.Details(2));
            var model = Assert.IsType<Product>(viewResult.Model);
            string actual = model.Name.ToLower();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void UnitTestProductList()
        {
            // 1. Create instance of fake repo using IProductRepository interface.
            var mockProductRepo = new Mock<IProductRepository>();

            // 2. Set up return data for ProductList() method.
            mockProductRepo.Setup(mpr => mpr.ProductList())
                .Returns(new List<Product>{
                    new Product(), new Product(), new Product()
                });

            // 3. Define controller instance with mock repository instance.
            var controller = new HomeController(mockProductRepo.Object);

            // 4. Make your test Assertions 
            // Check if it returns a view
            var result = Assert.IsType<ViewResult>(controller.Index());

            // Check that the model returned to the view is 'List<Product>'.
            var model = Assert.IsType<List<Product>>(result.Model);

            // Ensure count of objects is 3.
            int expected = 3;
            int actual = model.Count;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void UnitTestProductDetails()
        {
            // 1. Create instance of fake repo using IProductRepository interface.
            var mockProductRepo = new Mock<IProductRepository>();

            mockProductRepo.Setup(mpr => mpr.ProductDetails(It.IsAny<int>()))
                .Returns(new Product() { ID = 1, Name = "apricots" });

            // 3. Define controller instance with mock repository instance.
            var controller = new HomeController(mockProductRepo.Object);

            // 4. Make your test Assertions 
            // Check if it returns a view
            var result = Assert.IsType<ViewResult>(controller.Details(1));

            // Check that the model returned to the view is 'List<Product>'.
            var model = Assert.IsType<Product>(result.Model);

            string expected = "apricots";
            string actual = model.Name.ToLower();
            Assert.Equal(expected, actual);
        }

    }
}
