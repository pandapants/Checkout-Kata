using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Tests
{
    [TestFixture]
    public class CheckoutTests
    {
        [Test]
        public void ScanningSingleSkuReturnsCorrectTotalPrice()
        {
            //Arrange
            var prices = new Dictionary<string, decimal>()
            {
                {"A", 50 }
            };
            var checkout = new Checkout(prices);

            //Act
            checkout.Scan("A");
            var result = checkout.GetTotalPrice();

            //Assert
            Assert.AreEqual(50, result);
        }

        [Test]
        public void ScanningMultipleSkuReturnsCorrectTotalPrice()
        {
            //Arrange
            var prices = new Dictionary<string, decimal>()
            {
                {"A", 50 },
                {"B", 30.50m }
            };
            var checkout = new Checkout(prices);

            //Act
            checkout.Scan("A,A,B");
            var result = checkout.GetTotalPrice();

            //Assert
            Assert.AreEqual(130.50m, result);
        }
    }
}
