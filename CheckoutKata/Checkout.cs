using System;
using System.Collections.Generic;

namespace CheckoutKata.Tests
{
    internal class Checkout
    {
        int totalPrice;
        Dictionary<string, int> skuQuantities;
        Dictionary<string, int> _prices;

        public Checkout(Dictionary<string,int> prices)
        {
            totalPrice = 0;
            _prices = prices;
            skuQuantities = new Dictionary<string, int>();
        }

        public Checkout()
        {
            totalPrice = 0;
        }

        internal void Scan(string skuInput)
        {
            string[] splitSkuInput = skuInput.Split(',');

            foreach(string sku in splitSkuInput)
            {
                if (skuQuantities.ContainsKey(sku))
                {
                    skuQuantities[sku] ++;
                }
                else
                {
                    skuQuantities[sku] = 1;
                }
            }
            
        }

        internal int GetTotalPrice()
        {
            foreach(string sku in skuQuantities.Keys)
            {
                if(_prices.ContainsKey(sku))
                {
                    totalPrice += _prices[sku];
                }
            }

            return totalPrice;
        }
    }
}