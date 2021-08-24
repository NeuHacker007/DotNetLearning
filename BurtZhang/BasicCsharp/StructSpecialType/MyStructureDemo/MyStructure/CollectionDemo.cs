using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStructure
{
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
          

        }
    }
}
