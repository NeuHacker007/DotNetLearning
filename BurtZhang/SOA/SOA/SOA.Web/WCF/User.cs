using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SOA.Web.WCF
{
    [DataContract] //1. 标准规范实体需要添加， 有无参构造函数是可以省略的
    public class User
    {
        public int Id { get; set; }

        [DataMember(Name = "ShortName")] //2. 有了DataContract 之后，必须有DataMember 否则不会看到，不会序列化
        public string Name { get; set; }
    }
}