using Library.Domain.Models;

namespace Library.Domain.Contracts
{
    // interfejsy repozytoriów specyficznych
    public interface ILoanRepository : IRepository<Loan>
    {
        int GetMaxId();
    }
}
