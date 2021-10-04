using System;
using Ivan.Crawler.Framework.Http;

namespace Ivan.Crawler
{
    /// <summary>
    /// 1. 爬虫，爬虫攻防
    /// 2. 下载html log4net
    /// 3. Xpath 解析html， 获取数据和深度抓取
    /// 4. 惰性加载， Ajax加载数据， VUE 数据绑定
    /// 5. 不易呀昂的属性和Ajax数据的获取
    /// 6. 多线程抓取
    ///
    /// 爬虫： 一个自动提取网页的程序
    ///       url开始 -- 分析获取数据 && 找到url -- 递归下去 -- 结束
    ///       下载html--解析获取数据 -- 数据保存
    /// 爬虫的攻防：
    ///     1. robots 协议 (君子协定没有技术约束) --道德防线
    ///     2. 请求检测header -- 爬虫去都模拟一下
    ///     3. 用户登录 -- 请求的时候带上cookie
    ///     4. 爬虫频率高; 限制IP (黑名单/返回验证码) -- 多个IP(adsl 拨号/168伪装IP/代理IP)
    ///               验证码 -- 有开源组件做图片识别/打码平台
    ///     5. 大招： 数据js动态加载； 转图片; js手机用户操作，然后提交；用户控件(可以收集更多信息)
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                {
                    var html = HttpHelper.DownloadHtml("www.jd.com");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
