namespace companydb
{
    class Employee : Person
    {
        private double salary;

        public Employee(string name, string email, string phone, double salary) : base(name, email, phone)
        {
            this.salary = salary;
        }

        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }
    }
}
