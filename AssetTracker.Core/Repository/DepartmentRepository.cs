using System;
using System.Data.Entity;
using AssetTracker.Core.DAL.BaseDAL;
using AssetTracker.Core.Models.EntityModel;
using AssetTracker.Core.Models.Interfaces.IRepository;

namespace AssetTracker.Core.Repository {
    public class DepartmentRepository : BaseRepository<Department>,IDepartmentRepository,IDisposable
    {
        public AssetTrackerContext Context
        {
            get { return db as AssetTrackerContext; }
        }

        public DepartmentRepository(DbContext db) : base(db)
        {
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
