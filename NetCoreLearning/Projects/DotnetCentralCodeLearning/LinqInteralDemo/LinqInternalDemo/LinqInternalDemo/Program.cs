using System;
using System.Linq;

namespace LinqInternalDemo
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        private static void SelectAndSelectManyDemo()
        {
            var customers = new Customer[]
            {
                new Customer()
                {
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
