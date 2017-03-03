using AssetTracker.Core.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracker.Core.DAL.BaseDAL;
using AssetTracker.Core.Models.Interfaces.DAL;

namespace AssetTracker.Core.DAL
{
    public class DesignationRepository : BaseRepository<Designation>, IDesignationRepository, IDisposable
    {
        private AssetTrackerEntities Context
        {
            get
            {
                return db as AssetTrackerEntities;
            }
        }
        public DesignationRepository(DbContext db)
            : base(db)
        {
        }
        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
