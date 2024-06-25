using Library.Domain;
using Library.Domain.Contracts;
using Library.Domain.Models;

namespace Library.Infrastructure.Repositories
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        private readonly LibraryDbContext _libraryDbContext;

        public ClientRepository(LibraryDbContext context) : base(context)
        {
            _libraryDbContext = context;
        }

        public int GetMaxId()
        {
            return _libraryDbContext.Clients.Max(x => x.ClientId);
        }
    }
}