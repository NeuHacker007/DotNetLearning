using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternPrinciple.DIP
{
    /// <summary>
    /// 依赖倒置原则： 高层模块不应该以来与底层模块，二者应该通过抽象依赖
    ///               依赖抽象，而不是依赖细节
    ///               面向抽象编程
    ///
    /// 抽象： 抽象类/接口
    /// 细节： 类
    /// 23中设计模式， 80%以上都跟这个有关系
    ///
    /// 依赖抽象，更具有通用性； 而且具备扩展性
    /// 细节是多变的，抽象是稳定的；系统架构基于抽象来搭建，会更稳定更具扩展性
    ///
    /// 面向抽象编程， 底层莫扩里面尽量都有抽象类/接口，
    ///
    /// 在声明参数/变量/属性的时候，尽量都是 接口/抽象类
    /// </summary>
    public class DIPShow
    {
        public static void Show()
        {
            // DIPShow -- 高层
            // Student -- 上层
            // Phone -- 低层

            Student student = new Student()
            {
                Id = 1,
                Name = "Ivan"
            };


            {
                Iphone phone = new Iphone();

                // student.PlayIphone(phone);
                student.Play(phone);
            }

            {
                Lumia phone = new Lumia();
                // student.PlayLumia(phone);
                student.Play(phone);
            }

        }
    }
}
