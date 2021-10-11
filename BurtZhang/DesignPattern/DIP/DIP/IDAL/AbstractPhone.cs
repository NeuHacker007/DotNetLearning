using System;

namespace IDAL
{
    public abstract class AbstractPhone
    {
        public int Id { get; set; }
        public string Branch { get; set; }

        public abstract void Call();
        public abstract void Text();
    }
}
