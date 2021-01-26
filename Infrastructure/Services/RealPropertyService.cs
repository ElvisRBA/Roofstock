using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Services
{
    public class RealPropertyService : IRealPropertyService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RealPropertyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

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

        public async Task<RealProperty> GetRealPropertyByIdAsync(int id)
        {
            return await _unitOfWork.Repository<RealProperty>().GetByIdAsync(id);
        }

        public async Task<IReadOnlyList<RealProperty>> GetRealPropertiesAsync()
        {
            return await _unitOfWork.Repository<RealProperty>().ListAllAsync();
        }
    }
}