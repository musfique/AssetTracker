using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracker.Core.DAL.BaseDAL;
using AssetTracker.Core.Models;
using AssetTracker.Core.Models.EntityModel;
using AssetTracker.Core.Models.Interfaces.IRepository;

namespace AssetTracker.Core.DAL {
    public class GeneralCategoryRepository : BaseRepository<GeneralCategory>, IGeneralCategoryRepository,IDisposable
    {
        public AssetTrackerEntities Context
        {
            get{return  db as AssetTrackerEntities;}
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
