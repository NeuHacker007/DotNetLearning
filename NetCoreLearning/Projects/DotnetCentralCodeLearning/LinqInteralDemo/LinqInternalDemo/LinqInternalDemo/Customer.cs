using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LinqInternalDemo
{
    public class Customer
    {
        public string Name { get; set; }

        public Phone[] Phones { get; set; }
    }
}
