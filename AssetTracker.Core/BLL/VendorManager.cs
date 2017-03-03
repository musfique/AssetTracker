using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracker.Core.DAL;
using AssetTracker.Core.Models.EntityModel;
using AssetTracker.Core.Models.Interfaces.BaseInterface;
using AssetTracker.Core.Models.Interfaces.BLL;
using AssetTracker.Core.Models.Interfaces.DAL;

namespace AssetTracker.Core.BLL
{
    public class VendorManager:IVendorManager
    {
        private IVendorRepository _vendorRepository;

        public VendorManager(IVendorRepository vendorRepository)
        {
            _vendorRepository = vendorRepository;
        }
        
        public bool Insert(Vendor entity)
        {
            if (IsVendorNameAvailable(entity.VendorName))
                return _vendorRepository.Insert(entity);
            return false;
        }

        public bool Edit(Vendor entity)
        {
            if (IsVendorNameAvailable(entity.VendorName, entity.VendorID))
                return _vendorRepository.Edit(entity);
            return false;
        }

        public bool Delete(int id)
        {
            var vendor = GetById(id);
            return _vendorRepository.Delete(vendor);
        }

        public Vendor GetById(int id)
        {
            return _vendorRepository.GetFirstOrDefaultBy(c => c.VendorID.Equals(id));
        }

        public ICollection<Vendor> GetAll()
        {
            return _vendorRepository.GetAll();
        }
        public Vendor GetByVendorName(string vendorName)
        {
           return _vendorRepository.GetFirstOrDefaultBy(c=>c.VendorName.Equals(vendorName));
        }

        public bool IsVendorNameAvailable(string vendorName)
        {
            var vendor = GetByVendorName(vendorName);
            if (vendor == null)
                return true;
            return false;
        }

        public bool IsVendorNameAvailable(string vendorName, int vendorId)
        {
            var wantedVendor = GetByVendorName(vendorName);
            var vendor = GetById(vendorId);
            if (wantedVendor == null)
                return true;
            else if (wantedVendor.VendorID == vendorId && wantedVendor.VendorName.Equals(vendor.VendorName))
                return true;
            return false;
        }

    }
}
