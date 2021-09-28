using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryPattern.War3.Interface;

namespace FactoryPattern.AbstractFactory
{
    /// <summary>
    /// 抽象工厂： 工厂 + 约束
    /// 创建产品簇， 多个对象是个整体， 不可分割
    /// 典型的应用
    ///
    /// System.Data.SqlClient.SqlClientFactory
    /// 
    /// 一个工厂负责一些产品的创建
    /// 产品簇
    ///
    /// 单一职责就是创建完整的产品簇
    ///
    /// 继承抽象后， 必须显式override弗雷德抽象方法
    /// </summary>
    public abstract class AbstractFactory
    {
        public abstract IRace CreateRace();
        public abstract IArmy CreateArmy();
        public abstract IHero CreateHero();
        public abstract IResource CreateResource();
    }
}
