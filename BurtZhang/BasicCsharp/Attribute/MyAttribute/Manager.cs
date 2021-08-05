using MyAttribute.Extension;
using System;
using System.Reflection;

namespace MyAttribute
{
    public class Manager
    {
        public static void Show(Student student)
        {
            Type type = typeof(Student);

            if (type.IsDefined(typeof(CustomAttribute), true))
            {
                //object oAttribute = type.GetCustomAttributes(typeof(CustomAttribute), true);
                CustomAttribute oAttribute = type.GetCustomAttribute(typeof(CustomAttribute), true) as CustomAttribute;
                Console.WriteLine($"{oAttribute.Description}_{oAttribute.Remark}");
                oAttribute.SHow();
            }

            MethodInfo method = type.GetMethod("Answer");

            if (method.IsDefined(typeof(CustomAttribute), true))
            {
                //object oAttribute = type.GetCustomAttributes(typeof(CustomAttribute), true);
                CustomAttribute oAttribute = method.GetCustomAttribute(typeof(CustomAttribute), true) as CustomAttribute;
                Console.WriteLine($"{oAttribute.Description}_{oAttribute.Remark}");
                oAttribute.SHow();
            }

            ParameterInfo inputParam = method.GetParameters()[0];
            if (inputParam.IsDefined(typeof(CustomAttribute), true))
            {
                //object oAttribute = type.GetCustomAttributes(typeof(CustomAttribute), true);
                CustomAttribute oAttribute = inputParam.GetCustomAttribute(typeof(CustomAttribute), true) as CustomAttribute;
                Console.WriteLine($"{oAttribute.Description}_{oAttribute.Remark}");
                oAttribute.SHow();
            }

            ParameterInfo returnParameterInfo = method.ReturnParameter;
            if (returnParameterInfo != null && returnParameterInfo.IsDefined(typeof(CustomAttribute), true))
            {
                //object oAttribute = type.GetCustomAttributes(typeof(CustomAttribute), true);
                CustomAttribute oAttribute = returnParameterInfo.GetCustomAttribute(typeof(CustomAttribute), true) as CustomAttribute;
                Console.WriteLine($"{oAttribute.Description}_{oAttribute.Remark}");
                oAttribute.SHow();
            }

            // 做数据检查(卸载数据库保存之前)
            //if (student.QQ > 10001 && student.QQ < 99999999999)
            //{

            //}
            Console.WriteLine($"validateness: {student.Validate()}");


            student.Study();
            student.Answer("Ivan");
        }
    }
}
