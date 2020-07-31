using System;
using System.Collections.Generic;
using System.Text;

namespace LinqInternalDemo
{
    public class Phone
    {
        public string Number { get; set; }
        public PhoneType PhoneType { get; set; }
        public Contact[] Contacts { get; set; }
    }

}
