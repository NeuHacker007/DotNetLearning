using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOA.BackEnd
{
    /// <summary>
    /// 1 SOA 的思想， 分布式服务
    /// 2. 建立web service
    /// 3. WCF多宿主多协议
    /// 4. 单元测试服务调用
    ///
    /// SOA： 面向服务架构，搭建分布式的设计思想
    ///       系统架构改进升级， 做资源整合， SOA
    ///       可以把系统/功能模块分拆到不同的服务器上，提高承载能力
    ///
    /// 三种跨进程/跨服务器：
    ///
    /// 1. 数据库/queue
    ///     没有门槛
    ///     被动的，需要使用者主动去pull 数据
    /// 2. Remoting
    ///     两边都必须是.NET 技术
    ///     需要使用marshell object
    /// 
    /// 3. Web Service/WCF/WebApi
    ///     数据序列化传递， 传递数据(性能比RPC低， 但是灵活)
    ///     根据数据执行操作
    ///     跨平台/跨语言/HTTP 穿透防火墙
    ///
    /// WebService: 托管于IIS web的形式 只支持 http/https
    ///     1）http 协议： 基于HTTP完成的请求/响应 (数据传输是以HTTP进行的)
    ///     2）XML 格式： 跨平台
    ///     3）SOAP 协议: 是用来把一个操作翻译成XML，也可以把XML还原成操作
    ///     4) WSDL: Webservice description language (method parameter)
    ///     5) UDDI: 找服务的机制
    /// WebService: 不支持泛型
    /// 安全问题：
    ///     1） 内部使用，不存在
    ///     2） Form Windows 身份
    ///     3） 加个参数， token 定时更新+沟通
    ///     4） SoapHeader
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
