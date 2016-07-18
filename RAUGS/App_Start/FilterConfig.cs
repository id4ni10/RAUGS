using System;
using System.Data;
using System.Web;
using System.Web.Mvc;

namespace RAUGS
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }

    public static class Extensions
    {
        public static DateTime ToDateTime(this object value)
        {
            return Convert.ToDateTime(value);
        }

        public static Int32 ToInt32(this object value)
        {
            return Convert.ToInt32(value);
        }

        public static Decimal ToDecimal(this object value)
        {
            return Convert.ToDecimal(value);
        }

        public static Boolean ToBoolean(this object value)
        {
            return (Boolean)value;
        }
    }
}
