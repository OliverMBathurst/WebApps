using System.Reflection;

namespace EntropyServer.Extensions
{
    public static class ObjectExtensions
    {
        public static bool CheckValue<T>(this object obj, string propertyName, T expectedValue) => obj.GetType().GetProperties().CheckValue(obj, propertyName, expectedValue);

        public static bool GetValue<T>(this object obj, string propertyName, out T value)
        {
            if (obj.GetType().GetProperties().Find(x => x.Name.Equals(propertyName), out var propertyResult) && propertyResult != null)
            {
                if (propertyResult.GetValue(obj) is T targetTypeResult)
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
            if (props.Find(x => x.Name.Equals(propertyName), out var propertyResult) && propertyResult != null)
            {
                if (propertyResult.GetValue(targetObject) is T targetTypeResult)
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
            if (props.Find(x => x.Name.Equals(propertyName), out var prop) && prop != null)
            {
                var properyValue = prop.GetValue(targetObject);
                return properyValue is T comparisonValue && comparisonValue.Equals(expectedValue);
            }

            return false;
        }
    }
}
