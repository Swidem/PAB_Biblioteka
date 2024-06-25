using Library.SharedKernel.Dto;

namespace Library.Application.Services
{
    public interface ILoanService
    {
        List<LoanDto> GetAll();
        LoanDto GetById(int id);
        int Create(CreateLoanDto dto);
        void Update(UpdateLoanDto dto);
        void Delete(int id);
    }
}
