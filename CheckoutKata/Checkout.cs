using System;
using System.Collections.Generic;

namespace CheckoutKata.Tests
{
    internal class Checkout
    {
        int totalPrice;
        string sku;
        Dictionary<string, int> _prices;

        public Checkout(Dictionary<string,int> prices)
        {
            totalPrice = 0;
            _prices = prices;
        }

        public Checkout()
        {
            totalPrice = 0;
        }

        internal void Scan(string sku)
        {
            this.sku = sku;
        }

        internal int GetTotalPrice()
        {
            if(_prices.ContainsKey(sku))
            {
                totalPrice += _prices[sku];
            }
            return totalPrice;
        }
    }
}