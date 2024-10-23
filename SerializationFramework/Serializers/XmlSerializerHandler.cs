using SerializationFramework.Interfaces;
using System.Xml.Serialization;

namespace SerializationFramework.Serializers
{
    /// <summary>
    /// The Xml Serializer
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class XmlSerializerHandler<T> : ISerializer<T> where T : class
    {
        /// <summary>
        /// To Serialize the object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string Serialize(T obj)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, obj);
                return writer.ToString();
            }
        }

        /// <summary>
        /// To Deserialize the object
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public T Deserialize(string data)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StringReader reader = new StringReader(data))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}
