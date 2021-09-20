﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternPrinciple.ISP 
{
    public class Iphone : AbstractPhone, IExtend, IExtendAdvanced, IExtendPhotography
    {
        public override void Call()
        {
            Console.WriteLine("Call from Iphone");
        }

        public override void Text()
        {
            Console.WriteLine("Text from Iphone");
        }

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

        public void Map()
        {
            Console.WriteLine("Map");
        }

        public void Pay()
        {
            Console.WriteLine("Pay");
        }
    }
}
