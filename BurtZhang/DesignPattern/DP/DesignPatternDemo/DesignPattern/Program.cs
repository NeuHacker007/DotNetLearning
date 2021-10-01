﻿using System;

namespace DesignPattern
{
    /// <summary>
    /// 设计模式： 面向对象语言开发过程中，遇到的种种问题和场景，提出的解决方案和思路，沉淀总结
    ///           套路 具体的套路
    ///
    /// 1. 创建型设计模式： 关注对象的创建
    ///     * 单例模式 : 把对象的创建权限关闭，提供一个方法，起到对象重用
    ///     * 原型模式 : 把对象的创建权限关闭，提供一个方法，提供全新的对象
    ///  三大工厂
    ///     * 简单工厂： (不属于GOF23种设计模式) 一个静态方法完成一组对象的创建
    ///     * 工厂方法：每个工厂只负责一个对象的创建
    ///     * 抽象工厂： 每个工厂负责一个产品簇的创建 工厂+ 约束
    ///     * 建造者模式： 是为了创建一个更复杂的对象
    /// 2. 结构型设计模式： 关注类与类之间的关系
    ///     面向对象 -- 类 -- 交互才能产生功能
    /// 纵向关系： 继承， 实现 关系肯定非常紧密
    /// 横向关系：关系依次变强
    ///         1. 依赖： 是方法内部出现的新类型
    ///         语义上的划分
    ///         2. 关联
    ///         3. 组合
    ///         4. 聚合
    ///
    /// 组合优于继承
    ///
    ///     1.适配器模式: 把一个类适配到原有的接口上，可以组合 可以继承
    ///     2.代理模式: 通过代理类来访问业务类，在不修改业务的前提下可以扩展功能
    ///     3.装饰器模式：可以动态的为类型添加功能， 甚至调整功能顺序， 而不修改业务类
    ///</summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
            }
        }
    }
}
