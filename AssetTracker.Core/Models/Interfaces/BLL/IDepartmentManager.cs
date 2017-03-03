using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracker.Core.Models.EntityModel;
using AssetTracker.Core.Models.Interfaces.BaseInterface;

namespace AssetTracker.Core.Models.Interfaces.BLL
{
    public interface IDepartmentManager: IManager<Department>
    {
        ICollection<Department> GetAllByOrganizationBranchId(int organizationBranchId);
        Department GetByDepartmentName(string departmentName);
        bool IsDepartmentNameAvailable(string departmentName, int organizationBranchId);
        bool IsDepartmentNameAvailable(string departmentName, int organizationBranchId,int departmentId);
    }
}
