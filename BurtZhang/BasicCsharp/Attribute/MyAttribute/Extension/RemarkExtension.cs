using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute.Extension
{
    /// <summary>
    /// User state
    /// </summary>
    public enum UserState
    {
        [Remark("Normal1")]
        Normal = 0, // 左边是字段名称， 右边是数据库值， 
        [Remark("Frozen2")]
        Frozen = 1,
       // [Remark("删除")]
        Deleted = 2
    }

    public class RemarkAttribute : Attribute
    {
        private string _remark = null;
        public RemarkAttribute(string remark)
        {
            _remark = remark;
        }

        public string GetRemark()
        {
            return this._remark;
        }
    }
    public static class RemarkExtension
    {
        public static string GetRemark(this Enum value)
        {
            Type type = value.GetType();

            FieldInfo field = type.GetField( value.ToString());

            if (field.IsDefined(typeof(RemarkAttribute), true))
            {
                RemarkAttribute attribute = field.GetCustomAttribute(typeof(RemarkAttribute), true) as RemarkAttribute;

                return attribute?.GetRemark();
            }
            else
            {
                return value.ToString();
            }
        }
    }
}
