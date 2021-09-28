using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryPattern.War3.Interface;

namespace FactoryPattern.FactoryMethod
{
    /// <summary>
    /// 工厂方法， 就是将每个生成对象的过程单独变成一个工厂
    /// </summary>
    interface IFactory
    {
        IRace CreateRace();
    }
}
