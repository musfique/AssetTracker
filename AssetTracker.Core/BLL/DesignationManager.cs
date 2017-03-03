using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracker.Core.DAL;
using AssetTracker.Core.Models.EntityModel;
using AssetTracker.Core.Models.Interfaces.IManager;
using AssetTracker.Core.Models.Interfaces.IRepository;

namespace AssetTracker.Core.BLL
{
    public class DesignationManager:IDesignationManager
    {
        private IDesignationRepository _designationRepository;

        public DesignationManager(IDesignationRepository designationRepository)
        {
            _designationRepository = designationRepository;
        }
        
        
        public bool Insert(Designation entity)
        {
            if (IsDesignationNameAvailable(entity.DesignationName))
                return _designationRepository.Insert(entity);
            return false;
        }

        public bool Edit(Designation entity)
        {
            if (IsDesignationNameAvailable(entity.DesignationName, entity.DesignationID))
                return _designationRepository.Edit(entity);
            return false;
        }

        public bool Delete(int id)
        {
            var designation = GetById(id);
            return _designationRepository.Delete(designation);
        }

        public Designation GetById(int id)
        {
            return _designationRepository.GetFirstOrDefaultBy(c=>c.DesignationID==id);
        }

        public ICollection<Designation> GetAll()
        {
            return _designationRepository.GetAll();
        }

        public Designation GetByDesignationName(string designationName)
        {
            return _designationRepository.GetFirstOrDefaultBy(c => c.DesignationName.Equals(designationName));
        }


        public bool IsDesignationNameAvailable(string designationName)
        {
            var designation = GetByDesignationName(designationName);
            if (designation == null)
                return true;
            return false;
        }

        public bool IsDesignationNameAvailable(string designationName, int designationId)
        {
            var wantedDesignation = GetByDesignationName(designationName);
            var designation = GetById(designationId);
            if (wantedDesignation == null)
                return true;
            else if (wantedDesignation.DesignationID == designationId && wantedDesignation.DesignationName.Equals(designation.DesignationName))
                return true;
            return false;
        }
        
    }
}
