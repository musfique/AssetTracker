using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracker.Core.DAL;
using AssetTracker.Core.Models;
using AssetTracker.Core.Models.EntityModel;
using AssetTracker.Core.Models.Interfaces.IManager;
using AssetTracker.Core.Models.Interfaces.IRepository;

namespace AssetTracker.Core.BLL {
    public class GeneralCategoryManager:IGeneralCategoryManager
    {
        private IGeneralCategoryRepository _generalCategoryRepository;

        public GeneralCategoryManager(IGeneralCategoryRepository generalCategoryRepository)
        {
            _generalCategoryRepository = generalCategoryRepository;
        }
        
        public bool Insert(GeneralCategory entity)
        {
            if (IsGeneralCategoryCodeAvailable(entity.GeneralCategoryCode) &&
                IsGeneralCategoryNameAvailable(entity.GeneralCategoryName)
                )
                return _generalCategoryRepository.Insert(entity);
            return false;
        }

        public bool Edit(GeneralCategory entity)
        {
            if (IsGeneralCategoryCodeAvailable(entity.GeneralCategoryCode, entity.GeneralCategoryID) &&
                IsGeneralCategoryNameAvailable(entity.GeneralCategoryName, entity.GeneralCategoryID)
                )
                return _generalCategoryRepository.Edit(entity);
            return false;
        }

        public bool Delete(int id)
        {
            var generalCategory = GetById(id);
            return _generalCategoryRepository.Delete(generalCategory);
        }

        public GeneralCategory GetById(int id)
        {
            return _generalCategoryRepository.GetFirstOrDefaultBy(c=>c.GeneralCategoryID.Equals(id));
        }

        public ICollection<GeneralCategory> GetAll()
        {
            return _generalCategoryRepository.GetAll();
        }

        public GeneralCategory GetByGeneralCategoryCode(string generalCategoryCode)
        {
            return _generalCategoryRepository
                .GetFirstOrDefaultBy(c=>c.GeneralCategoryCode.Equals(generalCategoryCode));
        }
        public GeneralCategory GetByGeneralCategoryName(string generalCategoryName)
        {
            return _generalCategoryRepository
                .GetFirstOrDefaultBy(c=>c.GeneralCategoryName.Equals(generalCategoryName));
        }

        public bool IsGeneralCategoryCodeAvailable(string generalCategoryCode)
        {
            var generalCategory = GetByGeneralCategoryCode(generalCategoryCode);
            if (generalCategory == null)
                return true;
            return false;
        }
        public bool IsGeneralCategoryCodeAvailable(string generalCategoryCode, int generalCategoryId)
        {
            var wantedGeneralCategory = GetByGeneralCategoryCode(generalCategoryCode);
            var generalCategory = GetById(generalCategoryId);
            if (wantedGeneralCategory == null)
                return true;
            else if (wantedGeneralCategory.GeneralCategoryID == generalCategoryId &&
                     wantedGeneralCategory.GeneralCategoryCode.Equals(generalCategory.GeneralCategoryCode))
                return true;
            return false;
        }
        public bool IsGeneralCategoryNameAvailable(string generalCategoryName)
        {
            var generalCategory = GetByGeneralCategoryName(generalCategoryName);
            if (generalCategory == null)
                return true;
            return false;
        }
        public bool IsGeneralCategoryNameAvailable(string generalCategoryName, int generalCategoryId)
        {
            var wantedGeneralCategory = GetByGeneralCategoryName(generalCategoryName);
            var generalCategory = GetById(generalCategoryId);
            if (wantedGeneralCategory == null)
                return true;
            else if (wantedGeneralCategory.GeneralCategoryID == generalCategoryId &&
                     wantedGeneralCategory.GeneralCategoryCode.Equals(generalCategory.GeneralCategoryCode))
                return true;
            return false;
        }
    }
}
