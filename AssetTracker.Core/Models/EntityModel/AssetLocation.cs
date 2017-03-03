using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracker.Core.Models
{
    public class AssetLocation
    {
        public int AssetLocationID { get; set; }
        public int OrganizationBranchID { get; set; }
        public string AssetLocationName { get; set; }
        public string ShortName { get; set; }

        public virtual OrganizationBranch OrganizationBranch { get; set; }
        
    }
}
