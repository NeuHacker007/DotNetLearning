using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        /// <summary>
        /// 细节没有消失 只是转移
        ///
        /// 转移了矛盾， 并没有消除矛盾
        ///
        /// 甚至是集中了矛盾，因为所有的依赖都集中在下面这个方法了
        /// </summary>
        /// <param name="raceType"></param>
        /// <returns></returns>
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

        // 升级思路
        // 1. 方法加参数
        // 2. 给不同的参数，配置不同的IraceTypeConfigReflection

        // 多方法是不对的，因为没法扩展新种族
        // 泛型也不对 泛型需要上端知道具体类型


        /// <summary>
        /// ioc 雏形 可配置可扩展
        ///
        /// 
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public static IRace CreateRaceConfigReflection(IConfigurationRoot config)
        {
            // 无需事先定义human/Undead 可以灵活添加
            var dllName = config["IRaceTypeConfig:DllName"];
            var typeName = config["IRaceTypeConfig:TypeName"];

            Assembly assembly = Assembly.Load(dllName);

            Type type = assembly.GetType(typeName);

            IRace iRace = Activator.CreateInstance(type) as IRace;

            return iRace;
        }

    }
}
