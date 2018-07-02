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
            var priceInformation = new Dictionary<string, PriceInformation>()
            {
                {
                    "A",
                    new PriceInformation()
                    {
                        UnitPrice = 50.00m
                    }
                }
            };
            var checkout = new Checkout(priceInformation);

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
            var priceInformation = new Dictionary<string, PriceInformation>()
            {
                {
                    "A",
                    new PriceInformation()
                    {
                        UnitPrice = 50.00m
                    }
                },
                {
                    "B",
                    new PriceInformation()
                    {
                        UnitPrice = 30.50m
                    }
                }
            };
            var checkout = new Checkout(priceInformation);

            //Act
            checkout.Scan("A,A,B");
            var result = checkout.GetTotalPrice();

            //Assert
            Assert.AreEqual(130.50m, result);
        }

        [Test]
        public void ScanningQuantityOfSkuMatchingOfferReturnsDiscountedTotalPrice()
        {
            //Arrange
            var priceInformation = new Dictionary<string, PriceInformation>()
            {
                {
                    "A",
                    new PriceInformation()
                    {
                        UnitPrice = 50.00m,
                        MulitItemOffer = new MultipleItemOffer()
                        {
                            Quantity = 3,
                            DiscountedPrice = 130
                        }
                    }
                }
            };
            var checkout = new Checkout(priceInformation);

            //Act
            checkout.Scan("A,A,A");
            var result = checkout.GetTotalPrice();

            //Assert
            Assert.AreEqual(130, result);
        }
    }
}
