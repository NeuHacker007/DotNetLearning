using System;
using System.Collections.Generic;

namespace CollectionDemoConApp
{
    public class Employee
    {
        public Employee(int id, string name)
        {
            EmpId = id;
            EmpName = name;
        }

        private int _EmpId;

        public int EmpId
        {
            get { return _EmpId; }
            set { _EmpId = value; }
        }

        private string _EmpName;

        public string EmpName
        {
            get { return _EmpName; }
            set { _EmpName = value; }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, Employee> empDictionary = new Dictionary<int, Employee>();
            empDictionary.Add(1, new Employee(1, "Yifan"));
            empDictionary.Add(2, new Employee(2, "Tuige"));
            empDictionary.Add(3, new Employee(3, "Youzhi"));
            empDictionary.Add(4, new Employee(4, "Eva"));
            empDictionary.Add(5, new Employee(5, "Jhon"));

            int counter = 1;
            foreach (var emp in empDictionary)
            {
                Console.WriteLine("No: {0} Key: {1} Emp ID: {2} Emp Name: {3}", counter++, emp.Key, emp.Value.EmpId, emp.Value.EmpName);
            }
            Console.ReadLine();
        }
    }
}
