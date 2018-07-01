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
        public void ScanningSkuOfAReturnsTotalPriceOf50()
        {
            //Arrange
            var prices = new Dictionary<string, int>()
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
        public void ScanningSkuOfBReturnsTotalPriceOf30()
        {
            //Arrange
            var prices = new Dictionary<string, int>()
            {
                {"B", 30 }
            };
            var checkout = new Checkout(prices);

            //Act
            checkout.Scan("B");
            var result = checkout.GetTotalPrice();

            //Assert
            Assert.AreEqual(30, result);
        }
    }
}
