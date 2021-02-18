using System;

namespace becoming_asd.Models
{
    public class Order
    {
        public int Id { get; private set; }
        public decimal Price { get; private set; }
        public decimal TaxRate { get; } = 0.23M;
        public decimal TotalPrice { get { return (1 * TaxRate) * Price; } }
        public bool IsPurchased { get; private set; }

        public Order(int id, decimal price)//walidacja ceny
        {
            Id = id;
            Price = price;
        }

        public void Purchase()
        {
            if (IsPurchased)
            {
                throw new Exception("Order purchased.");
            }

            IsPurchased = true;
        }
    }
}