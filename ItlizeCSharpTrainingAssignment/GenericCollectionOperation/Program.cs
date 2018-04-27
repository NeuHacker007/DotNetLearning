using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericCollectionOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            #region inital list
            List<PersonalDetails> personalDetailses = new List<PersonalDetails>()
            {
                new PersonalDetails()
                {
                    FirstName = "Yifan",
                    MiddleName = " ",
                    LastName = "Zhang",
                    Gender = "Male",
                    Age = 29
                },
                new PersonalDetails()
                {
                    FirstName = "John",
                    MiddleName = " ",
                    LastName = "Smith",
                    Gender = "Female",
                    Age = 58

                },
                new PersonalDetails()
                {
                    FirstName = "Apple",
                    MiddleName = " ",
                    LastName = "Jobs",
                    Gender = "Female",
                    Age = 36
                }

            };
            #endregion
            foreach (var personaldetail in personalDetailses)
            {
                Console.WriteLine("First Name: {0}, LastName: {1}, Age: {2}, Gender: {3}",
                    personaldetail.FirstName, personaldetail.LastName, personaldetail.Age, personaldetail.Gender);
            }

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("***************************************************************************");
            //var personalsOver35 = from personal in personalDetailses
            //                      where personal.Age > 35
            //                      select personal;


            var personalsOver35 = personalDetailses.Where(x => x.Age > 35);
            foreach (var personal in personalsOver35)
            {
                Console.WriteLine("First Name: {0}, LastName: {1}, Age: {2}, Gender: {3}",
                    personal.FirstName, personal.LastName, personal.Age, personal.Gender);
            }

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("***************************************************************************");

            personalDetailses.Sort((x, y) => x.FirstName.CompareTo(y.FirstName));
            foreach (var personaldetail in personalDetailses)
            {
                Console.WriteLine("First Name: {0}, LastName: {1}, Age: {2}, Gender: {3}",
                    personaldetail.FirstName, personaldetail.LastName, personaldetail.Age, personaldetail.Gender);
            }

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("***************************************************************************");

            List<PersonalDetails> newList = new List<PersonalDetails>()
            {
                new PersonalDetails()
                {
                    FirstName = "Tuige",
                    MiddleName = " ",
                    LastName = "Zhu",
                    Gender = "Male",
                    Age = 26
                },
                new PersonalDetails()
                {
                    FirstName = "Youzhi",
                    MiddleName = "",
                    LastName = "Zhang",
                    Gender = "Male",
                    Age = 27
                }
            };

            personalDetailses.AddRange(newList);
            foreach (var personaldetail in personalDetailses)
            {
                Console.WriteLine("First Name: {0}, LastName: {1}, Age: {2}, Gender: {3}",
                    personaldetail.FirstName, personaldetail.LastName, personaldetail.Age, personaldetail.Gender);
            }
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("***************************************************************************");

            personalDetailses.RemoveAll(x => string.Equals(x.Gender, "Male"));

            foreach (var personaldetail in personalDetailses)
            {
                Console.WriteLine("First Name: {0}, LastName: {1}, Age: {2}, Gender: {3}",
                    personaldetail.FirstName, personaldetail.LastName, personaldetail.Age, personaldetail.Gender);
            }
            Console.ReadLine();
        }
    }
}
