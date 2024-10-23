using SerializationFramework.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace SerializationFramework.Validations
{
    public interface DataAnnotationsValidator
    {
        public class DataAnnotationsValidator<T> : IValidator<T>
        {
            public bool Validate(T obj, out IEnumerable<string> errors)
            {
                var context = new ValidationContext(obj, null, null);
                var results = new List<ValidationResult>();
                bool isValid = Validator.TryValidateObject(obj, context, results, true);

                errors = results.Select(r => r.ErrorMessage);
                return isValid;
            }
        }
    }
}
