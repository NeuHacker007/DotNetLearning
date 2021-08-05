using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGeneric
{
    public class Monitor
    {
        public static void Show()
        {
            Console.WriteLine("*********************** Monitor***************");

            {
                int iVal = 12345;
                long commonSecond = 0;
                long objectSecond = 0;
                long genericSecond = 0;

                {
                    Stopwatch watStopwatch = new Stopwatch();

                    watStopwatch.Start();

                    for (int i = 0; i < 100000000; i++)
                    {
                        ShowInt(i);
                    }
                    watStopwatch.Stop();

                    commonSecond = watStopwatch.ElapsedMilliseconds;

                }
                {
                    Stopwatch watStopwatch = new Stopwatch();

                    watStopwatch.Start();

                    for (int i = 0; i < 100000000; i++)
                    {
                        ShowObj(i);
                    }
                    watStopwatch.Stop();

                    objectSecond = watStopwatch.ElapsedMilliseconds;

                }
                {
                    Stopwatch watStopwatch = new Stopwatch();

                    watStopwatch.Start();

                    for (int i = 0; i < 100000000; i++)
                    {
                        ShowGeneric<int>(i);
                    }
                    watStopwatch.Stop();

                    genericSecond = watStopwatch.ElapsedMilliseconds;

                }

                Console.WriteLine($"common = {commonSecond}, object = {objectSecond}, generic = {genericSecond}");
            }
        }

        private static void ShowInt(int i)
        {

        }

        private static void ShowObj(object o)
        {

        }

        private static void ShowGeneric<T>(T t)
        {

        }
    }
}
