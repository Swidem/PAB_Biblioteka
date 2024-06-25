using Library.Domain.Models;

namespace Library.Domain.Contracts
{
    public interface IBookRepository : IRepository<Book>
    {
        int GetMaxId();
    }
}