using System;
using System.Collections.Generic;

namespace CheckoutKata.Tests
{
    public class Checkout
    {
        private decimal totalPrice;
        private Dictionary<string, int> skuQuantities;
        private readonly Dictionary<string, PriceInformation> _priceInformation;

        public Checkout(Dictionary<string, PriceInformation> priceInformation)
        {
            totalPrice = 0;
            _priceInformation = priceInformation;
            skuQuantities = new Dictionary<string, int>();
        }

        public void Scan(string skuInput)
        {
            string[] splitSkuInput = skuInput.Split(',');
            this.UpdateSkuQuantities(splitSkuInput);
        }

        private void UpdateSkuQuantities(string[] skuInputvalues)
        {
            foreach (string sku in skuInputvalues)
            {
                if (skuQuantities.ContainsKey(sku))
                {
                    skuQuantities[sku]++;
                }
                else
                {
                    skuQuantities[sku] = 1;
                }
            }
        }

        public decimal GetTotalPrice()
        {
            foreach (string sku in skuQuantities.Keys)
            {
                PriceInformation skuPriceInformation = _priceInformation[sku];

                if (skuPriceInformation != null)
                {
                    int skuQuantity = skuQuantities[sku];

                    if(MultipleItemDiscountApplies(skuPriceInformation, skuQuantity))
                    {
                        totalPrice += skuPriceInformation.MulitItemOffer.DiscountedPrice;
                        totalPrice += (skuQuantity - skuPriceInformation.MulitItemOffer.Quantity) * skuPriceInformation.UnitPrice;
                    }
                    else
                    {
                        totalPrice += (skuQuantity * skuPriceInformation.UnitPrice);
                    }
                }
            }

            return totalPrice;
        }

        private bool MultipleItemDiscountApplies(PriceInformation skuPriceInformation, int skuQuantity)
        {
            if(skuPriceInformation.MulitItemOffer != null)
            {
                return skuQuantity >= skuPriceInformation.MulitItemOffer.Quantity;
            }

            return false;
        }
    }
}