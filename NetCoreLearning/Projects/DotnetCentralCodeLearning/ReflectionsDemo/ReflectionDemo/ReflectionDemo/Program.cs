using System;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace ReflectionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var assembly =
                Assembly.LoadFrom(
                    @"H:\.NET Learning\NetCoreLearning\Projects\DotnetCentralCodeLearning\ReflectionsDemo\ReflectionDemo\PrintAll\bin\Debug\netcoreapp3.1\PrintAll.dll");

            foreach (var type in assembly.GetTypes())
            {
                Console.WriteLine("========== Type ========= ");
                Console.WriteLine($"Type: {type.Name}");

                var instance = Activator.CreateInstance(type);

                Console.WriteLine("========== Fields ========= ");
                foreach (var fieldInfo in type.GetFields(
                    BindingFlags.NonPublic
                    | BindingFlags.Instance
                    | BindingFlags.DeclaredOnly))
                {
                    Console.WriteLine($"Field: {fieldInfo.Name}");
                    fieldInfo.SetValue(instance, "Ivan");
                }
                Console.WriteLine("========== Methods ========= ");
                // only properties have special name so in below condition
                // we will not see the public method get_name which is from property
                foreach (var methodInfo in type.GetMethods(
                    BindingFlags.Public
                    | BindingFlags.NonPublic
                    | BindingFlags.Instance
                    | BindingFlags.DeclaredOnly).Where(m => !m.IsSpecialName))
                {
                    Console.WriteLine($"Method: {methodInfo.Name}");
                    if (methodInfo.GetParameters().Length > 0)
                    {
                        methodInfo.Invoke(instance, new object?[] { "Eva" });
                    }
                    else if (methodInfo.ReturnType.Name != "Void")
                    {
                        var returnValue = methodInfo.Invoke(instance, null);

                        Console.WriteLine($"Return Value from method: {returnValue}");
                    }
                    else
                    {
                        methodInfo.Invoke(instance, null);
                    }



                }
                Console.WriteLine("========== properties ========= ");

                foreach (var propertyInfo in type.GetProperties())
                {
                    Console.WriteLine($"Property: {propertyInfo.Name}");
                    var propertyValue = propertyInfo.GetValue(instance);
                    Console.WriteLine($"Property Value: {propertyValue}");
                }
            }

            Console.ReadKey();

        }
    }
}
