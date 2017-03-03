using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracker.Core.Models.Interfaces.BaseInterface;

namespace AssetTracker.Core.Models.Interfaces.BLL
{
    public interface IOrganizationManager: IManager<Organization>
    {
        bool IsNameAvailable(string organizationName);
        bool IsNameAvailable(string organizationName, int organizationId);
        bool IsShortNameAvailable(string organizationShortName);
        bool IsShortNameAvailable(string organizationShortName, int organizationId);
    }
}
