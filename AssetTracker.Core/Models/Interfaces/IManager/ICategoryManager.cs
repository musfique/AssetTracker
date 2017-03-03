using System.Collections.Generic;
using AssetTracker.Core.Models.Interfaces.BaseInterface;

namespace AssetTracker.Core.Models.Interfaces.IManager
{
    public interface ICategoryManager : IManager<Category>
    {
        Category GetByCategoryName(string categoryName);
        Category GetByCategoryCode(string categoryCode);
        Category GetByCategoryCodeAndGeneralCategoryId(int generalCategoryId, string categoryCode);
        Category GetByCategoryNameAndGeneralCategoryId(int generalCategoryId, string categoryName);
        ICollection<Category> GetAllByGeneralCategoryId(int generalCategoryId);
        bool IsCategoryCodeAvailable(int generalCategoryId, string categoryCode);
        bool IsCategoryCodeAvailable(int generalCategoryId, string categoryCode, int categoryId);
        bool IsCategoryNameAvailable(int generalCategoryId, string categoryName);
        bool IsCategoryNameAvailable(int generalCategoryId, string categoryName, int categoryId);
    }
}
