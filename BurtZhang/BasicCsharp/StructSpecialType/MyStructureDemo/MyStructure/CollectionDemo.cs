using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStructure
{
    /// <summary>
    ///
    /// IEnumerable 任何数据集合，都实现该接口， 该接口为不同的数据结构，提供了统一的访问方法
    ///             这个就是迭代器模式
    /// </summary>
    public class CollectionDemo
    {
        public static void Show()
        {
            {
                // Array 类型
                {
                    //Array： 在内存上连续分配，且元素类型一致
                    //可以访问坐标 读取快--增删慢 长度不变
                    Console.WriteLine("************Array**********");

                    int[] intArray = new int[3];
                    intArray[0] = 1;
                    string[] strings = new string[] {"123", "234"};
                }

                {
                    // ArrayList 不定长， 连续分配的
                    // 元素没有类型限制，任何元素都是当成object 处理, 如果是值类型，会有装箱操作
                    // 可以访问坐标 读取快--增删慢
                    Console.WriteLine("*******************Array List****************");
                    ArrayList arrayList = new ArrayList();

                    arrayList.Add("Ivan");
                    arrayList.Add("Is");
                    arrayList.Add(32);
                    //arrayList[4] = 26; //索引赋值 不会增加长度，会报错因为空间不足


                }
                {
                    //List: 也是Array 内存上都是连续摆放的，可以以索引方式访问
                    // 不定长； 泛型, 保证类型安全，避免装箱拆箱
                    // 可以访问坐标 读取快--增删慢
                    Console.WriteLine("*********************List ***********************");

                    List<int> intList = new List<int>() {1, 2, 3, 4};

                    List<string> strList = new List<string>();

                    //strList[0] = "1"; // 异常，原因同上
                }
            }

            {
                // 链表 
                {
                    //LinkedList: 泛型特点; 链表 元素不连续分配，每个元素都有记录前后节点
                    // 找元素只能遍历 查找不方便
                    // 增删 比较方便
                    Console.WriteLine("********************************Linked List**************************");

                    LinkedList<int> linkedList = new LinkedList<int>();

                    linkedList.AddFirst(123);
                    linkedList.AddLast(234);
                    var isContain = linkedList.Contains(123);

                    LinkedListNode<int> node123 = linkedList.Find(123);

                    if (node123 == null) return;
                    linkedList.AddBefore(node123, 0);
                    linkedList.AddAfter(node123, 9);

                    linkedList.Remove(234);
                    linkedList.Remove(node123);

                    linkedList.RemoveFirst();
                    linkedList.RemoveLast();
                }

                {
                    //Queue： 就是链表 先进先出 放任务 延迟执行， A 不断写入日子任务 B 不断获取任务去执行
                    Console.WriteLine("******************Queue*********************");

                    Queue<string> nums = new Queue<string>();

                    nums.Enqueue("one");
                    nums.Enqueue("two");
                    nums.Enqueue("three");
                }

                {
                    // Stack 也是链表 先进后出 解析表达目录树的时候 先产生的数据后使用
                    Console.WriteLine("*************************Stack**********************");

                    Stack<string> stack = new Stack<string>();
                    stack.Push("one");
                    stack.Push("Two");
                    stack.Push("Three");
                    stack.Push("Four");
                    stack.Push("Five");
                }
            }

            {
                //SET 集合
                
                {
                    //HashSet: hash分布， 元素间没有关系，动态增加容量，可以去重
                    //统计用户 IP 交差并补 -- 二次好友/间接关注/共同好友/粉丝合集
                    Console.WriteLine("*******************HashSet********************");
                    HashSet<string> hash = new HashSet<string>();

                    hash.Add("123");
                    hash.Add("456");
                    hash.Add("789");
                    hash.Add("987");
                    hash.Add("765");
                    hash.Add("543");
                    hash.Add("321");
                    hash.Add("321");
                    hash.Add("321");
                    hash.Add("321");
                    {
                        HashSet<string> hash1 = new HashSet<string>();
                        hash1.Add("123");
                        hash1.Add("789");
                        hash1.Add("111");

                        hash1.SymmetricExceptWith(hash); // 补
                        hash1.UnionWith(hash); // 并
                        hash1.ExceptWith(hash); // 差
                        hash1.IntersectWith(hash); // 交
                    }
                }

                {
                    //排序集合 去重且排序
                    // 统计排名 -- 每统计一个就丢进去集合
                    Console.WriteLine("*********************SortedList*******************");

                    SortedSet<string> sortedSet = new SortedSet<string>();

                   sortedSet.Add("123");
                   sortedSet.Add("456");
                   sortedSet.Add("789");
                   sortedSet.Add("987");
                   sortedSet.Add("765");
                   sortedSet.Add("543");
                   sortedSet.Add("321");
                   sortedSet.Add("321");
                   sortedSet.Add("321");
                   sortedSet.Add("321");

                }
            }
            {
                // HashTable key-value 不定长 拿着key计算一个地址，然后放入key-value
                // object - 装箱拆箱 如果不同的key得到相同的地址，第二个在前面地址+1
                // 查找的时候，如果地址对应数据的key不对，那就+1 查找
                // 浪费空间，hashtable是基于数组实现的
                // 查找数据 一次定位；增删 一次定位 增删改查都很快
                // 数据太多，重复定位，效率就下去了。
                {
                    Console.WriteLine("*************************Hash Table***************************");

                    Hashtable table = new Hashtable();
                    table.Add("123","456");
                    table[234] = 456;
                    table["ivan"] = 456;

                    Hashtable.Synchronized(table);// 线程安全
                }

                {
                    //字典 泛型 key-value 增删改查都很快，有序
                    Console.WriteLine("********************************Dictionary***************************");

                    Dictionary<int, string> dic = new Dictionary<int, string>();
                    dic.Add(1, "haha");
                }
                {
                    Console.WriteLine("******************Sorted Dictionary*********************");

                    SortedDictionary<int, string> dic = new SortedDictionary<int, string>();

                    dic.Add(1, "Ivan");
                    dic.Add(3, "Ivan1");
                    dic.Add(2, "Ivan2");
                }
                {
                    Console.WriteLine("***************Sort List*******************");

                    SortedList sortedList = new SortedList();


                    sortedList.Add("First", "Hello");
                    sortedList.Add("Second", "Hello");
                    //sortedList.Add("Second", "Hello"); // 不能重复key

                }

                {
                    List<string> fruit = new List<string>()
                    {
                        "apple",
                        "apple",
                        "apple",
                        "apple",
                        "apple",
                        "apple",
                        "apple"
                    };
                                     
                    IEnumerable<string> query = fruit.Where(fruit => fruit.Length > 6); // where 中是传入的委托

                    foreach (var item in query) // 遍历才会去查询比较 迭代器 yield
                    {
                        
                    }

                    IQueryable<string> queryable = fruit.AsQueryable<string>().Where(s => s.Length > 5);// where 中传入的是表达式目录树

                    foreach (var item in queryable) // 表达式目录树的解析， 延迟到遍历时候才去执行， EF的延迟查询
                    {
                        
                    }
                }
               
            }
          

        }
    }
}
