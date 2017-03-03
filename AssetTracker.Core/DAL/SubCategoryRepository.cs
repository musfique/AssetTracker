using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracker.Core.DAL.BaseDAL;
using AssetTracker.Core.Models;
using AssetTracker.Core.Models.EntityModel;
using AssetTracker.Core.Models.Interfaces.DAL;

namespace AssetTracker.Core.DAL {
    public class SubCategoryRepository :BaseRepository<SubCategory>,ISubCategoryRepository,IDisposable
    {
        public AssetTrackerEntities Context
        {
            get{return db as AssetTrackerEntities;}
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
