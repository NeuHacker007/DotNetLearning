using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.Extensions.Configuration;

namespace CustomConfiguration
{
    internal class MyConfigurationProvider : ConfigurationProvider
    {
        Timer timer;

        public MyConfigurationProvider(): base()
        {
            timer = new Timer();
            timer.Elapsed += (obj, e) => Load(true);
            timer.Interval = 3000;
            timer.Start();
        }

        //public void Timer_Elapsed(object sender, ElapsedEventArgs e)
        //{
        //    Load(true);
        //}
        public override void Load()
        {
            Load(false);
        }

        void Load(bool reload)
        {
            this.Data["lastTime"] = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            if (reload)
            {
                base.OnReload();
            }
        }
    }
}
