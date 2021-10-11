using System;
using DAL;
using IDAL;

namespace IBLL
{
    public interface IStudentService
    {
        void Study();
        //void PlayPhone(Iphone phone);
        //void PlayLumia(Lumia phone);
        void Play(AbstractPhone phone);

    }
}
