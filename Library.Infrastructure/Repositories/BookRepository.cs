﻿

using Library.Domain;
using Library.Domain.Contracts;
using Library.Domain.Models;

namespace Library.Infrastructure.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private readonly LibraryDbContext _libraryDbContext;

        public BookRepository(LibraryDbContext context) : base(context)
        {
            _libraryDbContext = context;
        }

        public int GetMaxId()
        {
            return _libraryDbContext.Books.Max(x => x.BookId);
        }
    }
}