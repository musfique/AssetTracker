using AssetTracker.Core.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracker.Core.Models;
using AssetTracker.Core.Models.Interfaces.IManager;
using AssetTracker.Core.Models.Interfaces.IRepository;

namespace AssetTracker.Core.BLL
{
    public class OrganizationManager : IOrganizationManager
    {
         private IOrganizationRepository _organizationRepository;

        public OrganizationManager(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }
        public bool Insert(Organization entity)
        {
            if (IsNameAvailable(entity.OrganizationName) && IsShortNameAvailable(entity.OrganizationShortName))
                return _organizationRepository.Insert(entity);
            return false;
        }

        public bool Edit(Organization entity)
        {
            if (IsNameAvailable(entity.OrganizationName, entity.OrganizationID) && IsShortNameAvailable(entity.OrganizationShortName, entity.OrganizationID))
                return _organizationRepository.Edit(entity);
            return false;
        }

        public bool Delete(int id)
        {
            var organization = GetById(id);
            return _organizationRepository.Delete(organization);
        }

        public Organization GetById(int id)
        {
            return _organizationRepository.GetFirstOrDefaultBy(c=>c.OrganizationID==id);
        }

        public ICollection<Organization> GetAll()
        {
            return _organizationRepository.GetAll();
        }

        public Organization GetOrganizationByName(string organizationName)
        {
            return _organizationRepository.Get(c=>c.OrganizationName.Equals(organizationName)).FirstOrDefault();
        }
        public Organization GetOrganizationByShortName(string organizationShortName)
        {
            return _organizationRepository.Get(c => c.OrganizationName.Equals(organizationShortName)).FirstOrDefault();
        }

        public bool IsNameAvailable(string organizationName)
        {
            var organization = GetOrganizationByName(organizationName);
            if (organization == null)
                return true;
            return false;
        }

        public bool IsNameAvailable(string organizationName, int organizationId)
        {
            var wantedOrganization = GetOrganizationByName(organizationName);
            var actualOrganization = GetById(organizationId);

            if (wantedOrganization == null)
                return true;
            else if (wantedOrganization.OrganizationID.Equals(organizationId) &&
                     wantedOrganization.OrganizationName.Equals(actualOrganization.OrganizationName))
                return true;
            return false;
        }

        public bool IsShortNameAvailable(string organizationShortName)
        {
            var organization = GetOrganizationByShortName(organizationShortName);

            if (organization == null)
                return true;
            return false;
        }
        public bool IsShortNameAvailable(string organizationShortName, int organizationId)
        {
            var wantedOrganization = GetOrganizationByShortName(organizationShortName);
            var actualOrganization = GetById(organizationId);

            if (wantedOrganization == null)
                return true;
            else if (wantedOrganization.OrganizationID.Equals(organizationId) &&
                     wantedOrganization.OrganizationName.Equals(actualOrganization.OrganizationName))
                return true;
            return false;
        }
    }
}
