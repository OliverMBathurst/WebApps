using System.Linq;
using System.Reflection;

namespace EntropyServer.Extensions
{
    public static class ObjectExtensions
    {
        public static bool CheckValue<T>(this object obj, string propertyName, T expectedValue) => obj.GetType().GetProperties().CheckValue(obj, propertyName, expectedValue);

        public static bool GetValue<T>(this object obj, string propertyName, out T value)
        {
            var propertyResult = obj.GetType().GetProperties().FirstOrDefault(x => x.Name.Equals(propertyName));
            if (propertyResult != null)
            {
                var propertyValue = propertyResult.GetValue(obj);
                if (propertyValue is T targetTypeResult)
                {
                    value = targetTypeResult;
                    return true;
                }
            }

            value = default;
            return false;
        }

        public static bool GetValue<T>(this PropertyInfo[] props, object targetObject, string propertyName, out T value)
        {
            var propertyResult = props.FirstOrDefault(x => x.Name.Equals(propertyName));
            if (propertyResult != null)
            {
                var propertyValue = propertyResult.GetValue(targetObject);
                if (propertyValue is T targetTypeResult)
                {
                    value = targetTypeResult;
                    return true;
                }
            }

            value = default;
            return false;
        }

        public static bool CheckValue<T>(this PropertyInfo[] props, object targetObject, string propertyName, T expectedValue)
        {
            var prop = props.FirstOrDefault(x => x.Name.Equals(propertyName));
            if (prop != null)
            {
                var properyValue = prop.GetValue(targetObject);
                return properyValue is T comparisonValue && comparisonValue.Equals(expectedValue);
            }

            return false;
        }
    }
}
