using System;

namespace autobazar
{
    public class EnumReader
    {
        public static T ParseIntToEnum<T>(int numberToParse)
        {
            if (Enum.IsDefined(typeof(T), numberToParse))
            {
                return (T)Enum.ToObject(typeof(T), numberToParse);
            }
            else
            {
                return default(T);
            }
        }
    }
}
