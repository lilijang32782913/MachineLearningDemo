using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Common
{
    public static class EnumUtil
    {
        public static T GetByName<T>(string name)
        {
            var type = typeof(T);
            foreach (var v in Enum.GetValues(type))
            {
                if (Enum.GetName(type,v)==name)
                {
                    return (T)Enum.Parse(type, v.ToString(), true);
                }
            }
            return default(T);
        }
    }
}
