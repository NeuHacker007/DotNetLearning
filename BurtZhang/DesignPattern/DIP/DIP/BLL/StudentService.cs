using System;
using IBLL;
using IDAL;

namespace BLL
{
    

    public class StudentService : IStudentService
    {
        public void Study()
        {
            Console.WriteLine("Learn with Ivan");
        }

        ///// <summary>
        ///// 依赖细节，导致底层的变化传递到上层
        ///// </summary>
        ///// <param name="phone"></param>

        //public void PlayPhone(Iphone phone)
        //{
        //    Console.WriteLine($" {nameof(phone)}");
        //    phone.Call();
        //    phone.Text();
        //}
        //public void PlayLumia(Lumia phone)
        //{
        //    Console.WriteLine($" {nameof(phone)}");
        //    phone.Call();
        //    phone.Text();
        //}


        // 更具扩展性， 
        public void Play(AbstractPhone phone)
        {

            Console.WriteLine($" {nameof(phone)}");
            phone.Call();
            phone.Text();
        }
    }
}
