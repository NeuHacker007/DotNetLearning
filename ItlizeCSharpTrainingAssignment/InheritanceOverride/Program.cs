using System;

namespace InheritanceOverride
{
    class Program
    {
        static void Main(string[] args)
        {
            CityDerived city = new CityDerived();
            city.DisplayCityName();
            Console.ReadLine();
        }
    }
}
