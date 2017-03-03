using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracker.Core.Models.Interfaces.BaseInterface;

namespace AssetTracker.Core.Models.Interfaces.BLL
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
