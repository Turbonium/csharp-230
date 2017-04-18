using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloWorld.Models;
using HelloWorld.Controllers;
using Moq;

namespace HelloWorld.Tests
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void TestMethodWithFakeClass()
        {
            // Arrange
            var controller = new HomeController(new FakeProductRepository());

            // Act
            var result = controller.Products();

            // Assert
            var products = (Product[])((System.Web.Mvc.ViewResultBase)(result)).Model;
            Assert.AreEqual(4, products.Length, "Length is invalid");
        }

        [TestMethod]
        public void TestMethodWithMoq()
        {
            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository
                .SetupGet(t => t.Products)
                .Returns(() =>
                {
                    return new Product[]{
                    new Product{ ProductId=101, Name="Baseball", Description="balls", Price=11.00m},
                    new Product{ ProductId=102, Name="Football", Description="nfl", Price=8.00m},
                    new Product{ ProductId=102, Name="Tennis Ball", Description="balls", Price=13.00m},
                    new Product{ ProductId=102, Name="Golf Ball", Description="balls", Price=3.00m},
                    new Product{ ProductId=102, Name="Ping Pong Ball", Description="balls", Price=12.00m}
                    };
                });

            // Arrange
            var controller = new HomeController(mockProductRepository.Object);

            // Act
            var result = controller.Products();

            // Assert
            var products = (Product[])((System.Web.Mvc.ViewResultBase)(result)).Model;
            Assert.AreEqual(5, products.Length, "Length is invalid");
            Assert.AreEqual(3, products.Count(p=> p.Price > 10), "Less than 3 products found with a price of 10 or more");
            Assert.AreEqual(2, products.Count(p=> p.Price < 10), "More than 2 products found with a price of 10 or less");
        }
    }
}