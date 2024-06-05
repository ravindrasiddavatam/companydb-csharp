using System;

namespace companydb
{
    class Program
    {
        public void Start()
        {
            string companyName;
            Program self = new Program();
            Console.Write("Company Name: ");
            companyName = Console.ReadLine();
            Company company = new Company(companyName);
            int choice, customerChoice;
            char subChoice;
            company.Input();
            while (true)
            {
                Console.WriteLine("    MAIN MENU");
                Console.WriteLine("1.) Employees");
                Console.WriteLine("2.) Sales");
                Console.WriteLine("3.) Quit");
                Console.Write("Choice? ");
                choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    while (true)
                    {
                        company.EmployeeHistory();
                        Console.Write("(A)dd Employee or (M)ain Menu? ");
                        subChoice = char.Parse(Console.ReadLine());
                        if (subChoice == 'A')
                        {
                            company.EmployeeAdd();
                        }
                        else if (subChoice == 'M')
                        {
                            break;
                        }
                    }
                }
                else if (choice == 2)
                {
                    while (true)
                    {
                        Console.Write("(A)dd Customer, Enter a (S)ale, (V)iew Customer, or (M)ain Menu? ");
                        subChoice = char.Parse(Console.ReadLine());
                        if (subChoice == 'A')
                        {
                            company.CustomerAdd();
                        }
                        else if (subChoice == 'S')
                        {
                            if (company.customer_end() >= 1)
                            {
                                company.CustomerHistory();
                                customerChoice = int.Parse(Console.ReadLine());
                                company.CustomerGet(customerChoice - 1).PurchaseAdd();
                            }
                            else
                            {
                                Console.WriteLine("Error: No Customers.");
                            }
                        }
                        else if (subChoice == 'V')
                        {
                            if (company.customer_end() >= 1)
                            {
                                company.CustomerHistory();
                                customerChoice = int.Parse(Console.ReadLine());
                                var customer = company.CustomerGet(customerChoice - 1);
                                customer.CustomerPrint();
                                customer.OrderHistory();
                            }
                            else
                            {
                                Console.WriteLine("Error: No Customers.");
                            }
                        }
                        else if (subChoice == 'M')
                        {
                            break;
                        }
                    }
                }
                else if (choice == 3)
                {
                    company.Output();
                    break;
                }
            }
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Start();
        }
    }
}
