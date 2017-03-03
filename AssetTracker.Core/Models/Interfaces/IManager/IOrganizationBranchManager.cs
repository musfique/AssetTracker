using System.Collections.Generic;
using AssetTracker.Core.Models.Interfaces.BaseInterface;

namespace AssetTracker.Core.Models.Interfaces.IManager {
    public interface IOrganizationBranchManager : IManager<OrganizationBranch>
    {
        OrganizationBranch GetByOrganizationBranchName(string organizationBranchName);
        OrganizationBranch GetByOrganizationBranchShortName(string organizationBranchShortName);
        ICollection<OrganizationBranch> GetAllByOrganizationId(int organizationId);
        bool IsShortNameAvilable(string organizationBranchShortName);
        bool IsShortNameAvilable(string organizationBranchShortName, int organizationId);

    }
}
