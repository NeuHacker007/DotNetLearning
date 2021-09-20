using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternPrinciple.LSP
{
    public class People
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public void Traditional()
        {
            Console.WriteLine("Traditional");
        }
    }

    public class Chinese : People
    {
        public string Kuaizi { get; set; }

        public void SayHi()
        {
            Console.WriteLine("Hi");
        }
    }

    public class HuBei : Chinese
    {
        public string Majiang { get; set; }

        public new void SayHi()
        {
            Console.WriteLine("Hubei Hi");
        }
    }

    /// <summary>
    /// 拥有了人的大部分属性和行为， 但是traditional 没有
    /// </summary>
    public class Japanese //: People
    {
        public int Id { get; set; }

        public string Name { get; set; }

        //不符合
        //public new void Traditional()
        //{
        //    throw new Exception();
        //}

        public void Ninja()
        {
            Console.WriteLine("Ninja");
        }
    }
}
