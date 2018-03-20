using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBooks.Core.App.Queries.GetMyBooksList
{
    public class GetMyBooksListQuery
    {
        private readonly IMyBooksQueryRepository _myBooksQueryRepository;

        public GetMyBooksListQuery(IMyBooksQueryRepository myBooksQueryRepository)
        {
            _myBooksQueryRepository = myBooksQueryRepository;
        }

        public async Task<IEnumerable<MyBooksListViewModel>> QueryAsync(Guid userId)
        {
            return await _myBooksQueryRepository.GetAsync(userId);
        }
    }
}