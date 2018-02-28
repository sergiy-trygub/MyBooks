using System.Threading.Tasks;

namespace MyBooks.Core.Domain.Authors
{
    public interface IAuthorRepository
    {
        Task<Author> FindAsync(string firstName, string lastName);

        Task SaveAsync(Author author);
    }
}