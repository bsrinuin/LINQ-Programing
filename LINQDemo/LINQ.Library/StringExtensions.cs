using System;
using System.Globalization;
using System.Threading;

namespace LINQ.Library
{
    public static class StringExtensions
    {
        ///Converts list of strings to title case 
        ///This is a extension class , ALways should have Static class and static metod and first method should have this keyword

        public static string ConvertToTitleCase(this string source)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textinfo = cultureInfo.TextInfo;

            return textinfo.ToTitleCase(source);


        }
    }
}
