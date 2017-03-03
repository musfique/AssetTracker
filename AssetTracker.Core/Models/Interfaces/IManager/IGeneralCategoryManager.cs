using AssetTracker.Core.Models.Interfaces.BaseInterface;

namespace AssetTracker.Core.Models.Interfaces.IManager
{
    public interface IGeneralCategoryManager: IManager<GeneralCategory>
    {
        GeneralCategory GetByGeneralCategoryCode(string generalCategoryCode);
        GeneralCategory GetByGeneralCategoryName(string generalCategoryName);
        bool IsGeneralCategoryCodeAvailable(string generalCategoryCode);
        bool IsGeneralCategoryCodeAvailable(string generalCategoryCode, int generalCategoryId);
        bool IsGeneralCategoryNameAvailable(string generalCategoryName);
        bool IsGeneralCategoryNameAvailable(string generalCategoryName, int generalCategoryId);


    }
}
