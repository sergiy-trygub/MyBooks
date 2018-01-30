using StickerBoards.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StickerBoards.Web.Infrastructure
{
    interface IBoardNotesRepository
    {
        Task<IEnumerable<StickerNote>> GetBoardNotesAsync(Guid boardId);

        Task<StickerNote> GetBoardNoteAsync(Guid noteId);

        Task CreateAsync(StickerNote note);

        Task DeleteAsync(Guid noteId);
    }
}
