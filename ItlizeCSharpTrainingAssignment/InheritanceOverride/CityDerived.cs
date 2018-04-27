/**
* @Project Name: $projectname$ ： CityDerived
* @Project Desc:
*
* @Machine Name: IVAN_ZHANG
* @Namespace Name: InheritanceOverride
* @Creation Time:  4/12/2018 7:12:04 PM
* @Author Ivan
* @Email  yf.eva.yifan@gmail.com
*
* @Change Log
*
* Version       Change Date               Changed By                  Changes
* ───────────────────────────────────────────────────────────────────────────────
* V0.01          4/12/2018 7:12:04 PM                    Ivan                  Initial
*
* Copyright (c) @ Yifan Zhang 2018.  All rights reserved.
*
*/
using System;

namespace InheritanceOverride
{
    class CityDerived : CityBase
    {
        private string cityname = "Boston";
        public override void DisplayCityName()
        {
            Console.WriteLine(cityname);
        }
    }
}
