using DB.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Reflection;

namespace MyReflection
{
    public class Factory
    {
        public static IDBHelper CreateHelper(IConfiguration _config)
        {
            // load from current directory
            Assembly assembly = Assembly.Load(_config["dllName"]); // 1. Load dll

            Type objType = assembly.GetType(_config["typeName"]); //2. Get type

            if (objType == null) return null;

            object oHelper = Activator.CreateInstance(objType);
            IDBHelper iDbHelper = (IDBHelper)oHelper; //4. cast the type


            return iDbHelper;
        }
    }
}
