namespace Library.Domain.Contracts
{
    public interface ILibraryUnitOfWork : IDisposable
    {
        IBookRepository BookRepository { get; }
        IClientRepository ClientRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }
        ILoanRepository LoanRepository { get; }
        void Commit();
    }
}