using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracker.Core.DAL;
using AssetTracker.Core.Models.EntityModel;
using AssetTracker.Core.Models.Interfaces.BLL;
using AssetTracker.Core.Models.Interfaces.DAL;

namespace AssetTracker.Core.BLL {
    public class EmployeeManager :IEmployeeManager
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeManager(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public bool Insert(Employee entity)
        {
            return _employeeRepository.Insert(entity);
        }

        public bool Edit(Employee entity)
        {
            return _employeeRepository.Edit(entity);
        }

        public bool Delete(int id)
        {
            var employee = GetById(id);
            return _employeeRepository.Delete(employee);
        }

        public Employee GetById(int id)
        {
            return _employeeRepository
                .GetFirstOrDefaultBy(c=>c.EmployeeID.Equals(id),c=>c.Designation,c=>c.Department);
        }

        public ICollection<Employee> GetAll()
        {
            return _employeeRepository
                .GetAll(c => c.Designation, c => c.Department);
        }
    }
}
