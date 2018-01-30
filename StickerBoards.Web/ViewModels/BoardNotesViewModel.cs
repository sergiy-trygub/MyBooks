using StickerBoards.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StickerBoards.Web.ViewModels
{
    public class BoardNotesViewModel
    {
        public Guid BoardId { get; set; }

        public IEnumerable<StickerNote> Notes { get; set; }
    }
}
