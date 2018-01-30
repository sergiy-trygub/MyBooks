using StickerBoards.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StickerBoards.Web.ViewModels
{
    public class BoardsViewModel
    {
        public IEnumerable<Board> Boards { get; set; }
    }
}
