using System;

namespace GeneralUtil
{
    public static class MappingUtil
    {
        public static T MapToEnum<T>(string strValue) where T : struct
        {
            if (Enum.TryParse(strValue, out T enumValue))
                return enumValue;
            else
                throw new ArgumentException(strValue);
        }
    }
}
