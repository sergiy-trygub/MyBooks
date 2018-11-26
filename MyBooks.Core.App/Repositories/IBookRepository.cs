using System.Threading.Tasks;
using MyBooks.Core.App.Domain;

namespace MyBooks.Core.App.Repositories
{
    public interface IBookRepository
    {
        Task<Book> FindAsync(string isbn);

        Task SaveAsync(Book book);
    }
}