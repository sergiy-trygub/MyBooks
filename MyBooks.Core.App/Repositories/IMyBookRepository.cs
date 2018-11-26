using System.Threading.Tasks;

namespace MyBooks.Core.App.Repositories
{
    public interface IMyBookRepository
    {
        Task<App.Domain.MyBook> FindAsync(string isbn);

        Task SaveAsync(App.Domain.MyBook myBook);
    }
}