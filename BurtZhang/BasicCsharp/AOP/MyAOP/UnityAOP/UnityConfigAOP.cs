using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using System.Configuration;
using System.IO;
using Microsoft.Practices.Unity.Configuration;

namespace UnityAOP
{
    public class UnityConfigAOP
    {
        public static void Show()
        {
            User user = new User()
            {
                Name = "Ivan",
                Password = "1234123"
            };

            {
                IUnityContainer container = new UnityContainer();
                container.RegisterType<IUserProcessor>();
                IUserProcessor processor = container.Resolve<IUserProcessor>();
                processor.RegUser(user);
            }

            { 
                IUnityContainer container = new UnityContainer();

                ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();

                fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "Unity.config");

                Configuration configuration =
                    ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
                UnityConfigurationSection configurationSection =
                    (UnityConfigurationSection) configuration.GetSection(UnityConfigurationSection.SectionName);

                configurationSection.Configure(container, "UnityAOPContainer");

                IUserProcessor processor = container.Resolve<IUserProcessor>();
                processor.RegUser(user);
                processor.GetUser(user);
            }
        }
    }
    public interface IUserProcessor
    {
        void RegUser(User user);
        User GetUser(User user);
    }
    public class User
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
    public class UserProcessor : IUserProcessor
    {
        public void RegUser(User user)
        {
            Console.WriteLine($"User has already registered Name: {user.Name}; Password: {user.Password}");
        }

        public User GetUser(User user)
        {
            return user;
        }
    }
}
