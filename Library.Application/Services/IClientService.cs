
using Library.SharedKernel.Dto;

namespace Library.Application.Services
{
    public interface IClientService
    {
        List<ClientDto> GetAll();
        ClientDto GetById(int id);
        int Create(CreateClientDto dto);
        void Update(UpdateClientDto dto);
        void Delete(int id);
    }
}
