using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IRealPropertyService
    {
         Task<RealProperty> CreateRealPropertyAsync(RealProperty realProperty);
         Task<RealProperty> GetRealPropertyByIdAsync(int id);
         Task<IReadOnlyList<RealProperty>> GetRealPropertiesAsync();
    }
}