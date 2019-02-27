using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookBoundCoreAPI.Contexts;
using BookBoundCoreAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookBoundCoreAPI.Services
{
    public class BooksRepository : IBooksRepository, IDisposable
    {
        private BookBoundContext _context;

        public BooksRepository(BookBoundContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddBook(Book bookToAdd)
        {
            if (bookToAdd == null)
            {
                throw new ArgumentNullException(nameof(bookToAdd));
            }

            _context.Add(bookToAdd);
        }

        public void DeleteBook(Book bookToDelete)
        {
            if (bookToDelete == null)
            {
                throw new ArgumentNullException(nameof(bookToDelete));
            }

            _context.Remove(bookToDelete);
        }        

        public async Task<Book> GetBookAsync(int bookId)
        {
            return await _context.Books
                //.Include(b => b.Author)
                .FirstOrDefaultAsync(b => b.Id == bookId);
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _context.Books
                //.Include(b => b.Author)
                .ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            // return true if 1 or more entities were changed
            return (await _context.SaveChangesAsync() > 0);
        }

        public void UpdateBook(Book bookToUpdate)
        {
            // no code required, entity tracked by context.  Including 
            // this is best practice to ensure other implementations of the 
            // contract (eg a mock version) can execute code on update
            // when needed.
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
}
