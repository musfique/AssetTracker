using System;
using System.Data.Entity;
using AssetTracker.Core.DAL.BaseDAL;
using AssetTracker.Core.Models;
using AssetTracker.Core.Models.EntityModel;
using AssetTracker.Core.Models.Interfaces.IRepository;

namespace AssetTracker.Core.Repository {
    public class SubCategoryRepository :BaseRepository<SubCategory>,ISubCategoryRepository,IDisposable
    {
        public AssetTrackerContext Context
        {
            get{return db as AssetTrackerContext;}
        }
        public SubCategoryRepository(DbContext db) : base(db)
        {
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
