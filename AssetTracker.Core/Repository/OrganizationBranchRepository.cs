using System;
using System.Data.Entity;
using AssetTracker.Core.DAL.BaseDAL;
using AssetTracker.Core.Models;
using AssetTracker.Core.Models.EntityModel;
using AssetTracker.Core.Models.Interfaces.IRepository;

namespace AssetTracker.Core.Repository
{
    public class OrganizationBranchRepository : BaseRepository<OrganizationBranch>, IOrganizationBranchRepository, IDisposable
    {

        private AssetTrackerContext Context
        {
            get
            {
                return db as AssetTrackerContext;
            }
        }
        public OrganizationBranchRepository(DbContext db)
            : base(db)
        {
        }

        public void Dispose()
        {
            Context.Dispose();
        }
        
    }
}