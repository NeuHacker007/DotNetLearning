using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.SqlServer
{
    public class GenericClass <T, W, X>
    {

        public void Show(T t, W w, X x)
        {
            Console.WriteLine($"t.type={t.GetType()}, w.type={w.GetType()}, x.type={w.GetType()}");
        }
    }
}
