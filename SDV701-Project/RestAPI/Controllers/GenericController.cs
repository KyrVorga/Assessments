using BusinessLayer;
using Microsoft.AspNetCore.Mvc;

namespace RestAPI.Controllers
{
    /// <summary>
    /// Represents a generic controller for handling CRUD operations.
    /// </summary>
    /// <typeparam name="TService">The service type that this controller interacts with.</typeparam>
    /// <typeparam name="TModel">The model type that this controller manages.</typeparam>
    [Route("api/[controller]")]
    [ApiController]
    public partial class GenericController<TService, TModel> : ControllerBase where TService : IService<TModel>
    {
        private TService _service;

        /// <summary>
        /// Gets or sets the service used by the controller.
        /// </summary>
        protected TService Service { get => _service; set => _service = value; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericController{TService, TModel}"/> class.
        /// </summary>
        /// <param name="service">The service to be used by the controller.</param>
        public GenericController(TService service)
        {
            Service = service;
        }

        /// <summary>
        /// Retrieves all instances of the model.
        /// </summary>
        /// <returns>An enumerable of all model instances.</returns>
        [HttpGet]
        public virtual IEnumerable<TModel> Get()
        {
            return Service.List();
        }

        /// <summary>
        /// Retrieves a specific instance of the model by ID.
        /// </summary>
        /// <param name="id">The ID of the model instance to retrieve.</param>
        /// <returns>The model instance.</returns>
        [HttpGet("{id}")]
        public virtual TModel Get(int id)
        {
            return Service.Get(id);
        }

        /// <summary>
        /// Adds a new instance of the model.
        /// </summary>
        /// <param name="model">The model instance to add.</param>
        /// <returns>The ID of the added model instance.</returns>
        [HttpPost]
        public virtual int Post([FromBody] TModel model)
        {
            return Service.Add(model);
        }

        /// <summary>
        /// Updates an existing instance of the model.
        /// </summary>
        /// <param name="model">The model instance to update.</param>
        /// <returns>The ID of the updated model instance.</returns>
        [HttpPut]
        public virtual int Put([FromBody] TModel model)
        {
            return Service.Update(model);
        }

        /// <summary>
        /// Deletes a specific instance of the model by ID.
        /// </summary>
        /// <param name="id">The ID of the model instance to delete.</param>
        [HttpDelete("{id}")]
        public virtual void Delete(int id)
        {
            Service.Delete(id);
        }

        /// <summary>
        /// Searches for model instances matching the specified criteria.
        /// </summary>
        /// <returns>A list of model instances matching the search criteria.</returns>
        [HttpGet("search")]
        public IList<TModel> Search()
        {
            var request = Request.Query;

            var filters = new Dictionary<string, List<FilterCriteria>>();

            // for each key in the query string, create a filter criteria
            foreach (var key in request.Keys)
            {
                var values = request[key];
                var filterCriteria = new List<FilterCriteria>();

                foreach (var filter in values)
                {
                    var operand = filter.Split(":")[0];
                    var value = filter.Split(":")[1];
                    filterCriteria.Add(new FilterCriteria { FilterName = key, Operation = operand, Value = value });
                }

                filters.Add(key, filterCriteria);
            }

            return Service.Search(filters);
        }
    }
}
