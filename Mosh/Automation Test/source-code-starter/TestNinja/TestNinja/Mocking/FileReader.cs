/**
* @Project Name: $projectname$ ： FileReader
* @Project Desc: 
* 
* @Machine Name: IVAN_ZHANG
* @Namespace Name: TestNinja.Mocking
* @Creation Time:  3/14/2018 5:43:09 PM
* @Author Ivan 
* @Email  yf.eva.yifan@gmail.com
* 
* @Change Log
*
* Version       Change Date               Changed By                  Changes
* ───────────────────────────────────────────────────────────────────────────────
* V0.01          3/14/2018 5:43:09 PM                    Ivan                  Initial
*
* Copyright (c) @ Yifan Zhang 2018.  All rights reserved.
*
*/
using System.IO;

namespace TestNinja.Mocking
{
    public interface IFileReader
    {
        string Read(string path);
    }

    class FileReader : IFileReader
    {
        public string Read(string path)
        {
            return File.ReadAllText(path);
        }
    }

    public class FileReaderForTest : IFileReader
    {
        public string Read(string path)
        {
            return "";
        }
    }
}
