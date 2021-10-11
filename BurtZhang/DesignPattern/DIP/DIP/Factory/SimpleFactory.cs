using System;
using System.Reflection;
using IBLL;
using IDAL;

namespace Factory
{
    public class SimpleFactory
    {
        // 配置文件 + 反射
        public static AbstractPhone CreatePhone()
        {
            Assembly assembly = Assembly.Load("DAL");
            Type type = assembly.GetType("DAL.Iphone");
            return (AbstractPhone) Activator.CreateInstance(type);
        }

        public static IStudentService CreateService()
        {
            Assembly assembly = Assembly.Load("BLL");
            Type type = assembly.GetType("BLL.StudentService");
            return (IStudentService) Activator.CreateInstance(type);
        }
    }
}
