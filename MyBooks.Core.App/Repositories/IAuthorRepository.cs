using System.Threading.Tasks;

namespace MyBooks.Core.App.Repositories
{
    public interface IAuthorRepository
    {
        Task<App.Domain.Author> FindAsync(string firstName, string lastName);

        Task SaveAsync(App.Domain.Author author);
    }
}