using System;
using System.Data.Entity;
using AssetTracker.Core.DAL.BaseDAL;
using AssetTracker.Core.Models;
using AssetTracker.Core.Models.EntityModel;
using AssetTracker.Core.Models.Interfaces.IRepository;

namespace AssetTracker.Core.Repository {
    public class GeneralCategoryRepository : BaseRepository<GeneralCategory>, IGeneralCategoryRepository,IDisposable
    {
        public AssetTrackerContext Context
        {
            get{return  db as AssetTrackerContext;}
        }

        public GeneralCategoryRepository(DbContext db) : base(db)
        {
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
