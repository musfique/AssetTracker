using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracker.Core.DAL;
using AssetTracker.Core.Models.EntityModel;
using AssetTracker.Core.Models.Interfaces.BLL;
using AssetTracker.Core.Models.Interfaces.DAL;

namespace AssetTracker.Core.BLL {
    public class DepartmentManager : IDepartmentManager
    {
        private IDepartmentRepository _departmentRepository;

        public DepartmentManager(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public bool Insert(Department entity)
        {
            if (IsDepartmentNameAvailable(entity.DepartmentName, entity.OrganizationBranchID))
                return _departmentRepository.Insert(entity);
            return false;
        }

        public bool Edit(Department entity)
        {
            if (IsDepartmentNameAvailable(entity.DepartmentName, entity.OrganizationBranchID,entity.DepartmentID))
                return _departmentRepository.Edit(entity);
            return false;
        }

        public bool Delete(int id)
        {
            var department = GetById(id);
            return _departmentRepository.Delete(department);
        }

        public Department GetById(int id)
        {
            return _departmentRepository.GetFirstOrDefaultBy(c=>c.DepartmentID.Equals(id),c=>c.OrganizationBranch, c=>c.OrganizationBranch.Organization);
        }

        public ICollection<Department> GetAll()
        {
            return _departmentRepository.GetAll(c => c.OrganizationBranch, c => c.OrganizationBranch.Organization);
        }
        public ICollection<Department> GetAllByOrganizationBranchId(int organizationBranchId)
        {
            return _departmentRepository
                .Get(c => c.OrganizationBranchID.Equals(organizationBranchId),
                c => c.OrganizationBranch, c => c.OrganizationBranch.Organization);
        }

        public Department GetByDepartmentName(string departmentName)
        {
            return _departmentRepository.GetFirstOrDefaultBy(c => c.DepartmentName.Equals(departmentName));
        }
        
        public bool IsDepartmentNameAvailable(string departmentName, int organizationBranchId)
        {
            var department =
                _departmentRepository.GetFirstOrDefaultBy(
                    c => c.DepartmentName.Equals(departmentName) && c.OrganizationBranchID.Equals(organizationBranchId));
            if (department == null)
                return true;
            return false;
        }

        public bool IsDepartmentNameAvailable(string departmentName, int organizationBranchId, int departmentId)
        {
            var wantedDepartment =
                _departmentRepository.GetFirstOrDefaultBy(
                    c => c.DepartmentName.Equals(departmentName) && c.OrganizationBranchID.Equals(organizationBranchId));
            if (wantedDepartment == null)
                return true;
            var department = GetById(departmentId);
            if(department.DepartmentName.Equals(wantedDepartment.DepartmentName) && department.OrganizationBranchID.Equals(wantedDepartment.OrganizationBranchID) && department.DepartmentID.Equals(wantedDepartment.DepartmentID))
                return true;
            return false;
        }
    }
}
