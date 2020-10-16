using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Scalert_Dairy.Utility
{
    public static class StringHelperExtention
    {
        public static string Trucate(this string value, int length,bool ellipsis = false)
        {
            if(length > value.Length)
            {
                if (ellipsis)
                    return string.Concat(value," ","......");
                return value;
            }
            var shortenedString = value.Substring(0, length);
            if (ellipsis)
                return string.Concat(shortenedString," ", "......");
            return shortenedString;
          
        }
    }
}