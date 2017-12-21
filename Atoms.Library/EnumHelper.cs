using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atoms.Library
{
    public static class EnumHelper
    {
        /// <summary>
        /// 静态方法：获取枚举键值列表(可用于下拉框)
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <returns></returns>
        public static List<KeyValue> EnumToList<T>(bool addAll = false, string allStr = "")
        {
            var list = (from Enum type in Enum.GetValues(typeof(T))
                        select new KeyValue { Value = type.GetHashCode(), Name = type.Description() }).ToList();
            if (addAll) list.Insert(0, new KeyValue { Name = "请选择"+ allStr, Value = 0 });
            return list;
        }

        /// <summary>
        /// 私有方法：获取当前枚举的描述
        /// </summary>
        /// <param name="temp">枚举类型</param>
        /// <returns></returns>
        public static string Description(this Enum temp)
        {
            var enumType = temp.GetType();
            try
            {
                var fieldInfo = enumType.GetField(temp.ToString());
                var attr = Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute), false) as DescriptionAttribute;
                return attr != null ? attr.Description : "";
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 扩展方法：根据值获取描述(可空)
        /// </summary>
        /// <returns>描述</returns>
        public static string GetDescNullable<T>(this int? value)
        {
            if (!value.HasValue) return string.Empty;
            var list = Enum.GetValues(typeof(T));
            foreach (var item in list.Cast<Enum>().Where(item => item.GetHashCode() == value))
                return item.Description();
            return string.Empty;
        }

        /// <summary>
        /// 扩展方法：根据值获取描述
        /// </summary>
        /// <returns>描述</returns>
        public static string GetDesc<T>(this int value)
        {
            var list = Enum.GetValues(typeof(T));
            foreach (var item in list.Cast<Enum>().Where(item => item.GetHashCode() == value))
                return item.Description();
            return "";
        }

    }



    /// <summary>
    /// 键值类型
    /// </summary>
    public class KeyValue
    {
        public string Name { get; set; }
        public int Value { get; set; }
    }
}
