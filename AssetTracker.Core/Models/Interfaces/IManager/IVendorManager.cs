using AssetTracker.Core.Models.EntityModel;
using AssetTracker.Core.Models.Interfaces.BaseInterface;

namespace AssetTracker.Core.Models.Interfaces.IManager
{
    public interface IVendorManager: IManager<Vendor>
    {
        Vendor GetByVendorName(string vendorName);
        bool IsVendorNameAvailable(string vendorName);
        bool IsVendorNameAvailable(string vendorName, int vendorId);
    }
}
