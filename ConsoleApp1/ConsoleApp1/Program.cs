using System;
using System.Linq;
using System.Collections.Generic;
namespace ConsoleApp1
{
    //public class Node
    //{
    //    public int data;
    //    public int key;
    //    public List<Node> children;

    //    public Node(int data, int key)
    //    {
    //        this.data = data;
    //        this.key = key;
    //        this.children = new List<Node>();
    //    }
    //}
    internal class Program
    {
        //public string? name;
        //public Nullable<DateTime> datetime = null;
        static void Main(string[] args)
        {

            //var arry = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //var result = Helper(arry, 0, new List<Node>());
            #region comments
            //int[] array = new int[] { 1, 2, 2, 3, 3, 3, 3, 4 };
            //Array.Sort(array);
            //var result = 0;

            //foreach(var item in array)
            //{
            //    Console.WriteLine($"result: {result}, item: {item}");
            //    result ^= item;
            //}
            // var list = new List<int>();
            //     int left = 0, right = array.Length - 1;

            //    var result = 0;

            //while (left <= right) {
            //    int mid = left + (right - left) / 2;
            //    if (array[mid] != array[mid - 1] && array[mid] != array[mid + 1]){
            //        result = array[mid];
            //        break;
            //    }
            //    else{
            //        int length = mid - left + 1;
            //        if (length % 2 == 0){
            //            left = mid + 1;
            //        }
            //        else {
            //            right = mid - 1;
            //        }
            //    }
            //}
            //   result  = array[left];

            //    Console.WriteLine(result);
            //LinkedList<Employee> list = new LinkedList<Employee>();
            //list.AddFirst(new Employee() { ID = 1 });
            //list.AddFirst(new Employee() { ID = 2 });
            //list.AddFirst(new Employee() { ID = 3 });
            //var lists = list.Where(x => x.ID == 2).ToList();

            //foreach (var item in lists)
            //{
            //    Console.WriteLine(item.ID);
            //}

            var str = "aabbhbccd";

            // var groupBy = str.GroupBy(x => x).Select(x => new
            // {
            //     key = x.Key,
            //     Count = x.Count()
            // });

            //foreach(var item in groupBy)
            // {
            //     Console.WriteLine($"char: {item.key} count: {item.Count}");
            // }

            Dictionary<char, int> dic = new Dictionary<char, int>();

            foreach (var item in str)
            {
                if (dic.ContainsKey(item))
                {
                    dic[item]++;
                }
                else
                {
                    dic.Add(item, 1);
                }
            }

            foreach (var item in dic)
            {
                Console.WriteLine($"item: {item.Key}, Count: {item.Value}");
            }
            #endregion 
        }

    //    public static Node Helper(int[] array, int start, List<Node> list)
    //    {
    //        if (start == array.Length) return ;
    //        if (list.Count == 3)
    //        {
    //            var minValue = list.First().key;
    //            var root = new Node(minValue, minValue);
    //            foreach (var item in list)
    //            {
    //                root.children.Add(item);
    //            }

    //            list.Clear();
    //           return root;
    //        }
    //        else
    //        {
    //            var node = new Node(array[start], array[start]);
    //            list.Add(node);
    //        }


    //       var newNode = Helper(array, start + 1, list);

    //        return newNode;
    //        // if (root.children.Count == k)
    //        // {
    //        //     //root.children.Add(node);
    //        //     var minValue = root.children.FirstOrDefault().key;
    //        //     var newNode = new Node(minValue, minValue);
    //        //     newNode.children

    //        // }
    //    }

    //    public class Employee
    //    {
    //        public int ID { get; set; }
    //    }

    //    public abstract class Employee2
    //    {
    //        public abstract void Add();

    //        public virtual void Add2()
    //        {
    //            Console.WriteLine("Test");
    //        }
    //    }


    //    public class Employee3 : Employee2
    //    {
    //        public override void Add()
    //        {
    //            throw new NotImplementedException();
    //        }

    //        public override void Add2()
    //        {
    //            Console.WriteLine("test2");
    //        }
    //    }



    //}
}
