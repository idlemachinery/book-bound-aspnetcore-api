using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookBoundCoreAPI.Contexts;
using BookBoundCoreAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookBoundCoreAPI.Services
{
    public class AuthorsRepository : IAuthorsRepository, IDisposable
    {
        private BookBoundContext _context;

        public AuthorsRepository(BookBoundContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddAuthor(Author authorToAdd)
        {
            if (authorToAdd == null)
            {
                throw new ArgumentNullException(nameof(authorToAdd));
            }

            _context.Add(authorToAdd);
        }

        public void DeleteAuthor(Author authorToDelete)
        {
            if (authorToDelete == null)
            {
                throw new ArgumentNullException(nameof(authorToDelete));
            }

            _context.Remove(authorToDelete);
        }

        public async Task<Author> GetAuthorAsync(int authorId)
        {
            return await _context.Authors
                .FirstOrDefaultAsync(b => b.Id == authorId);
        }

        public async Task<IEnumerable<Author>> GetAuthorsAsync()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            // return true if 1 or more entities were changed
            return (await _context.SaveChangesAsync() > 0);
        }

        public void UpdateAuthor(Author authorToUpdate)
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
