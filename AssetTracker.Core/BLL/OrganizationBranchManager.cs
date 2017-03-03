using AssetTracker.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracker.Core.DAL;
using System.Data.Entity;
using AssetTracker.Core.Models.Interfaces.BLL;
using AssetTracker.Core.Models.Interfaces.DAL;

namespace AssetTracker.Core.BLL {
    public class OrganizationBranchManager : IOrganizationBranchManager
    {
        private IOrganizationBranchRepository _organizationBranchRepository;

        public OrganizationBranchManager(IOrganizationBranchRepository organizationBranchRepository)
        {
            _organizationBranchRepository = organizationBranchRepository;
        }


        public bool Insert(OrganizationBranch entity) 
        {
            if (IsShortNameAvilable(entity.OrganizatioBranchShortName))
                return _organizationBranchRepository.Insert(entity);
            return false;
        }

        public bool Edit(OrganizationBranch entity)
        {
            if (IsShortNameAvilable(entity.OrganizatioBranchShortName, entity.OrganizationBranchID))
                return _organizationBranchRepository.Edit(entity);
            return false;
        }

        public bool Delete(int id) 
        {
            var organizationBranch = GetById(id);
            return _organizationBranchRepository.Delete(organizationBranch);
        }

        public OrganizationBranch GetById(int id)
        {
            return _organizationBranchRepository.GetFirstOrDefaultBy(c=>c.OrganizationBranchID == id,c=>c.Organization);
        }

        public ICollection<OrganizationBranch> GetAll() 
        {
            return _organizationBranchRepository.GetAll(c=>c.Organization);
        }
        
        public OrganizationBranch GetByOrganizationBranchName(string organizationBranchName)
        {
            return _organizationBranchRepository.GetFirstOrDefaultBy(c=> c.OrganizationBranchName.Equals(organizationBranchName),c=>c.Organization);
        }
        
        public OrganizationBranch GetByOrganizationBranchShortName(string organizationBranchShortName)
        {
            return _organizationBranchRepository.GetFirstOrDefaultBy(c => c.OrganizationBranchName.Equals(organizationBranchShortName), c => c.Organization);
        }
        public ICollection<OrganizationBranch> GetAllByOrganizationId(int organizationId)
        {
            return _organizationBranchRepository.Get(c => c.OrganizationID.Equals(organizationId),c=>c.Organization);
        }

        public bool IsShortNameAvilable(string organizationBranchShortName)
        {
            var organizationBranch = GetByOrganizationBranchShortName(organizationBranchShortName);
            if (organizationBranch == null)
                return true;
            return false;
        }
        public bool IsShortNameAvilable(string organizationBranchShortName, int organizationBranchId)
        {
            var wantedOrganizationBranch = GetByOrganizationBranchShortName(organizationBranchShortName);
            var organizationBranch = GetById(organizationBranchId);

            if (wantedOrganizationBranch == null)
                return true;
            else if (organizationBranch.OrganizatioBranchShortName.Equals(wantedOrganizationBranch.OrganizatioBranchShortName) && wantedOrganizationBranch.OrganizationID.Equals(organizationBranch.OrganizationID))
                return true;
            return false;
        }

        
    }
}
