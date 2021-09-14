using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternPrinciple.SRP
{
    /// <summary>
    /// 单一职责原则： 类T负责两个不同职责： 职责P1， 职责P2。
    /// 当由于职责P1 需求发生改变和需要修改类T时
    /// 有可能导致原本运行正常的职责P2功能发生故障
    ///
    ///
    /// 一个类只负责一个事儿
    /// </summary>
    public class SRPShow
    {

        public static void Show()
        {
            {
                Animal animal = new Animal("Chicken");
                animal.Breath();
                animal.Action();
            }
            {
                Animal animal = new Animal("Fish");
                animal.Breath();
                animal.Action();
            }
        }
    }
}
