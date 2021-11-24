using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using SOA.WebAPI.Unity;

namespace SOA.WebAPI
{
    /// <summary>
    ///
    /// .NET Remoting: 平台要求 必须两边都是windows
    /// WebService: 跨平台 SOAP/XML http
    /// WFC: 集大成者 重
    /// 以上三种定义后台接口，调用的方法
    ///
    /// RESTFul: 一种架构风格，以资源为视角来描述服务的
    ///          移动互联网: json/xml来描述，http方法，统一了数据操作
    ///     资源： 实体就是资源 json/XML/数据流
    ///     统一接口: CRUD 是通过HTTP的method体现的 get | post | put/patch | delete
    ///     URI: url
    ///     无状态: http无状态 前后没有关联
    /// 
    /// 路由：
    ///  1. 启动 Application_Start -- WebApiConfig.Register--把路由规则写入容器
    ///  2. 运行 请求会去容器匹配--找到(第一个满足)的控制器--然后找到action (http method)
    ///         a. 以特性为准[HttpGet][HttpPost][HttpPut][HttpDelete]
    ///         b. 以get开头
    ///         c. (找方法的时候)优先最匹配 api/values/1 --Get(int id)
    ///     一个资源，同一种操作更新，可能有多个来源途径
    ///     版本号：
    ///
    ///     特性路由:
    ///     1. config.MapHttpAttributeRoutes();
    ///     2. 控制器/action都可以写特性；
    /// </summary>
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.DependencyResolver = new UnityDependencyResolver(UnitContainerFactory.GetContainer());
            // Web API routes
            config.MapHttpAttributeRoutes(); //特性路由

            //一般不指定action 因为RESTFul，是以资源为目标的，没有操作的概念
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "UserApi",
                routeTemplate: "userapi/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
