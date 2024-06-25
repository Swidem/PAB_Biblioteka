using Library.SharedKernel.Dto;

namespace Library.Application.Services
{
    public interface IBookService
    {
        List<BookDto> GetAll();
        BookDto GetById(int id);
        int Create(CreateBookDto dto);
        void Update(UpdateBookDto dto);
        void Delete(int id);

    }
}