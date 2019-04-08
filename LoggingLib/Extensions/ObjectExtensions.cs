using System.Collections.Generic;

namespace LoggingLib.Extensions
{
    public static class ObjectExtensions
    {
        public static List<KeyValuePair<string, object>> GetProperties(this object me)
        {
            var result = new List<KeyValuePair<string, object>>();
            foreach (var property in me.GetType().GetProperties())
            {
                if (property.GetValue(me) is Dictionary<string, object> currValue)
                {
                    foreach (var keyValuePair in currValue)
                    {
                        result.Add(new KeyValuePair<string, object>(keyValuePair.Key, keyValuePair.Value));
                    }
                }
                else
                {
                    result.Add(new KeyValuePair<string, object>(property.Name, property.GetValue(me)));
                }
            }
            return result;
        }
    }
}