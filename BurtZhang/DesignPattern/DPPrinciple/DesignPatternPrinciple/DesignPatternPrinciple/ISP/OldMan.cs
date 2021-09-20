using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternPrinciple.ISP
{
    public class OldMan : IExtend
    {
        public void Photo()
        {
            Console.WriteLine("Photo");
        }

        public void Online()
        {
            Console.WriteLine("Online");
        }

        public void Game()
        {
            Console.WriteLine("Game");
        }

        public void Record()
        {
            Console.WriteLine("Record");
        }

        public void Movie()
        {
            Console.WriteLine("Movie");
        }
        /// <summary>
        /// Old man 不可以导航
        /// </summary>
        public void Map()
        {
            throw new NotImplementedException();
        }
        // old man 不可以 pay 但是由于接口强制约束，又必须实现，
        // 此时应当考虑拆分 IExtend 接口
        public void Pay()
        {
            throw new NotImplementedException();
        }
    }
}
