/**
* @Project Name: $projectname$ ： CityBase
* @Project Desc:
*
* @Machine Name: IVAN_ZHANG
* @Namespace Name: InheritanceOverride
* @Creation Time:  4/12/2018 7:11:39 PM
* @Author Ivan
* @Email  yf.eva.yifan@gmail.com
*
* @Change Log
*
* Version       Change Date               Changed By                  Changes
* ───────────────────────────────────────────────────────────────────────────────
* V0.01          4/12/2018 7:11:39 PM                    Ivan                  Initial
*
* Copyright (c) @ Yifan Zhang 2018.  All rights reserved.
*
*/
using System;

namespace InheritanceOverride
{
    class CityBase
    {
        private string cityname = "malden";
        public virtual void DisplayCityName()
        {
            Console.WriteLine(cityname);
        }
    }
}
