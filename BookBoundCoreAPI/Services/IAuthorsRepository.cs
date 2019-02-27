using BookBoundCoreAPI.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookBoundCoreAPI.Services
{
    public interface IAuthorsRepository
    {
        Task<Author> GetAuthorAsync(int authorId);

        Task<IEnumerable<Author>> GetAuthorsAsync();

        void UpdateAuthor(Author authorToUpdate);

        void AddAuthor(Author authorToAdd);

        void DeleteAuthor(Author authorToDelete);

        Task<bool> SaveChangesAsync();
    }
}
