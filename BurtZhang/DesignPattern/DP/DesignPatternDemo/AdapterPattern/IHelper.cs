using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    public interface IHelper
    {
        void Add<T>();
        void Delete<T>();
        void Update<T>();
        void Query<T>();
    }
}
