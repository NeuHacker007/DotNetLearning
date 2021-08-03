using System;
using System.Data.Common;
using System.Reflection;
using DB.Interface;
using DB.MySql;
using DB.SqlServer;
using Microsoft.Extensions.Configuration;

namespace MyReflection
{

    /// <summary>
    /// 1. Dll -> IL -> metadata - Reflection
    /// 2. Reflection load dll, read module, class, methods and attributes
    /// 3. Reflection create Object
    /// 4. Reflection call instance method, static method, overload method, private methods, generic method
    /// 5. Reflection to get fields and property
    /// 6. Pro & cons
    ///
    /// System.Reflection used to read the metadata 
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            
            try
            {
                Console.WriteLine("***********Common**************");

                IDBHelper helper = new MySqlHelper();
                helper.Query();
                Console.WriteLine("**************Reflection**************");

                {
                    
                    // load from current directory
                    Assembly assembly = Assembly.Load("DB.MySql"); // 1. Load DLL
                    // provide the full path of the dll
                    // but before usage we need add reference
                    // to our project otherwise it will throw exception
                    Assembly assembly1 = Assembly.LoadFile(@"C:\Drive H Work\DotNetLearning\BurtZhang\BasicCsharp\Reflection\ReflectionDemo\MyReflection\bin\Debug\net5.0\DB.MySql.dll");

                    // parameter can be the suffix or the full dll path
                    Assembly assembly2 = Assembly.LoadFrom("DB.MySql.dll");

                    foreach (var module in assembly.GetModules())
                    {
                        Console.WriteLine(module.FullyQualifiedName);
                    }

                    foreach (var type in assembly.GetTypes())
                    {
                        Console.WriteLine(type.FullName);
                    }

                    Type objType = assembly
                        .GetType("DB.MySql.MySqlHelper"); //2. Get type
                    if (objType != null)
                    {

                        object oHelper = Activator.CreateInstance(objType); //3. create instance
                        // oHelper is object so it cannot call the method
                        // although the method is there.
                        // actually this is compiler doesn't accept this
                        // and error out.
                        // oHelper.Query(); 
                        IDBHelper iDbHelper = (IDBHelper)oHelper; //4. cast the type
                        iDbHelper?.Query(); //5. call the method.
                    }
                }

                {
                    Console.WriteLine("***************Reflection + Factory + Config***************");

                    IDBHelper dbHelper = Factory.CreateHelper(config);
                    dbHelper.Query(); //Configurable, dynamic and depends on the string.
                }

                // Break Singleton
                {
                    Console.WriteLine("***************Reflection + Object***************");

                    Assembly assembly = Assembly.Load("DB.SqlServer");

                    Singleton singleton1 = Singleton.GetSingleton();
                    Singleton singleton2 = Singleton.GetSingleton();
                    Singleton singleton3 = Singleton.GetSingleton();
                    Console.WriteLine($"Singleton1: {singleton1.GetHashCode()} \n Singleton2: {singleton2.GetHashCode()} \n Singleton3: {singleton3.GetHashCode()}");
                    {
                        Type type = assembly.GetType("DB.SqlServer.Singleton");

                        Singleton singleton4 = Activator.CreateInstance(type, true) as Singleton;
                        Singleton singleton5 = Activator.CreateInstance(type, true) as Singleton;
                        Singleton singleton6 = Activator.CreateInstance(type, true) as Singleton;
                        Console.WriteLine($"Singleton1: {singleton4.GetHashCode()} \n Singleton2: {singleton5.GetHashCode()} \n Singleton3: {singleton6.GetHashCode()}");
                    }
                }
                // create instance with parameterized constructor
                {
                    Assembly assembly = Assembly.Load("DB.SqlServer");
                    Type type = assembly.GetType("DB.SqlServer.ReflectionTest");
                    if (type != null)
                    {
                        object oParameterLess = Activator.CreateInstance(type);
                        object oIntParameter = Activator.CreateInstance(type, new object[] {123});
                        object oStrParameter = Activator.CreateInstance(type, new object[] {"123"});
                    }
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                //throw;
            }

            Console.ReadLine();
        }
    }
}
