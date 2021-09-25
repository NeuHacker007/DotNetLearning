using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using FactoryPattern.War3.Interface;
using FactoryPattern.War3.Service;
using Microsoft.Extensions.Configuration;

namespace FactoryPattern
{
    public enum RaceType
    {
        Human,
        Undead,
        ORC,
        NE
    }
    public class ObjectFactory
    {
        public static IRace CreateRace(RaceType raceType)
        {
            IRace iRace = raceType switch
            {
                RaceType.Human => new Human(),
                RaceType.NE => new NE(),
                RaceType.ORC => new ORC(),
                RaceType.Undead => new Undead(),
                _ => throw new Exception("wrong race")
            };

            return iRace;
        }

        public static IRace CreateRace(IConfigurationRoot config)
        {
            var raceConfig = config["RaceType"];
            RaceType raceType = (RaceType) Enum.Parse(typeof(RaceType), raceConfig);
            return CreateRace(raceType);
        }
    }
}
