using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternPrinciple.LSP
{
    public class Poly
    {
        public static void Test()
        {
            ParentClass parent = new ChildClass();

            parent.CommonMethod(); // 调用父类  普通方法由左边决定，编译时决定


            {
                typeof(ParentClass)
                    .GetMethod("CommonMethod")
                    .Invoke(parent, null); // 调用父类



                typeof(ChildClass)
                    .GetMethod("CommonMethod")
                    .Invoke(parent, null); // 调用子类
            }

            {
                dynamic dParent = new ChildClass();
                dParent.CommonMethod(); // 调用子类方法 运行时决定的
            }


            parent.VirtualMethod();// 调用子类  虚方法由右边决定， 运行时决定

            parent.AbstractMethod();// 调用子类 抽象方法由右边决定， 运行时决定

        }

    }

    public abstract class ParentClass
    {
        public void CommonMethod()
        {
            Console.WriteLine("Common method from PrarentClass");
        }

        public virtual void VirtualMethod()
        {
            Console.WriteLine("Virtual Method from PrarentClass");
        }

        public virtual void VirtualMethod(string name)
        {
            Console.WriteLine("Virtual Method overload from PrarentClass");
        }

        public abstract void AbstractMethod();

    }

    public class ChildClass : ParentClass
    {
        // new 关键字用来隐藏父类方法
        public new void CommonMethod()
        {
            Console.WriteLine("Common method from ChildClass");
        }

        public override void VirtualMethod()
        {
            Console.WriteLine("Virtual Method from ChildClass");
        }

        public override void AbstractMethod()
        {
            Console.WriteLine("AbstractMethod from Child Class");
        }
    }
}
