﻿using LinqDemo.Models;
using System;
using System.Linq;

namespace LinqDemo
{
    public class OuterJoinDemo
    {
        public static void Demo1()
        {
            var queryMethod = from emp in OuterJoinDataSource.Employee.GetAllEmployees()
                              join address in OuterJoinDataSource.Address.GetAddress()
                              on emp.AddressId equals address.ID into EmployeeAddressGroup
                              from address in EmployeeAddressGroup.DefaultIfEmpty()
                              select new
                              {
                                  emp,
                                  address
                              };
            foreach (var item in queryMethod)
            {
                Console.WriteLine($"Name : {item.emp.Name}, Address : {item.address?.AddressLine} ");
            }
        }

        public static void Demo2()
        {
            var methodFormat = OuterJoinDataSource.Employee.GetAllEmployees()
                               .GroupJoin(
                                OuterJoinDataSource.Address.GetAddress(),
                                emp => emp.AddressId,
                                address => address.ID,
                                (emp, address) => new { emp, address })
                               .SelectMany(
                                x => x.address.DefaultIfEmpty(),
                                (emp, address) => new { emp, address });

            foreach (var item in methodFormat)
            {
                Console.WriteLine($"Name : {item.emp.emp.Name}, Address : {item.address?.AddressLine} ");
            }

        }
    }

    public class RightjoinDemo
    {
        public static void Demo1()
        {
            var queryMethod = from address in OuterJoinDataSource.Address.GetAddress()
                              join emp in OuterJoinDataSource.Employee.GetAllEmployees()
                              on address.ID equals emp.AddressId into AddressEmpGroup
                              from emp in AddressEmpGroup.DefaultIfEmpty()
                              select new
                              {
                                  address,
                                  emp
                              };

            foreach (var item in queryMethod)
            {
                Console.WriteLine($" Name: {item.emp?.Name} address: {item.address.AddressLine}");
            }
        }

        public static void Demo2()
        {
            var methodForamt = OuterJoinDataSource.Address.GetAddress()
                 .GroupJoin(
                    OuterJoinDataSource.Employee.GetAllEmployees(),
                    address => address.ID,
                    emp => emp.AddressId,
                    (address, emp) => new { address, emp })
                 .SelectMany(x => x.emp.DefaultIfEmpty(),
                  (address, emp) => new
                  {
                      emp,
                      address
                  });
            foreach (var item in methodForamt)
            {
                Console.WriteLine($" Name: {item.emp?.Name} address: {item.address.address.AddressLine}");
            }


        }
    }
}