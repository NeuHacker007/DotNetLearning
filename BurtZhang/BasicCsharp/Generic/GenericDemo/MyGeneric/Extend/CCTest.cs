using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyGeneric.Extend
{
    /// <summary>
    /// .NET 4.0
    /// 只能放在接口或者委托的泛型参数前面
    /// out 协变 covariant 修饰返回值
    /// in 逆变 contravariant 修饰传入参数
    /// </summary>
    public class CCTest
    {
        public static void Show()
        {
            {
                Bird bird1 = new Bird();
                Bird bird2 = new Sparrow();
                Sparrow sparrow1 = new Sparrow();
                // Sparrow sparrow2 = new Bird();

            }
            {
                List<Bird> bird1 = new List<Bird>();

                // 应该可以这样写， 一堆麻雀当然是一堆鸟
                // 但是实际上不行。
                // 因为 List<Bird> 和 List<Sparrow>
                // 没有父子关系。
                // List<Bird> bird2 = new List<Sparrow>();



                List<Bird> birds3 = new List<Sparrow>().Select(c => (Bird)c).ToList();
            }

            {
                // 协变

                // 之所以可以这样写，是因为在泛型接口IEnumerable当中
                // 在泛型类型前使用了out
                // out 修饰后，泛型类型只能放在返回值而不能放在函数入参中
                IEnumerable<Bird> birds1 = new List<Bird>();
                IEnumerable<Bird> birds2 = new List<Sparrow>();

                //委托
                Func<Bird> func = new Func<Sparrow>(() => null);

                ICustomerListOut<Bird> customerListOut = new CustomerListOut<Bird>();
                ICustomerListOut<Bird> customerListOut2 = new CustomerListOut<Sparrow>();
            }

            {
                // 逆变
                ICustomerListIn<Sparrow> customerListIn1 = new CustomerListIn<Sparrow>();
                ICustomerListIn<Sparrow> customerListIn2 = new CustomerListIn<Bird>();

                ICustomerListIn<Bird> birds = new CustomerListIn<Bird>();
                birds.Show(new Sparrow());
                birds.Show(new Bird());

                Action<Sparrow> act = new Action<Bird>( (Bird i) => {} );
            }

            {
                IMyList<Sparrow, Bird> myList1 = new MyList<Sparrow, Bird>();
                IMyList<Sparrow, Bird> myList2 = new MyList<Sparrow, Sparrow>(); //协变
                IMyList<Sparrow, Bird> myList3 = new MyList<Bird, Bird>(); // 逆变
                IMyList<Sparrow, Bird> myList4 = new MyList<Bird, Sparrow>(); // 协变 + 逆变


            }
        }

        public interface ICustomerListOut<out T>
        {
            T Get();

            //  void Show(T t); //只能放在返回值
        }

        public class CustomerListOut<T> : ICustomerListOut<T>
        {
            public T Get()
            {
                return default(T);
            }
        }
        public interface ICustomerListIn<in T>
        {
           // T Get(); //只能放在入参

            void Show(T t);
        }

        public class CustomerListIn<T> : ICustomerListIn<T>
        {
            //public T Get()
            //{
            //    return default(T);
            //}
            public void Show(T t)
            {
                
            }
        }

        public interface IMyList<in inT, out outT>
        {
            void Show(inT t);

            outT Get();

            outT Do(inT t);
        }

        public class MyList<T1, T2> : IMyList<T1, T2>
        {
            public void Show(T1 t)
            {
                Console.WriteLine(t.GetType().Name);
            }

            public T2 Get()
            {
                Console.WriteLine(typeof(T2).Name);

                return default(T2);
            }

            public T2 Do(T1 t)
            {
                Console.WriteLine(t.GetType().Name);
                Console.WriteLine(typeof(T2).Name);
                return default(T2);
            }
        }

        public class Bird
        {
            public int Id { get; set; }

        }

        public class Sparrow : Bird
        {
            public string Name { get; set; }
        }
    }
}
