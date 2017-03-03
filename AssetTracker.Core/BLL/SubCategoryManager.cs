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
    public class SubCategoryManager :ISubCategoryManager
    {
        private ISubCategoryRepository _subCategoryRepository;

        public SubCategoryManager(ISubCategoryRepository subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
        }
        
        public bool Insert(SubCategory entity)
        {
            if (IsSubCategoryCodeAvailable(entity.SubCategoryCode, entity.CategoryID) &&
                IsSubCategoryNameAvailable(entity.SubCategoryName, entity.CategoryID))
                return _subCategoryRepository.Insert(entity);
            return false;
        }

        public bool Edit(SubCategory entity)
        {
            if (IsSubCategoryCodeAvailable(entity.SubCategoryCode, entity.SubCategoryID, entity.CategoryID) &&
                IsSubCategoryNameAvailable(entity.SubCategoryName, entity.SubCategoryID, entity.CategoryID))
                return _subCategoryRepository.Edit(entity);
            return false;
        }

        public bool Delete(int id)
        {
            var subCategory = GetById(id);
            return _subCategoryRepository.Delete(subCategory);
        }

        public SubCategory GetById(int id)
        {
            return _subCategoryRepository
                .GetFirstOrDefaultBy(c=>c.SubCategoryID.Equals(id), 
                c=>c.Category, 
                c=>c.Category.GeneralCategory);
        }

        public ICollection<SubCategory> GetAll()
        {
            return _subCategoryRepository.GetAll(c => c.Category, c => c.Category.GeneralCategory);
        }

        public SubCategory GetBySubCategoryName(string subCategoryName)
        {
            return _subCategoryRepository
                .GetFirstOrDefaultBy(c => c.SubCategoryName.Equals(subCategoryName),
                c => c.Category,
                c => c.Category.GeneralCategory);
        }
        public SubCategory GetBySubCategoryNameAndCategoryId(string subCategoryName, int categoryId)
        {
            return _subCategoryRepository
                .GetFirstOrDefaultBy(c => c.SubCategoryName.Equals(subCategoryName) &&
                    c.CategoryID.Equals(categoryId),
                    c => c.Category,
                    c => c.Category.GeneralCategory);
        }
        public SubCategory GetBySubCategoryCode(string subCategoryCode)
        {
            return _subCategoryRepository
                .GetFirstOrDefaultBy(c => c.SubCategoryCode.Equals(subCategoryCode),
                c => c.Category,
                c => c.Category.GeneralCategory);
        }
        public SubCategory GetBySubCategoryCodeAndCategoryId(string subCategoryCode, int categoryId)
        {
            return _subCategoryRepository
                .GetFirstOrDefaultBy(c => c.SubCategoryCode.Equals(subCategoryCode) &&
                    c.CategoryID.Equals(categoryId),
                    c => c.Category,
                    c => c.Category.GeneralCategory);
        }

        public ICollection<SubCategory> GetAllByCategoryId(int categoryId)
        {
            return _subCategoryRepository
                .Get(c => c.CategoryID.Equals(categoryId),
                    c => c.Category,
                    c => c.Category.GeneralCategory);
        }

        public bool IsSubCategoryNameAvailable(string subCategoryName, int categoryId)
        {
            var subCategory = GetBySubCategoryNameAndCategoryId(subCategoryName, categoryId);
            if (subCategory == null)
                return true;
            return false;
        }
        public bool IsSubCategoryNameAvailable(string subCategoryName, int subCategoryId, int categoryId)
        {
            var wantedSubCategory = GetBySubCategoryNameAndCategoryId(subCategoryName, categoryId);
            var subCategory = GetById(subCategoryId);
            if (wantedSubCategory == null)
                return true;
            else if (wantedSubCategory.SubCategoryID == subCategoryId &&
                     wantedSubCategory.SubCategoryName.Equals(subCategory.SubCategoryName))
                return true;
            return false;
        }

        public bool IsSubCategoryCodeAvailable(string subCategoryCode, int categoryId)
        {
            var subCategory = GetBySubCategoryCodeAndCategoryId(subCategoryCode, categoryId);
            if (subCategory == null)
                return true;
            return false;
        }

        public bool IsSubCategoryCodeAvailable(string subCategoryCode, int subCategoryId, int categoryId)
        {
            var wantedSubCategory = GetBySubCategoryCodeAndCategoryId(subCategoryCode, categoryId);
            var subCategory = GetById(subCategoryId);
            if (wantedSubCategory == null)
                return true;
            else if (wantedSubCategory.SubCategoryID == subCategoryId &&
                     wantedSubCategory.SubCategoryCode.Equals(subCategory.SubCategoryCode))
                return true;
            return false;
        }
    }
}
