using System;

namespace AssetTracker.Core.Models.Interfaces.IModel
{
    public interface IAudit
    {
        int CreatedBy { get; set; }
        DateTime CreatedOn { get; set; }
        int? LastModifiedBy { get; set; }
        DateTime? LastModifiedOn { get; set; }
    }
}
