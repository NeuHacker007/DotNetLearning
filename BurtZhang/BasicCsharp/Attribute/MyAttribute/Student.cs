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
        public string Name { get; set; }

        [Custom]
        public void Study()
        {
            Console.WriteLine($"{this.Name} learn");
        }
        [Custom]
        [return: Custom]
        public string Answer([Custom] string name)
        {
            return $"{name}";
        }

    }
}
