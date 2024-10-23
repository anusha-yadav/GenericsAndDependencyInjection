namespace SerializationFramework.Interfaces
{
    /// <summary>
    /// Validator interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IValidator<T>
    {
        bool Validate(T obj, out IEnumerable<string> errors);
    }
}
