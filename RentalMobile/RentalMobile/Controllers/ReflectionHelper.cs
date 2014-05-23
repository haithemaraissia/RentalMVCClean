using System;
using System.Collections.Generic;
using System.Linq;

namespace RentalMobile.Controllers
{
    public static class ReflectionHelper
    {
        public static Boolean ToStringNullSafe(this object obj)
        {
            if (obj != null)
            {
               var result = obj is bool;
               return result;
            }
            return false;

        }

        public static IEnumerable<string> Compare<T>(T a, T b, params string[] ignore)
        {
            var changes = new List<string>();
            var aProps = a.GetType().GetProperties();
            var bProps = b.GetType().GetProperties();
            int count = aProps.Count();
            for (int i = 0; i < count; i++)
            {
                bool aa = aProps[i].GetValue(a, null).ToStringNullSafe();
                bool bb = bProps[i].GetValue(b, null).ToStringNullSafe();
                if (aa != bb &&  aa && ignore.All(x => x != aProps[i].Name))
                {
                    changes.Add(string.Format("Property {0} changed from {1} to {2}", aProps[i].Name, true, false));
                   
                }
            }
            return changes;
        }
    }
}