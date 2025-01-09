using AutoMapper;
using DataAccessLayer;
using DataAccessLayer.Models;
using Models;

namespace BusinessLayer
{
    public class TraitService : Service, ITraitService
    {
        public TraitService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public TraitModel Get(int id)
        {
            //Get the Trait
            var trait = UnitOfWork.TraitRepository.Get(id);

            //Create the model to map the Trait entity to
            var model = new TraitModel();

            //Do the mapping
            _mapper.Map(trait, model);

            return model;
        }

        public int Add(TraitModel model)
        {
            // Validate the Trait model
            Validate(model);

            var data = new Trait();
            _mapper.Map(model, data);

            //Add the Trait to the repository and save
            UnitOfWork.TraitRepository.Add(data);
            UnitOfWork.Save();

            return data.ID;
        }

        public int Update(TraitModel model)
        {
            // Validate the Trait model
            Validate(model);

            //Retrive the Trait to update
            var data = UnitOfWork.TraitRepository.Get(model.ID);

            //Map the model to the enitity
            _mapper.Map(model, data);

            //Update and save the 
            UnitOfWork.TraitRepository.Update(data);
            UnitOfWork.Save();

            return data.ID;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<TraitModel> List()
        {
            throw new NotImplementedException();
        }

        public IList<TraitModel> Search(Dictionary<string, List<FilterCriteria>> filters)
        {
            throw new NotImplementedException();
        }
    }
}
