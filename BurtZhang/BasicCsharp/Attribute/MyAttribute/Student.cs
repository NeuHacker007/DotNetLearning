using MyAttribute.Extension;
using System;

namespace MyAttribute
{
    //[Obsolete("obsolete", true)] // impact the compiler
    //[Serializable] //Serialize deserialize, can impact program running 
    //[Custom]
    //[Custom()]
    //[Custom(123), Custom(123, Description = "1234")]
    [Custom(123, Description = "1234", Remark = "2345")]
    public class Student
    {
        public int Id { get; set; }
        [Length(5, 10)]
        public string Name { get; set; }

        [Long(10001, 99999999999)]
        public long QQ { get; set; }

        #region OldStyle Datavalidation

        //这种写法用来解决数据合法性，但是给属性增加了太多的事儿
        //把业务逻辑强行嫁给属性了，影响了类型封装
        private long _QQ2 = 0;
        public long QQ2
        {
            get
            {
                return this._QQ2;
            }
            set
            {
                if (value > 10001 && value < 99999999999)
                {
                    _QQ2 = value;
                }
                else
                {
                    throw new Exception();
                }
            }
        }

        #endregion


        [Custom]
        public void Study()
        {
            Console.WriteLine($"{this.Name} learn");
        }
        [Custom(666, Description = "this is test", Remark = "777")]
        [return: Custom]
        public string Answer([Custom] string name)
        {
            return $"{name}";
        }

    }
}
