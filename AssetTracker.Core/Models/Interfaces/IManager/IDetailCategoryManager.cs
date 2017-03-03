using AssetTracker.Core.Models.Interfaces.BaseInterface;

namespace AssetTracker.Core.Models.Interfaces.IManager
{
    public interface IDetailCategoryManager: IManager<DetailCategory>
    {
        DetailCategory GetByDetailCategoryName(string detailCategoryName);
        DetailCategory GetByDetailCategoryCode(string detailCategoryCode);
        DetailCategory GetByDetailCategoryCodeAndCategoryId(string detailCategoryCode, int subCategoryId);
        DetailCategory GetByDetailCategoryNameAndCategoryId(string detailCategoryName, int subCategoryId);
        bool IsDetailCategoryNameAvilable(string detailCategoryName, int subCategoryId);
        bool IsDetailCategoryNameAvilable(string detailCategoryName, int detailCategoryId, int subCategoryId);
        bool IsDetailCategoryCodeAvilable(string detailCategoryCode, int subCategoryId);
        bool IsDetailCategoryCodeAvilable(string detailCategoryCode, int detailCategoryId, int subCategoryId);
    }
}
