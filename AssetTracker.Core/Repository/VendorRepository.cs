using AssetTracker.Core.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using AssetTracker.Core.DAL.BaseDAL;
using AssetTracker.Core.Models.Interfaces.IRepository;

namespace AssetTracker.Core.DAL
{
    public class VendorRepository:BaseRepository<Vendor>,IVendorRepository,IDisposable
    {
        private AssetTrackerEntities Context
        {
            get
            {
                return db as AssetTrackerEntities;
            }
        }
        
        public VendorRepository(DbContext db) : base(db)
        {
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
