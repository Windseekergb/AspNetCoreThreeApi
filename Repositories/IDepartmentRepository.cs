using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThreeApi.Models;

namespace ThreeApi.Repositories
{
    public  interface IDepartmentRepository
    {
        Task<Department> Add(Department department);
        Task<IEnumerable<Department>> GetAll();
        Task<Department> GetById(int id);
    }
}
