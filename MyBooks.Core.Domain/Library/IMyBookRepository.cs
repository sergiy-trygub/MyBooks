using System.Threading.Tasks;
using MyBooks.Core.Domain.Library;

namespace MyBooks.Core.Domain.Library
{
    public interface IMyBookRepository
    {
        Task<MyBook> FindAsync(string isbn);

        Task SaveAsync(MyBook myBook);
    }
}