using AutoMapper;
using DataAccessLayer;

namespace BusinessLayer
{
    /// <summary>
    /// Represents the base class for all services, providing shared functionality.
    /// </summary>
    public abstract class Service
    {
        /// <summary>
        /// Gets the unit of work for database operations.
        /// </summary>
        protected IUnitOfWork UnitOfWork { get; private set; }

        /// <summary>
        /// The AutoMapper instance used for entity mapping.
        /// </summary>
        protected readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="Service"/> class.
        /// </summary>
        /// <param name="mapper">The AutoMapper instance for entity mapping.</param>
        /// <param name="unitOfWork">The unit of work for database operations.</param>
        public Service(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        /// <summary>
        /// Validates the specified model against its data annotations.
        /// </summary>
        /// <param name="model">The model to validate.</param>
        /// <returns><c>true</c> if the model is valid; otherwise, <c>false</c>.</returns>
        /// <exception cref="ModelValidationException">Thrown when the model is invalid.</exception>
        protected virtual bool Validate(object model)
        {
            var modelValidator = new ModelValidator();
            if (!modelValidator.Validate(model))
            {
                throw new ModelValidationException($"{nameof(model)} is invalid", modelValidator.Errors);
            }
            return true;
        }
    }
}
