using System.Threading.Tasks;
using StellarPayRoll.Core.Dtos;
using StellarPayRoll.Core.Models.Entities;
using StellarPayRoll.Core.Paging;

namespace StellarPayRoll.Core.Domain.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<Employee> GetEmployeeAsync(string employeeNo);

        Task<PaginatedList<EmployeeDto>> LoadEmployeesAsync(string filter, int page, int limit);

    }
}
