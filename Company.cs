

namespace companydb
{
    class Company
    {
        private List<Employee> employees;
        private List<Customer> customers;
        private string name;

        public Company(string name)
        {
            this.employees = new List<Employee>();
            this.customers = new List<Customer>();
            this.name = name;
        }

        public void employee_add(Employee employee)
        {
            this.employees.Add(employee);
        }

        public void customer_add(Customer customer)
        {
            this.customers.Add(customer);
        }
        public int employee_end()
        {
            return this.employees.Count;
        }

        public int customer_end()
        {
            return this.customers.Count;
        }
        public void EmployeeAdd()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Phone: ");
            string phone = Console.ReadLine();
            Console.Write("Salary: ");
            double salary = double.Parse(Console.ReadLine());
            Employee temp = new Employee(name, email, phone, salary);
            employee_add(temp);
        }

        public void CustomerAdd()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Phone: ");
            string phone = Console.ReadLine();
            Customer temp = new Customer(name, email, phone);
            customer_add(temp);
        }

        public void EmployeeHistory()
        {
            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.Name} <{employee.Email}> Phone: {employee.Phone} Salary: ${employee.Salary}");
            }
        }

        public void CustomerHistory()
        {
            for (int i = 0; i < customers.Count; i++)
            {
                Console.WriteLine($"{i + 1}.) {customers[i].Name}");
            }
            Console.Write("Choice? ");
        }

        public Customer CustomerGet(int index)
        {
            return customers[index];
        }

        public void Input()
        {
           if (!File.Exists(name + ".dat"))
            {
                using (var file = File.Create(name + ".dat")) { }
                using (StreamWriter file = new StreamWriter(name + ".dat"))
                {
                    file.WriteLine("0");
                    file.WriteLine("0");
                }
            }

            IEnumerable<string> filedata = File.ReadLines(name + ".dat");
            List<string> items = new List<string>(filedata);

            int k = 0, temp, h, l, u;
            h = int.Parse(items[k++]);
            temp = 0;
            while (temp < h)
            {
                string empName = items[k++];
                string empEmail = items[k++];
                string empPhone = items[k++];
                double empSalary = double.Parse(items[k++]);
                Employee employee = new Employee(empName, empEmail, empPhone, empSalary);
                employee_add(employee);
                temp++;
            }

            l = int.Parse(items[k++]);
            temp = 0;
            while (temp < l)
            {
                string cusName = items[k++];
                string cusEmail = items[k++];
                string cusPhone = items[k++];
                u = int.Parse(items[k++]);
                Customer customer = new Customer(cusName, cusEmail, cusPhone);
                int j = 0;
                while (j < u)
                {
                    string itemName = items[k++];
                    int itemQty = int.Parse(items[k++]);
                    double itemCost = double.Parse(items[k++]);
                    Purchase purchase = new Purchase(itemName, itemQty, itemCost);
                    customer.purchase_add(purchase);
                    j++;
                }
                customer_add(customer);
                temp++;
            }
        }

        public void Output()
        {
             using (StreamWriter file = new StreamWriter(name + ".dat"))
            {
                file.WriteLine(employees.Count);
                foreach (var employee in employees)
                {
                    file.WriteLine(employee.Name);
                    file.WriteLine(employee.Email);
                    file.WriteLine(employee.Phone);
                    file.WriteLine(employee.Salary);
                }

                file.WriteLine(customers.Count);
                foreach (var customer in customers)
                {
                    file.WriteLine(customer.Name);
                    file.WriteLine(customer.Email);
                    file.WriteLine(customer.Phone);
                    file.WriteLine(customer.purchase_end());
                    for (int i = 0; i < customer.purchase_end(); i++)
                    {
                        Purchase purchase = customer.PurchaseGet(i);
                        file.WriteLine(purchase.Item);
                        file.WriteLine(purchase.Qty);
                        file.WriteLine(purchase.Cost);
                    }
                }
            }
        }
    }
}

