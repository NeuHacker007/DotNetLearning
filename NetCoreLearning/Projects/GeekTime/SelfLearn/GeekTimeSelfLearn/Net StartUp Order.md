Top to bottom 
![](./img/2022-11-23_22-46-20.png)

ConfigureHostConfiguration  -> 用于监听URL

ConfigureAppConfiguration -> 用于嵌入自己配置文件, 程序各个组件后续读取

ConfigureServices -> 用于注入自己应用的组件

Configure -> 注册中间件， 管理整个HTTPContext

.Net Core 自带DI框架

IServiceCollection   -> 负责注册服务
ServiceDescriptor  -> 注册服务时的信息
IServiceProvider -> 具体的容器， 由 ServiceCollection build 而成
IServiceScope -> 一个容器的子容器的生命周期
