using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LotteryDemo
{
    public class RandomHelper
    {
        public static int GetRandomNumberLong(int min, int max)
        {
            Thread.Sleep(GetRandomNumber(1000, 2000));
            return GetRandomNumber(min, max);
        }
        public static int GetRandomNumber(int min, int max)
        {
            Guid guid = new Guid();

            string sGuid = guid.ToString();

            int seed = DateTime.Now.Millisecond;

            foreach (char c in sGuid)
            {
                switch (c)
                {
                    case 'a':
                    case 'b':
                    case 'c':
                    case 'd':
                    case 'e':
                    case 'f':
                    case 'g':
                        seed += 1;
                        break;
                    case 'h':
                    case 'i':
                    case 'j':
                    case 'k':
                    case 'l':
                    case 'm':
                    case 'n':
                        seed += 2;
                        break;
                    case 'o':
                    case 'p':
                    case 'q':
                    case 'r':
                    case 's':
                    case 't':
                        seed += 3;
                        break;
                    case 'u':
                    case 'v':
                    case 'w':
                    case 'x':
                    case 'y':
                    case 'z':
                        seed += 4;
                        break;
                    default:
                        seed += 5;
                        break;
                }
            }

            Random random = new Random(seed);

            return random.Next(min, max);
        }
    }
}
