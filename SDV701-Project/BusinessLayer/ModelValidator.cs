using System.ComponentModel.DataAnnotations;

namespace BusinessLayer
{
    /// <summary>
    /// Provides functionality to validate models against their data annotations.
    /// </summary>
    internal class ModelValidator
    {
        /// <summary>
        /// Gets the list of validation errors from the last validation.
        /// </summary>
        public ICollection<ValidationResult> Errors { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelValidator"/> class.
        /// </summary>
        public ModelValidator()
        {
            Errors = new List<ValidationResult>();
        }

        /// <summary>
        /// Validates the specified model against its data annotations.
        /// </summary>
        /// <param name="model">The model to validate.</param>
        /// <returns><c>true</c> if the model is valid; otherwise, <c>false</c>.</returns>
        public bool Validate(object model)
        {
            Errors.Clear();

            var context = new ValidationContext(model, null, null);

            return Validator.TryValidateObject(model, context, Errors, true);
        }
    }
}
