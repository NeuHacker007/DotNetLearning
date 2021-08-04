using System;

namespace MyAttribute
{
    //[Obsolete("obsolete", true)] // impact the compiler
    //[Serializable] //Serialize deserialize, can impact program running 
    [Custom]
    [Custom()] 
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Custom]
        public void Study()
        {
            Console.WriteLine($"{this.Name} learn");
        }

        public string Answer(string name)
        {
            return $"{name}";
        }

    }
}
