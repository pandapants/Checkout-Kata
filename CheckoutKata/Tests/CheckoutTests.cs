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
            var checkout = new Checkout();

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
            var checkout = new Checkout();

            //Act
            checkout.Scan("B");
            var result = checkout.GetTotalPrice();

            //Assert
            Assert.AreEqual(30, result);
        }
    }
}
