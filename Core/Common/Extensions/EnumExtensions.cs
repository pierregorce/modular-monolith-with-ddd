using System;
using System.Collections.Generic;

namespace Core.Common.Extensions
{
    public static class EnumExtensions
    {
        public static int GetInt(this System.Enum enumValue)
        {
            return (int)((object)enumValue);
        }

        public static string GetString(this System.Enum enumValue)
        {
            return enumValue.ToString();
        }

        public static T ToEnum<T>(this string value, bool ignoreCase = true)
        {
            return (T)Enum.Parse(typeof(T), value, ignoreCase);
        }

        public static bool IsInEnum(this System.Enum enumValue)
        {
            return Enum.IsDefined(enumValue.GetType(), enumValue);
        }

        public static bool IsInEnum<T>(this System.Enum enumValue, IList<T> allowedValues)
        {
            if (!allowedValues.Contains(enumValue.As<T>())) return false;
            return Enum.IsDefined(enumValue.GetType(), enumValue);
        }
    }
}
