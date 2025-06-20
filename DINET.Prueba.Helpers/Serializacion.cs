using System.Reflection;
using System.Web;

namespace DINET.Prueba.Helpers
{
    /// <summary>
    /// Serializacion
    /// </summary>
    public static class Serializacion
    {
        /// <summary>
        /// ToDictionary
        /// </summary>
        public static Dictionary<string, string?> ToDictionary(this object source)
        {
            return source.GetType()
                         .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                         .Where(prop => prop.GetValue(source, null) != null)
                         .ToDictionary(
                             prop => prop.Name,
                             prop => FormatValue(prop.GetValue(source, null))
                         );
        }

        /// <summary>
        /// Format Value
        /// </summary>
        private static string? FormatValue(object? value)
        {
            if (value == null) return null;

            return value switch
            {
                DateTime dateTime => dateTime.ToString("yyyy-MM-ddTHH:mm:ss"), // ISO 8601 format
                DateTimeOffset dateTimeOffset => dateTimeOffset.ToString("yyyy-MM-ddTHH:mm:ss"), // ISO 8601 format
                _ => value.ToString()
            };
        }

        /// <summary>
        /// ToQuery String
        /// </summary>
        public static string ToQueryString(Dictionary<string, string?> parameters)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);
            foreach (var param in parameters)
            {
                if (!string.IsNullOrEmpty(param.Value))
                {
                    query[param.Key] = param.Value;
                }
            }
            return "?" + query.ToString();
        }
    }
}