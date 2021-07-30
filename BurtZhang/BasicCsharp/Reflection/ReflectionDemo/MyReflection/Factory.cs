using DB.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyReflection
{
    public class Factory
    {
         public static IDBHelper CreateHelper()
        {
            // load from current directory
            Assembly assembly = Assembly.Load("DB.MySql"); // 1. Load dll

            Type objType = assembly.GetType("DB.MySql.MySqlHelper"); //2. Get type


            object oHelper = Activator.CreateInstance(objType);
            IDBHelper iDbHelper = (IDBHelper)oHelper; //4. cast the type


            return iDbHelper;
        }
    }
}
