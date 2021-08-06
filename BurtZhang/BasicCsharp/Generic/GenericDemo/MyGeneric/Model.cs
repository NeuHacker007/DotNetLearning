using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGeneric
{

    public interface ISports
    {
        void PingPang();
    }

    public interface IWork
    {
        void Work();
    }
    class Model
    {
    }

    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Hi()
        {
            Console.WriteLine("Hi");
        }
    }

    public class Chinese : People, ISports, IWork
    {
        public void Tradition()
        {
            Console.WriteLine("tradition");
        }

        public void SayHi()
        {
            Console.WriteLine("hahaha");
        }

        public void PingPang()
        {
            Console.WriteLine("play pingpang");
        }

        public void Work()
        {
            throw new NotImplementedException();
        }
    }

    public class Hubei : Chinese
    {
        public string Changjiang { get; set; }

        public void Majiang()
        {
            Console.WriteLine("Play Majiang");
        }
    }

    public class Japanese: ISports
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public void PingPang()
        {
            Console.WriteLine("play pingpang");
        }
    }
}
