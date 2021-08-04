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
                        object oIntParameter = Activator.CreateInstance(type, new object[] { 123 });
                        object oStrParameter = Activator.CreateInstance(type, new object[] { "123" });
                    }
                }

                // Generic 
                {
                    Assembly assembly = Assembly.Load("DB.SqlServer");
                    // In order to find proper generic class, we need use ` + number of parameter.
                    // otherwise the type will be null
                    Type type = assembly.GetType("DB.SqlServer.GenericClass`3");
                    // we cannot direct create instance like below and we will
                    // get the exception of
                    //                  Message = "Cannot create an instance of DB.SqlServer.GenericClass`3[T,W,X]
                    //                            because Type.ContainsGenericParameters is true."
                    // Reason is that we didn't provide the concrete type info to the create Instance method. 
                    // object oGeneric = Activator.CreateInstance(type);

                    Type newType = type.MakeGenericType(new Type[] { typeof(int), typeof(string), typeof(DateTime) });
                    object oGeneric = Activator.CreateInstance(newType);

                }

                // Method
                {
                    Console.WriteLine("***************Reflection + Method***************");
                    Assembly assembly = Assembly.Load("DB.SqlServer");
                    Type type = assembly.GetType("DB.SqlServer.ReflectionTest");

                    object oReflection = Activator.CreateInstance(type);
                    // cannot be called until cast the object to it's type
                    // oReflection.Show1();
                    {
                        // walk around 

                        MethodInfo method = type.GetMethod("Show1");
                        method?.Invoke(oReflection, null);
                    }
                    {
                        // parameter 
                        MethodInfo method2 = type.GetMethod("Show2");
                        method2?.Invoke(oReflection, new object[] {123});
                    }
                    {
                        //static 
                        MethodInfo method3 = type.GetMethod("Show5");
                        method3?.Invoke(oReflection, new object[] {"123"});
                        method3?.Invoke(null, new object[] {"123"});
                    }
                    {
                        //Overload
                        MethodInfo method5 = type.GetMethod("Show3", new Type[] {});
                        method5?.Invoke(oReflection, new object[] {});
                        MethodInfo method6 = type.GetMethod("Show3", new Type[] {typeof(int), typeof(string)});
                        method6?.Invoke(oReflection, new object[] {123, "123"});
                    }
                    {
                        //private method

                        MethodInfo method = type.GetMethod("Show4", BindingFlags.Instance | BindingFlags.NonPublic);
                        method?.Invoke(oReflection, new object[] {"123"});
                    }
                    {
                        Assembly assembly1 = Assembly.Load("DB.SqlServer");
                        Type GenericDouble = assembly.GetType("DB.SqlServer.GenericDouble`1");
                        Type newGenericDouble = GenericDouble?.MakeGenericType(new Type[] {typeof(int)});
                        object o = Activator.CreateInstance(newGenericDouble);
                        MethodInfo method = newGenericDouble.GetMethod("Show");
                        MethodInfo newMethod = method?.MakeGenericMethod(new Type[] {typeof(string), typeof(DateTime)});

                        newMethod?.Invoke(o, new object[] {123, "Ivan", DateTime.Now});


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
