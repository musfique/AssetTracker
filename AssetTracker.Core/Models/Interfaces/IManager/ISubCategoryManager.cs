using System.Collections.Generic;
using AssetTracker.Core.Models.Interfaces.BaseInterface;

namespace AssetTracker.Core.Models.Interfaces.IManager
{
    public interface ISubCategoryManager : IManager<SubCategory>
    {
        SubCategory GetBySubCategoryName(string subCategoryName);
        SubCategory GetBySubCategoryNameAndCategoryId(string subCategoryName, int categoryId);
        SubCategory GetBySubCategoryCode(string subCategoryCode);
        SubCategory GetBySubCategoryCodeAndCategoryId(string subCategoryCode, int categoryId);
        ICollection<SubCategory> GetAllByCategoryId(int categoryId);
        bool IsSubCategoryNameAvailable(string subCategoryName, int categoryId);
        bool IsSubCategoryNameAvailable(string subCategoryName, int subCategoryId, int categoryId);
        bool IsSubCategoryCodeAvailable(string subCategoryCode, int categoryId);
        bool IsSubCategoryCodeAvailable(string subCategoryCode, int subCategoryId, int categoryId);
    }
}
