using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternPrinciple.ISP
{
    public abstract class AbstractPhone
    {
        public int Id { get; set; }
        public string Branch { get; set; }

        public abstract void Call();
        public abstract void Text();
    }

    /// <summary>
    /// 一个大而全的接口： 描述能干什么 can do
    /// 
    /// </summary>
    public interface IExtend
    {
       
        void Online();

        void Game();
        
        void Movie();

  
    }

    public interface IExtendAdvanced
    {
        void Map();
        void Pay();
    }

    public interface IExtendPhotography
    {
        void Photo();
        void Record();
    }
}
