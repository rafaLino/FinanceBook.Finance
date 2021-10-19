using System;

namespace FinanceBook.Finance.Application.Core.Extensions
{
    public static class StringExtensions
    {
        public static T AsEnum<T>(this string value, bool ignoreCase = true) where T : Enum => (T)Enum.Parse(typeof(T), value, ignoreCase);
    }
}
