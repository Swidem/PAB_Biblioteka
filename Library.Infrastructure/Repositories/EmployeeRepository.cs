using Library.Domain;
using Library.Domain.Contracts;
using Library.Domain.Models;

namespace Library.Infrastructure.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly LibraryDbContext _libraryDbContext;

        public EmployeeRepository(LibraryDbContext context) : base(context)
        {
            _libraryDbContext = context;
        }

        public int GetMaxId()
        {
            return _libraryDbContext.Employees.Max(x => x.EmployeeId);
        }
    }
}
