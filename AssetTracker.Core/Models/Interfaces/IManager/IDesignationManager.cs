using AssetTracker.Core.Models.EntityModel;
using AssetTracker.Core.Models.Interfaces.BaseInterface;

namespace AssetTracker.Core.Models.Interfaces.IManager
{
    public interface IDesignationManager:IManager<Designation>
    {
        Designation GetByDesignationName(string designationName);
        bool IsDesignationNameAvailable(string designationName);
        bool IsDesignationNameAvailable(string designationName, int designationId);
        
    }
}
