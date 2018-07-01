using System;

namespace CheckoutKata.Tests
{
    internal class Checkout
    {
        int totalPrice;

        public Checkout()
        {
            totalPrice = 0;
        }

        internal void Scan(string sku)
        {
            if (sku == "A") totalPrice += 50;
        }

        internal object GetTotalPrice()
        {
            return totalPrice;
        }
    }
}