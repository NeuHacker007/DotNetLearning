using System;
using System.Linq;

namespace LinqInternalDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var customers = GetCustomers();
            var addressList = GetAddressList();

            var customerWithAddress = customers.Join(
                addressList,
                c => c.Id,
                a => a.CustomerId,
                (c, a) => new
                {
                    c.Name,
                    a.Street,
                    a.City
                });

            foreach (var item in customerWithAddress)
            {
                Console.WriteLine($"{item.Name} - {item.Street} - {item.City}");
            }

            Console.ReadKey();
        }

        private static Address[] GetAddressList()
        {
            return new[]
            {
                new Address()
                {
                    Id = 1,
                    CustomerId = 2,
                    Street = "AA",
                    City = "Indianapolis"
                },
                new Address()
                {
                    Id = 2,
                    CustomerId = 2,
                    Street = "BB",
                    City = "Indianapolis"
                },
                new Address()
                {
                    Id = 3,
                    CustomerId = 1,
                    Street = "CC",
                    City = "Indianapolis"
                },
                new Address()
                {
                    Id = 4,
                    CustomerId = 4,
                    Street = "DD",
                    City = "Indianapolis"
                },
                new Address()
                {
                    Id = 5,
                    CustomerId = 5,
                    Street = "EE",
                    City = "Indianapolis"
                },
                new Address()
                {
                    Id = 6,
                    CustomerId = 6,
                    Street = "FF",
                    City = "Indianapolis"
                },
                new Address()
                {
                    Id = 7,
                    CustomerId = 7,
                    Street = "GG",
                    City = "Indianapolis"
                },
            };
        }

        private static void SelectAndSelectManyDemo()
        {
            var customers = GetCustomers();


            var customerNames = customers.NewSelect(c => c.Name);

            foreach (var customerName in customerNames)
            {
                Console.WriteLine(customerName);
            }

            var customerPhones = customers.SelectMany(c => c.Phones.NewSelectMany(p => p.Contacts));

            foreach (var customerPhone in customerPhones)
            {
                Console.WriteLine($"{customerPhone.Name}");
            }
        }

        private static Customer[] GetCustomers()
        {
            return new[]
            {
                new Customer()
                {
                    Id = 1,
                    Name = "Ivan",
                    Phones = new Phone[]
                    {
                        new Phone()
                        {
                            Number = "123",
                            PhoneType = PhoneType.Cell,
                            Contacts = new Contact[]
                            {
                                new Contact() {Name = "Guopin"},
                                new Contact() {Name = "Youzhi"},
                            }
                        },
                        new Phone()
                        {
                            Number = "456",
                            PhoneType = PhoneType.Home,
                            Contacts = new Contact[]
                            {
                                new Contact() {Name = "Yunshu"},
                                new Contact() {Name = "Roujia"},
                            }
                        },
                    }
                },
                new Customer()
                {
                    Id = 2,
                    Name = "Eva",
                    Phones = new Phone[]
                    {
                        new Phone()
                        {
                            Number = "345-678-33",
                            PhoneType = PhoneType.Cell,
                            Contacts = new Contact[]
                            {
                                new Contact() {Name = "shuangjie"},
                                new Contact() {Name = "tuige"},
                            }
                        },
                        new Phone()
                        {
                            Number = "345-678-32",
                            PhoneType = PhoneType.Home,
                            Contacts = new Contact[]
                            {
                                new Contact() {Name = "rongyan"},
                                new Contact() {Name = "ziheng"},
                            }
                        },
                    }
                }
            };
        }

        private static void WhereLinqDemo()
        {
            var items = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var even = items.NewWhere(x => x % 2 == 0);

            foreach (var num in even)
            {
                Console.WriteLine(num);
            }
        }
    }
}
