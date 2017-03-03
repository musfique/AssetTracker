using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracker.Core.Models.EntityModel;
using AssetTracker.Core.Models.Interfaces.IManager;
using AssetTracker.Core.Models.Interfaces.IRepository;

namespace AssetTracker.Core.BLL
{
    public class WarrantyPeriodUnitManager : IWarrantyPeriodUnitManager
    {
        private IWarrantyPeriodUnitRepository _warrantyPeriodUnitRepository;

        public WarrantyPeriodUnitManager(IWarrantyPeriodUnitRepository warrantyPeriodUnitRepository)
        {
            _warrantyPeriodUnitRepository = warrantyPeriodUnitRepository;
        }
        public bool Insert(WarrantyPeriodUnit entity)
        {
            return _warrantyPeriodUnitRepository.Insert(entity);
        }

        public bool Edit(WarrantyPeriodUnit entity)
        {
            return _warrantyPeriodUnitRepository.Edit(entity);
        }

        public bool Delete(int id)
        {
            var entity = GetById(id);
            return _warrantyPeriodUnitRepository.Delete(entity);
        }

        public WarrantyPeriodUnit GetById(int id)
        {
            return _warrantyPeriodUnitRepository.GetFirstOrDefaultBy(c => c.WarrantyPeriodUnitID == id);
        }

        public ICollection<WarrantyPeriodUnit> GetAll()
        {
            return _warrantyPeriodUnitRepository.GetAll();
        }
    }
}
