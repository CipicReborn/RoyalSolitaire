using System;

namespace Utils
{
    public class EnumUtils
    {

        public static T[] GetValues<T>()
        {
            return (T[])Enum.GetValues(typeof(T));
        }
    }
}