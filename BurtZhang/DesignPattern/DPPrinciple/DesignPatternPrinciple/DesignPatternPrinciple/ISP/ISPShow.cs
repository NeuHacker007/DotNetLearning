using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternPrinciple.ISP
{
    /// <summary>
    /// 接口隔离原则： 客户端不应该依赖它不需要的接口
    ///               一个类对另一个类的依赖应该建立在最小的接口上
    ///               实现一个接口的时候，只需要自己需要的功能
    ///
    /// 实现接口，就必须把接口中所有的方法都实现
    /// 其实是一种约束, 肯定包含具体实现的
    ///
    /// 可以多重实现， 所以可以拆分，然后多个实现
    ///
    /// 为什么不建立一个大而全的接口， 而是要拆分？
    /// 1. 因为不能让类型实现自己没有的功能
    /// 为什么要尽量用同一个接口
    /// 1. 尽量让抽象更具备适应性
    ///
    /// 接口拆分是随着项目进程进行演变的，一直演变下去，
    /// 是不是直接拆分成一个接口一个方法得了？
    /// 
    /// 如果真的一个接口，一个方法，那也就没有意义了
    /// 究竟该如何设计呢？需要丰富的经验和对业务的理解
    ///     1. 接口不能太大 否则会实现不需要的功能
    ///     2. 不能过度设计 要考虑清楚业务的边界
    ///     3. 接口还是要尽量的小， 合适的接口，一致的功能应该在一个接口
    ///     4. 接口合并： 如果一个业务包含多个固定步骤， 我们不应该把步骤都暴露，而是提供一个入口即可
    ///         eg. Map()  用户不关心Map是怎么工作的，所以我们只要暴露Map即可，不用把下面三个步骤暴露
    ///                 -- 搜索
    ///                 -- 定位
    ///                 -- 导航 
    /// </summary>
    public class ISPShow
    {
        public static void Show()
        {
            {
                // OK 
                IExtend device = new Iphone();

                // device.Map();
                device.Movie();
                // device.Pay();
            }

            {
                IExtend device = new OldMan();
                // throw not implemented exception
                // 埋坑
                //  device.Pay();
                //  device.Map();
                // Or
                // if (device is OldMan)
            }
        
        }
    }
}
