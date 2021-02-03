using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Services
{
    // This service is created to perform the principal functionalities of the RealProperty entity.
    public class RealPropertyService : IRealPropertyService
    {
        private readonly IUnitOfWork _unitOfWork;

        // Injecting unitOfWork so I can track and save the changes of the service. 
        public RealPropertyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        // This method is responsible for creating a property inside the database.
        public async Task<RealProperty> CreateRealPropertyAsync(RealProperty realProperty)
        {
            // create RealProperty
            var realPropertyToCreate = new RealProperty(realProperty);
            _unitOfWork.Repository<RealProperty>().Add(realPropertyToCreate);

            // save to db
            var result = await _unitOfWork.Complete();

            if (result <= 0) return null;

            // return RealProperty
            return realPropertyToCreate;
        }

        // This method is responsible for getting a specific property from the database by its id.
        public async Task<RealProperty> GetRealPropertyByIdAsync(int id)
        {
            return await _unitOfWork.Repository<RealProperty>().GetByIdAsync(id);
        }

        // This method is responsible for getting all the properties from the internal database.
        public async Task<IReadOnlyList<RealProperty>> GetRealPropertiesAsync()
        {
            return await _unitOfWork.Repository<RealProperty>().ListAllAsync();
        }
    }
}