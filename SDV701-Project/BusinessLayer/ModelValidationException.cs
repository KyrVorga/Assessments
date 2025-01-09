using System.ComponentModel.DataAnnotations;

namespace BusinessLayer
{
    /// <summary>
    /// Represents an exception that is thrown when model validation fails.
    /// </summary>
    public class ModelValidationException : Exception
    {
        /// <summary>
        /// Gets the collection of validation errors.
        /// </summary>
        public ICollection<ValidationResult> Errors { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelValidationException"/> class.
        /// </summary>
        public ModelValidationException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelValidationException"/> class with a specified error message and a collection of <see cref="ValidationResult"/>.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="errors">The collection of validation errors.</param>
        public ModelValidationException(string message, ICollection<ValidationResult> errors) : base(message)
        {
            Errors = errors;
        }
    }
}
