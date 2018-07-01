using System;

namespace CheckoutKata.Tests
{
    internal class Checkout
    {
        int totalPrice;
        string sku;

        public Checkout()
        {
            totalPrice = 0;
        }

        internal void Scan(string sku)
        {
            this.sku = sku;
        }

        internal object GetTotalPrice()
        {
            if (sku == "A") totalPrice += 50;
            if (sku == "B") totalPrice += 30;
            return totalPrice;
        }
    }
}