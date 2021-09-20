using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternPrinciple.LOD
{
    /// <summary>
    /// 迪米特法则（最少知道原则）： 一个对象应该对其他对象保持最少的了解
    /// 面向对象 -- 类 -- 类与类之间会有交互 -- 功能模块 -- 系统
    /// 高内聚， 低耦合： 高度封装， 类与类之间减少依赖
    ///
    /// 耦合关系： 依赖， 关联， 组合， 聚合， 继承， 实现
    /// 依赖： 一个对象仅出现在其他类的方法里，不属于其他类的属性
    ///       间接朋友
    /// 关联，组合，聚合： 都是一个类的属性里出现其他类，但是关联程度又轻到重
    ///                  直接朋友
    ///
    /// 只与直接朋友通信
    /// 去掉内部依赖 -- 降低访问修饰符
    /// </summary>
    public class LODShow
    {
        private School school = new School()
        {
            SchoolName = "Celebree",
            Classes = new List<Class>()
            {
                new Class()
                {
                    ClassName = "Advanced",
                    Students = new List<Student>()
                    {
                        new Student()
                        {
                            Id = 1,
                            Name = "Ivan"
                        }
                    }
                },
                new Class()
                {
                    ClassName = "VIP",
                    Students = new List<Student>()
                    {
                        new Student()
                        {
                            Id =2,
                            Name = "Eva"
                        }
                    }
                }
            }
        };
    }
}
