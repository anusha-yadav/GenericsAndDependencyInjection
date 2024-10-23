using SerializationFramework.Interfaces;

namespace SerializationFramework.Serializers
{
    /// <summary>
    /// The Custom Serailization
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CustomSerializerHandler<T> : ISerializer<T> where T : class
    {
        /// <summary>
        /// To Serialize the object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string Serialize(T obj)
        {
            var properties = typeof(T).GetProperties();
            return string.Join(";", properties.Select(p => $"{p.Name}={p.GetValue(obj)}"));
        }

        /// <summary>
        /// To deserialize the object
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public T Deserialize(string data)
        {
            var obj = Activator.CreateInstance<T>();
            var properties = typeof(T).GetProperties();
            var keyValuePairs = data.Split(';');
            foreach (var kvp in keyValuePairs)
            {
                var pair = kvp.Split('=');
                var property = properties.FirstOrDefault(p => p.Name == pair[0]);
                if (property != null)
                {
                    var convertedValue = Convert.ChangeType(pair[1], property.PropertyType);
                    property.SetValue(obj, convertedValue);
                }
            }
            return obj;
        }
    }
}
