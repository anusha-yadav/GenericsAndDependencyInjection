namespace SerializationFramework.Interfaces
{
    /// <summary>
    /// Serializer interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISerializer<T> where T : class
    {
        string Serialize(T obj);
        T Deserialize(string data);
    }
}
