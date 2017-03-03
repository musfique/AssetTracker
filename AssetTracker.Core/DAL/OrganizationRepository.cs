﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracker.Core.Models;
using AssetTracker.Core.Models.EntityModel;
using AssetTracker.Core.DAL.BaseDAL;
using AssetTracker.Core.Models.Interfaces.BLL;


namespace AssetTracker.Core.DAL
{
    public class OrganizationRepository : BaseRepository<Organization>, IOrganizationRepository, IDisposable
    {
        private AssetTrackerEntities Context
        {
            get
            {
                return db as AssetTrackerEntities;
            }
        }
        public OrganizationRepository(DbContext db)
            : base(db)
        {
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
