using System;
using System.Web;

namespace TropicalServer.Helper
{
    public class UtilityTools
    {
        public static void CreateCookies(string cookiename, string key, string value, int hours = 1)
        {
            HttpCookie loginIdCookie = new HttpCookie(cookiename);
            loginIdCookie.Values[key] = value;
            loginIdCookie.Expires = DateTime.Now.AddHours(hours);
        }
    }
}