namespace companydb
{
    class Purchase
    {
        private string item;
        private int qty;
        private double cost;

        public Purchase(string item, int qty, double cost)
        {
            this.item = item;
            this.qty = qty;
            this.cost = cost;
        }

        public string Item
        {
            get { return item; }
            set { item = value; }
        }

        public int Qty
        {
            get { return qty; }
            set { qty = value; }
        }

        public double Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        public double Total
        {
            get { return qty * cost; }
        }
    }
}
