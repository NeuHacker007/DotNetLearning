using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternPrinciple.DIP
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        //  /// <summary>
        //  /// 依赖Iphone
        //  /// </summary>
        //  /// <param name="phone"></param>
        //  public void PlayIphone(Iphone phone)
        //  {
        //      phone.Call();
        //      phone.Text(); 
        //  }

        //  public void PlayLumia(Lumia phone)
        //  {
        //      phone.Call();
        //      phone.Text(); 
        //  }

        /// <summary>
        /// 依赖抽象
        /// </summary>
        /// <param name="phone"></param>
        public void Play(AbstractPhone phone)
        {
            phone.Call();
            phone.Text();
        }
    }
}
