using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PrototypePattern
{

    [Serializable]
    public class StudentPrototype
    {

        private static StudentPrototype _StudentPrototype = null;
        public int Id { get; set; }

        public string Name { get; set; }


        public Class Class { get; set; }

        private StudentPrototype()
        {
            long lResult = 0;

            for (int i = 0; i < 10000000; i++)
            {
                lResult += i;
            }

            Thread.Sleep(1000);

        }

        static StudentPrototype()
        {
            _StudentPrototype = new StudentPrototype();
            _StudentPrototype.Id = 1;
            _StudentPrototype.Name = "Eva";
            _StudentPrototype.Class.ClassId = 1;
            _StudentPrototype.Class.Name = "basic";
        }

        public static StudentPrototype CreateInstance()
        {

            // MemberwiseClone() 内存复制
            // 内存拷贝时 引用属性是拷贝的引用地址
            StudentPrototype model = (StudentPrototype)_StudentPrototype.MemberwiseClone();

            return model;
        }

        public static StudentPrototype CreateInstanceSerialize()
        {

            // MemberwiseClone() 内存复制
            // 内存拷贝时 引用属性是拷贝的引用地址
            return SerializeHelper.DeepClone<StudentPrototype>(_StudentPrototype);


        }


        public void Study()
        {

        }
    }
    [Serializable]
    public class Class
    {
        public int ClassId { get; set; }

        public string Name { get; set; }
    }
}
