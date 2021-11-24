using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity.Configuration;
using Unity;

namespace SOA.WebAPI.Unity
{
    /// <summary>
    /// 一定要单例
    /// </summary>
    public class UnitContainerFactory
    {
        private static IUnityContainer _container = null;
        static UnitContainerFactory()
        {
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap
            {
                ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"cfgFiles\Unity.config")
            };
            Configuration configuration =
                ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            UnityConfigurationSection section =
                (UnityConfigurationSection) configuration.GetSection(UnityConfigurationSection.SectionName);
            _container = new UnityContainer();

            section.Configure(_container, "webAPIContainer");
        }

        public static IUnityContainer GetContainer()
        {
            return _container;
        }
    }
}