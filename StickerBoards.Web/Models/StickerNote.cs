using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StickerBoards.Web.Models
{
    public class StickerNote
    {
        public Guid Id { get; set; }

        public Guid BoardId { get; set; }

        public string Text { get; set; }

        public int Severity { get; set; }
    }
}
