using System;
using System.Collections.Generic;

namespace companydb
{
    class Customer : Person
    {
        private List<Purchase> history;

        public Customer(string name, string email, string phone) : base(name, email, phone)
        {
            this.history = new List<Purchase>();
        }

        public void purchase_add(Purchase purchase)
        {
            this.history.Add(purchase);
        }

        public void CustomerPrint()
        {
            Console.WriteLine($"{Name}  <{Email}>  Phone: {Phone}");
        }

        public void OrderHistory()
        {
            Console.WriteLine("Order History");
            Console.WriteLine("Item              Price   Quantity   Total");
            foreach (var purchase in history)
            {
                Console.WriteLine($"{purchase.Item}         {purchase.Cost}          {purchase.Qty}     {purchase.Total}");
            }
        }

        public void PurchaseAdd()
        {
            Console.Write("Item: ");
            string item = Console.ReadLine();
            Console.Write("Quantity: ");
            int qty = int.Parse(Console.ReadLine());
            Console.Write("Cost: ");
            double cost = double.Parse(Console.ReadLine());
            Purchase p = new Purchase(item, qty, cost);
            purchase_add(p);
        }

        public Purchase PurchaseGet(int index)
        {
            return history[index];
        }
        public int purchase_end()
        {
            return history.Count;
        }
    }
}
