using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PrototypePattern
{
    /// <summary>
    /// 普通类
    /// 但是有一个非常耗时的构造函数， 从性能角度考虑需要优化
    /// </summary>
    /// 
    public class Student
    {
        public Student()
        {
            long lResult = 0;

            for (int i = 0; i < 10000000; i++)
            {
                lResult +=i;
            }

            Thread.Sleep(1000);

        }


        public int Id { get; set; }

        public string Name { get; set; }


        public void Study()
        {

        }
    }

    
}
