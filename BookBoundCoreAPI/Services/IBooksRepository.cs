using BookBoundCoreAPI.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookBoundCoreAPI.Services
{
    public interface IBooksRepository
    {
        Task<Book> GetBookAsync(int bookId);

        Task<IEnumerable<Book>> GetBooksAsync();

        void UpdateBook(Book bookToUpdate);

        void AddBook(Book bookToAdd);

        void DeleteBook(Book bookToDelete);

        Task<bool> SaveChangesAsync();
    }
}
