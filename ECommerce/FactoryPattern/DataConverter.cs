using ProductManagement.Enums;
using SerializationFramework.Interfaces;
using SerializationFramework.Serializers;

namespace ProductManagement.FactoryPattern
{
    /// <summary>
    /// The DataConverter
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DataConverter<T> where T : class
    {
        /// <summary>
        /// To get serialized format
        /// </summary>
        /// <param name="formatType"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        public static ISerializer<T> GetSerializerFormat(FormatType formatType)
        {
            if (!typeof(T).IsDefined(typeof(SerializableAttribute), true))
            {
                throw new InvalidOperationException($"The class {typeof(T).Name} must be marked with [Serializable] attribute to be serialized.");
            }

            return formatType switch
            {
                FormatType.Json => new JsonSerializerHandler<T>(),
                FormatType.Xml => new XmlSerializerHandler<T>(),
                _ => throw new NotSupportedException()
            };
        }
    }
}
