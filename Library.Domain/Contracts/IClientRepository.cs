using Library.Domain.Models;

namespace Library.Domain.Contracts
{
    public interface IClientRepository : IRepository<Client>
    {
        int GetMaxId();
    }
}