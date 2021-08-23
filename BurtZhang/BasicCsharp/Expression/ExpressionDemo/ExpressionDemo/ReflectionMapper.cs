using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionDemo
{
    /// <summary>
    /// 反射实现mapper 性能比较差
    /// </summary>
    public class ReflectionMapper
    {
        public static TOut Trans<TIn, TOut>(TIn tIn)
        {
            TOut tOut = Activator.CreateInstance<TOut>();

            foreach (var itemOut in tOut.GetType().GetProperties())
            {

                var propIn = tIn.GetType().GetProperty(itemOut.Name);

                itemOut.SetValue(tOut, propIn?.GetValue(tIn));

                //foreach (var itemIn in tIn.GetType().GetProperties())
                //{
                //    if (itemOut.Name.Equals(itemIn.Name))
                //    {
                //        itemOut.SetValue(tOut, itemIn.GetValue(tIn));
                //        break;
                //    }
                //}
            }

            
            foreach (var itemOut in tOut.GetType().GetFields())
            {
                var fieldIn = tIn.GetType().GetField(itemOut.Name);
                itemOut.SetValue(tOut, fieldIn?.GetValue(tIn));
                //foreach (var itemIn in tIn.GetType().GetFields())
                //{
                //    if (itemOut.Name.Equals(itemIn.Name))
                //    {
                //        itemOut.SetValue(tOut, itemIn.GetValue(tIn));
                //        break;
                //    }
                //}
            }

            return tOut;
        }
    }
}
