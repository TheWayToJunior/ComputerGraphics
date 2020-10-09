using System;
using System.Reflection;

namespace PracticalWork4
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum obj)
        {
            var type = obj.GetType();
            var field = type.GetField(obj.ToString());
            var attribure = field.GetCustomAttribute(typeof(DescriptionAttribute), true);

            return (attribure as DescriptionAttribute)?.Value ?? obj.ToString();
        }
    }

    public class DescriptionAttribute : Attribute
    {
        public string Value { get; set; }
    }
}
