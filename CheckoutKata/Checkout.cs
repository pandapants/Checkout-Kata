using System;
using System.Collections.Generic;

namespace CheckoutKata.Tests
{
    public class Checkout
    {
        private decimal totalPrice;
        private Dictionary<string, int> skuQuantities;
        private readonly Dictionary<string, decimal> _prices;

        public Checkout(Dictionary<string, decimal> prices)
        {
            totalPrice = 0;
            _prices = prices;
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
            foreach(string sku in skuQuantities.Keys)
            {
                if(_prices.ContainsKey(sku))
                {
                    int skuQuantity = skuQuantities[sku];
                    totalPrice += (skuQuantity * _prices[sku]);
                }
            }

            return totalPrice;
        }
    }
}