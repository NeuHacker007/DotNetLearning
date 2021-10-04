using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;


namespace Ivan.Crawler.Framework.Http
{
    public class HttpHelper
    {

        public static string DownloadHtml(string url)
        {
            string html = string.Empty;

            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;

                if (request == null)
                {
                    throw new HttpRequestException("Request Failed");
                }
                request.Timeout = 30 * 1000; //设置30s超时
                request.UserAgent = @"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/94.0.4606.61 Safari/537.36 Edg/94.0.992.31";
                request.ContentType = "text/html; charset=utf-8";
                request.Host = @"www.jd.com";
                request.Method = "GET";


                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response?.StatusCode != HttpStatusCode.OK)
                    {
                        Console.WriteLine($"Craw {url} failed Status{response.StatusCode}");
                    }
                    else
                    {
                        try
                        {
                            using StreamReader sr = new StreamReader(response.GetResponseStream());
                            html = sr.ReadToEnd();
                            
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            html = null;
                        }
                    }

                    return html;
                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
