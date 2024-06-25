using Library.Domain.Models;

namespace Library.SharedKernel.Dto
{
    public class BookDto
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public StatusOfBook StatusOfBook { get; set; }
    }
}
