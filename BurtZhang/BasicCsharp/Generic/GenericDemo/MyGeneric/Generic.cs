using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGeneric
{
    public class Generic<T>
    {
        public T _T;
    }

    public interface IGenericInterface<T>
    {
        T GetT(T t);//泛型类型的返回值
    }

    public class CommonClass 
        : Generic<int> // 普通类继承泛型类，必须指定其类型
    {

    }

    public class GenericClassChild<T> 
        //: Generic<T>  
        :Generic<int> // 可以合法
    {

    }

    public delegate void SayHi<T>(T t);//泛型委托
}
