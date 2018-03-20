using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyBooks.Core.App.Queries.GetMyBooksList;

namespace MyBooks.Core.App.Queries
{
    public interface IMyBooksQueryRepository
    {
        Task<IEnumerable<MyBooksListViewModel>> GetAsync(Guid userId);
    }
}