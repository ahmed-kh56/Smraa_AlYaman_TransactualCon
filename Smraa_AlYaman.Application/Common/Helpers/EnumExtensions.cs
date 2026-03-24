using System;
using System.Collections.Generic;
using System.Text;

namespace Smraa_AlYaman.Application.Common.Helpers
{
    public static class EnumExtensions
    {
        public static TEnum ToEnum<TEnum>(this int value)
            where TEnum : struct, Enum
        {
            return (TEnum)(object)value;
        }

        public static bool TryToEnum<TEnum>(this int value, out TEnum result)
            where TEnum : struct, Enum
        {
            if (Enum.IsDefined(typeof(TEnum), value))
            {
                result = (TEnum)(object)value;
                return true;
            }

            result = default;
            return false;
        }

    }

}
