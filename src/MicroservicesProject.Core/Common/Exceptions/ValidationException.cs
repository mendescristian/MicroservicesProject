using FluentValidation.Results;

namespace MicroservicesProject.Core.Common.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public ValidationException()
            : base("One or more validation error have occured. Please contact develop squad.")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(IEnumerable<ValidationFailure> errors) : this()
        {
            Errors = errors.GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                           .ToDictionary(g => g.Key, g => g.ToArray());
        }

        public IDictionary<string, string[]> Errors { get; }
    }

}
