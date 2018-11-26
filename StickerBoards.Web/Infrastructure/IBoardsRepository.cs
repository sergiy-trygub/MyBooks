using StickerBoards.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StickerBoards.Web.Infrastructure
{
    public interface IBoardsRepository
    {
        Task<IEnumerable<Board>> GetBoardsAsync();

        Task CreateBoardAsync();

        Task DeleteBoardAsync();
    }
}
