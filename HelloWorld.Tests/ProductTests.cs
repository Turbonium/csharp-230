using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloWorld.Models;
using HelloWorld.Controllers;
using Moq; // Use a Moq Test
using System.Linq;

namespace HelloWorld.Tests
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void TestMethodWithMoq()
        {
            var mockProductRepository = new Mock<IProductRepository>();

            mockProductRepository
                .SetupGet(t => t.Products)
                .Returns(
                    () =>
                    {
                        return new Product[]{
                            new Product{ Name="Baseball", Price = 11},
                            new Product{ Name="Football", Price = 8},
                            new Product{ Name="Tennis ball", Price = 13} ,
                            new Product{ Name="Golf ball", Price=3},
                            new Product{ Name="ping pong ball", Price = 12},
                        };
                    }
                 );

            // Arrange
            var controller = new HomeController(mockProductRepository.Object);

            // Act
            var result = controller.Products();

            // Assert
            var products = (Product[])((System.Web.Mvc.ViewResultBase)(result)).Model;
            Assert.AreEqual(5, products.Length, "Length is invalid");
            // the check for the price
            Assert.AreEqual(3, products.Where(t => t.Price > 10).Count(), "We should have 3 products > $10");
            Assert.AreEqual(2, products.Where(t => t.Price < 10).Count(), "We should have 2 products < $10");
        }

        [TestMethod]
        public void TestMethodWithFakeClass()
        {
            // Arrange
            var controller = new HomeController(new FakeProductRepository());

            // Act
            var result = controller.Products();

            // Assert
            var products = (Product[])((System.Web.Mvc.ViewResultBase)(result)).Model;
            Assert.AreEqual(5, products.Length);
        }
    }
}