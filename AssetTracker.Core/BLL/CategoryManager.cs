using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracker.Core.DAL;
using AssetTracker.Core.Models;
using AssetTracker.Core.Models.Interfaces.IManager;
using AssetTracker.Core.Models.Interfaces.IRepository;

namespace AssetTracker.Core.BLL {
    public class CategoryManager : ICategoryManager
    {
        private ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public bool Insert(Category entity)
        {
            if (IsCategoryCodeAvailable(entity.GeneralCategoryID, entity.CategoryCode) &&
                IsCategoryNameAvailable(entity.GeneralCategoryID, entity.CategoryName)
                )
                return _categoryRepository.Insert(entity);
            return false;
        }

        public bool Edit(Category entity)
        {
            if (IsCategoryCodeAvailable(entity.GeneralCategoryID, entity.CategoryCode, entity.CategoryID) &&
                IsCategoryNameAvailable(entity.GeneralCategoryID, entity.CategoryName, entity.CategoryID)
                )
                return _categoryRepository.Edit(entity);
            return false;
        }

        public bool Delete(int id)
        {
            var category = GetById(id);
            return _categoryRepository.Delete(category);
        }

        public Category GetById(int id)
        {
            return _categoryRepository.GetFirstOrDefaultBy(c=>c.CategoryID.Equals(id),c=>c.GeneralCategory);
        }

        public ICollection<Category> GetAll()
        {
            return _categoryRepository.GetAll(c=>c.GeneralCategory);
        }
        public Category GetByCategoryName(string categoryName)
        {
            return _categoryRepository
                .GetFirstOrDefaultBy(c=>c.CategoryName.Equals(categoryName),c=>c.GeneralCategory);
        }

        public Category GetByCategoryCode(string categoryCode)
        {
            return _categoryRepository
                .GetFirstOrDefaultBy(c=>c.CategoryCode.Equals(categoryCode),c=>c.CategoryName);
        }
        public Category GetByCategoryCodeAndGeneralCategoryId(int generalCategoryId, string categoryCode)
        {
            return _categoryRepository
                .GetFirstOrDefaultBy(c=>c.GeneralCategoryID.Equals(generalCategoryId) &&
                    c.CategoryCode.Equals(categoryCode),
                    c=>c.GeneralCategory);
        }
        public Category GetByCategoryNameAndGeneralCategoryId(int generalCategoryId, string categoryName)
        {
            return _categoryRepository
                .GetFirstOrDefaultBy(c=>c.GeneralCategoryID.Equals(generalCategoryId) && 
                    c.CategoryName.Equals(categoryName),
                    c=>c.GeneralCategory);
        }

        public ICollection<Category> GetAllByGeneralCategoryId(int generalCategoryId)
        {
            return _categoryRepository.Get(c=>c.GeneralCategoryID.Equals(generalCategoryId), c=>c.GeneralCategory);
        }

        public bool IsCategoryCodeAvailable(int generalCategoryId, string categoryCode)
        {
            var category = GetByCategoryCodeAndGeneralCategoryId(generalCategoryId, categoryCode);
            if (category == null)
                return true;
            return false;
        }
        public bool IsCategoryCodeAvailable(int generalCategoryId, string categoryCode, int categoryId)
        {
            var category = GetByCategoryCodeAndGeneralCategoryId(generalCategoryId, categoryCode);
            if (category == null || category.CategoryID == categoryId)
                return true;
            return false;
        }
        public bool IsCategoryNameAvailable(int generalCategoryId, string categoryName)
        {
            var category = GetByCategoryNameAndGeneralCategoryId(generalCategoryId, categoryName);
            if (category == null)
                return true;
            return false;
        }
        public bool IsCategoryNameAvailable(int generalCategoryId, string categoryName, int categoryId)
        {
            var category = GetByCategoryNameAndGeneralCategoryId(generalCategoryId, categoryName);
            if (category == null || category.CategoryID == categoryId)
                return true;
            return false;
        }
    }
}
