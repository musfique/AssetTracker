using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracker.Core.Models.EntityModel;
using AssetTracker.Core.Models.Interfaces.BaseInterface;

namespace AssetTracker.Core.Models.Interfaces.BLL
{
    public interface IDesignationManager:IManager<Designation>
    {
        Designation GetByDesignationName(string designationName);
        bool IsDesignationNameAvailable(string designationName);
        bool IsDesignationNameAvailable(string designationName, int designationId);
        
    }
}
