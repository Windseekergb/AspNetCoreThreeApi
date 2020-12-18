using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThreeApi.Models;

namespace ThreeApi.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee> Add(Employee employee);
        Task<IEnumerable<Employee>> GetByDepartmentId(int departmentId);
        Task<IEnumerable<Employee>> GetById(int Id);
        Task<Employee> Fire(int id);
    }
}
