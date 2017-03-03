using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracker.Core.DAL.BaseDAL;
using AssetTracker.Core.Models.EntityModel;
using AssetTracker.Core.Models.Interfaces.IRepository;

namespace AssetTracker.Core.DAL {
    public class EmployeeRepository :BaseRepository<Employee>,IEmployeeRepository,IDisposable
    {
        private AssetTrackerContext Context
        {
            get
            {
                return db as AssetTrackerContext;
            }
        }
        public EmployeeRepository(DbContext db) : base(db)
        {
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
