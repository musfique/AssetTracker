using System.Collections.Generic;
using AssetTracker.Core.Models.EntityModel;
using AssetTracker.Core.Models.Interfaces.BaseInterface;

namespace AssetTracker.Core.Models.Interfaces.IManager
{
    public interface IDepartmentManager: IManager<Department>
    {
        ICollection<Department> GetAllByOrganizationBranchId(int organizationBranchId);
        Department GetByDepartmentName(string departmentName);
        bool IsDepartmentNameAvailable(string departmentName, int organizationBranchId);
        bool IsDepartmentNameAvailable(string departmentName, int organizationBranchId,int departmentId);
    }
}
