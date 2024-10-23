using Newtonsoft.Json;
using SerializationFramework.Interfaces;

namespace SerializationFramework.Serializers
{
    /// <summary>
    /// The JsonSerailizer 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class JsonSerializerHandler<T> : ISerializer<T> where T : class 
    {
        /// <summary>
        /// To Serialize the object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string Serialize(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// To Deserialize the object
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public T Deserialize(string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }

    }
}
