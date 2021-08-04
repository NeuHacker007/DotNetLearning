﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute
{
    /// <summary>
    /// 特性：
    /// 1. 是一个类
    /// 2. 必须直接或间接继承 attribute 类
    /// 3. 一般以attribute结尾，声明时可以省略
    /// </summary>
    ///
    
    // this allow to use the same attribute multiple times
    // [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    // attributeTargets 指定可以修饰那种类型
    // inherited 是否允许子类继承该attribute。默认为true
    [AttributeUsage(
        AttributeTargets.Class | 
        AttributeTargets.Method, 
        AllowMultiple = true, 
        Inherited = true)]
    public class CustomAttribute : Attribute
    {
        public CustomAttribute()
        {
            
        }

        public CustomAttribute(int id)
        {
            
        }

        public string Description { get; set; }

        public string Remark = null;

        public void SHow()
        {
            Console.WriteLine($"this is {nameof(CustomAttribute)}");
        }

        //也可以写委托， 事件

    }
}
