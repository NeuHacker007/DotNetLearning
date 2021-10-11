using System;
using Factory;
using IBLL;
using IDAL;

namespace DIP
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Iphone phone = new Iphone();
                //Lumia lumia = new Lumia();

                //AbstractPhone phone = new Iphone();
                //AbstractPhone  lumia = new Lumia();
                {
                    

                   // StudentService studentService = new StudentService();//依赖
                    IStudentService studentService = SimpleFactory.CreateService();
                    studentService.Study();
                //    studentService.PlayPhone(phone);
                }
                {
                  //  IStudentService service = new StudentService(); // 依赖 左边换成抽象

                    //{
                    // IStudentService service = new StudentService(); // 依赖 左边换成抽象
                    //    // 每增加一个phone都要添加不同的play方法
                    //    service.PlayPhone(phone);
                    //    // service.PlayLumia(phone);
                    //    service.PlayLumia(lumia);
                    //}

                    {
                        // 1.加接口没有用
                        // 2. 不方便看代码 细节还是在依赖，依赖 StudentService
                        IStudentService service = SimpleFactory.CreateService(); // 依赖 左边换成抽象
                        AbstractPhone phone = SimpleFactory.CreatePhone();
                        service.Play(phone);
                     //   service.Play(lumia);
                        service.Study();
                    }

                    {
                        // 让别人来做， 第三方 封装

                    }





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
