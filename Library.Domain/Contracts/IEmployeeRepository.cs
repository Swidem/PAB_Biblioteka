using Library.Domain.Models;

namespace Library.Domain.Contracts
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        int GetMaxId();
    }
}
