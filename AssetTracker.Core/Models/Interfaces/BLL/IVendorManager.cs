using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracker.Core.Models.Interfaces.BaseInterface;
using AssetTracker.Core.Models.EntityModel;

namespace AssetTracker.Core.Models.Interfaces.BLL
{
    public interface IVendorManager: IManager<Vendor>
    {
        Vendor GetByVendorName(string vendorName);
        bool IsVendorNameAvailable(string vendorName);
        bool IsVendorNameAvailable(string vendorName, int vendorId);
    }
}
