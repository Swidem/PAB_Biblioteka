using AutoMapper;
using Library.Domain.Contracts;
using Library.Domain.Exceptions;
using Library.Domain.Models;
using Library.SharedKernel.Dto;

namespace Library.Application.Services
{
    public class LoanService : ILoanService
    {
        private readonly ILibraryUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LoanService(ILibraryUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<LoanDto> GetAll()
        {
            var loans = _unitOfWork.LoanRepository.GetAll();
            return _mapper.Map<List<LoanDto>>(loans);
        }

        public LoanDto GetById(int id)
        {
            var loan = _unitOfWork.LoanRepository.Get(id);
            if (loan == null)
            {
                throw new NotFoundException("Loan not found");
            }
            return _mapper.Map<LoanDto>(loan);
        }

        public int Create(CreateLoanDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("Invalid loan data");
            }

            var loan = _mapper.Map<Loan>(dto);

            _unitOfWork.LoanRepository.Insert(loan);
            _unitOfWork.Commit();

            return loan.LoanId;
        }

        public void Update(UpdateLoanDto dto)
        {
            var loan = _unitOfWork.LoanRepository.Get(dto.LoanId);
            if (loan == null)
            {
                throw new NotFoundException("Loan not found");
            }

            _mapper.Map(dto, loan);

            _unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            var loan = _unitOfWork.LoanRepository.Get(id);
            if (loan == null)
            {
                throw new NotFoundException("Loan not found");
            }

            _unitOfWork.LoanRepository.Delete(loan);
            _unitOfWork.Commit();
        }
    }
}