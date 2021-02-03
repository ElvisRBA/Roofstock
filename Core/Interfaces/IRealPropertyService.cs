using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    // Interface of the RealPropertyService methods that I can make us of. 
    public interface IRealPropertyService
    {
         Task<RealProperty> CreateRealPropertyAsync(RealProperty realProperty);
         Task<RealProperty> GetRealPropertyByIdAsync(int id);
         Task<IReadOnlyList<RealProperty>> GetRealPropertiesAsync();
    }
}