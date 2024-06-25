using Library.SharedKernel.Dto;

namespace Library.Application.Services
{
    public interface IEmployeeService
    {
        List<EmployeeDto> GetAll();
        EmployeeDto GetById(int id);
        int Create(CreateEmployeeDto dto);
        void Update(UpdateEmployeeDto dto);
        void Delete(int id);
    }
}

