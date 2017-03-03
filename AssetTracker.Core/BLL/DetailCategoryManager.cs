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

namespace AssetTracker.Core.BLL
{
    public class DetailCategoryManager : IDetailCategoryManager
    {
        private IDetailCategoryRepository _detailCategoryRepository;

        public DetailCategoryManager(IDetailCategoryRepository detailCategoryRepository)
        {
            _detailCategoryRepository = detailCategoryRepository;
        }
        
        public bool Insert(DetailCategory entity)
        {
            if (IsDetailCategoryNameAvilable(entity.DetailCategoryName, entity.SubCategoryID))
                return _detailCategoryRepository.Insert(entity);
            return false;
        }

        public bool Edit(DetailCategory entity)
        {
            if (IsDetailCategoryNameAvilable(entity.DetailCategoryName, entity.DetailCategoryID,
                    entity.SubCategoryID)
                    &&
                    IsDetailCategoryCodeAvilable(entity.DetailCategoryCode, entity.DetailCategoryID,
                        entity.SubCategoryID))
                return _detailCategoryRepository.Edit(entity);
            return false;
        }

        public bool Delete(int id)
        {
            var detailCategory = GetById(id);
            return _detailCategoryRepository.Delete(detailCategory);
        }

        public DetailCategory GetById(int id)
        {
            return _detailCategoryRepository
                .GetFirstOrDefaultBy(c=>c.DetailCategoryID.Equals(id),
                c=>c.SubCategory,
                c=>c.SubCategory.Category,
                c=>c.SubCategory.Category.GeneralCategory);
        }

        public ICollection<DetailCategory> GetAll()
        {
            return _detailCategoryRepository
                .GetAll(c => c.SubCategory,
                c => c.SubCategory.Category,
                c => c.SubCategory.Category.GeneralCategory);
        }

        public ICollection<DetailCategory> GetAllBySubCategoryId(int subCategoryId)
        {
            return _detailCategoryRepository.Get(c => c.SubCategoryID == subCategoryId);
        }

        public DetailCategory GetByDetailCategoryName(string detailCategoryName)
        {
            return _detailCategoryRepository
                .GetFirstOrDefaultBy(c => c.DetailCategoryName.Equals(detailCategoryName),
                c => c.SubCategory,
                c => c.SubCategory.Category,
                c => c.SubCategory.Category.GeneralCategory);
        }

        public DetailCategory GetByDetailCategoryCode(string detailCategoryCode)
        {
            return _detailCategoryRepository
                .GetFirstOrDefaultBy(c => c.DetailCategoryCode.Equals(detailCategoryCode),
                c => c.SubCategory,
                c => c.SubCategory.Category,
                c => c.SubCategory.Category.GeneralCategory);
        }

        public DetailCategory GetByDetailCategoryCodeAndCategoryId(string detailCategoryCode, int subCategoryId)
        {
            return _detailCategoryRepository
                .GetFirstOrDefaultBy(c => c.DetailCategoryCode.Equals(detailCategoryCode) &&
                 c.SubCategoryID.Equals(subCategoryId),
                c => c.SubCategory,
                c => c.SubCategory.Category,
                c => c.SubCategory.Category.GeneralCategory);
        }
        public DetailCategory GetByDetailCategoryNameAndCategoryId(string detailCategoryName, int subCategoryId)
        {
            return _detailCategoryRepository
                .GetFirstOrDefaultBy(c => c.DetailCategoryName.Equals(detailCategoryName) &&
                 c.SubCategoryID.Equals(subCategoryId),
                c => c.SubCategory,
                c => c.SubCategory.Category,
                c => c.SubCategory.Category.GeneralCategory);
        }


        public bool IsDetailCategoryNameAvilable(string detailCategoryName, int subCategoryId)
        {
            var detailCategory = GetByDetailCategoryNameAndCategoryId(detailCategoryName, subCategoryId);
            if (detailCategory == null)
                return true;
            return false;
        }

        public bool IsDetailCategoryNameAvilable(string detailCategoryName, int detailCategoryId, int subCategoryId)
        {
            var wantedDetailCategory = GetByDetailCategoryNameAndCategoryId(detailCategoryName, subCategoryId);
            var detailCategory = GetById(detailCategoryId);
            if (wantedDetailCategory == null)
                return true;
            else if (wantedDetailCategory.DetailCategoryName.Equals(detailCategory.DetailCategoryName) &&
                     wantedDetailCategory.DetailCategoryID.Equals(detailCategory.DetailCategoryID))
                return true;
            return false;
        }

        public bool IsDetailCategoryCodeAvilable(string detailCategoryCode, int subCategoryId)
        {
            var detailCategory = GetByDetailCategoryNameAndCategoryId(detailCategoryCode, subCategoryId);
            if (detailCategory == null)
                return true;
            return false;
        }

        public bool IsDetailCategoryCodeAvilable(string detailCategoryCode, int detailCategoryId, int subCategoryId)
        {
            var wantedDetailCategory = GetByDetailCategoryCodeAndCategoryId(detailCategoryCode, subCategoryId);
            var detailCategory = GetById(detailCategoryId);
            if (wantedDetailCategory == null)
                return true;
            else if (wantedDetailCategory.DetailCategoryCode.Equals(detailCategory.DetailCategoryCode) &&
                     wantedDetailCategory.DetailCategoryID.Equals(detailCategory.DetailCategoryID))
                return true;
            return false;
        }
    }
}
