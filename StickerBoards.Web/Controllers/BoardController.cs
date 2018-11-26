using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StickerBoards.Web.Infrastructure;
using StickerBoards.Web.Models;
using StickerBoards.Web.ViewModels;

namespace StickerBoards.Web.Controllers
{
    public class BoardController : Controller
    {
        private readonly STBoardNotesRepository _boardNotesRepository;

        public BoardController(STBoardNotesRepository boardNotesRepository)
        {
            _boardNotesRepository = boardNotesRepository;
        }

        [HttpGet("/board/{id}/notes")]
        public async Task<IActionResult> Notes(string id)
        {
            Guid boardId = Guid.Parse(id);

            var notes = await _boardNotesRepository.GetBoardNotesAsync(boardId);

            return View(new BoardNotesViewModel { BoardId = boardId, Notes = notes });
        }

        [HttpGet("/board/{id}/add-note")]
        public IActionResult AddNote(string id)
        {
            ViewBag.BoardId = id;
            return View();
        }

        [HttpPost("/board/{id}/add-note")]
        public async Task<IActionResult> AddNote(string id, StickerNote note)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }

            note.Id = Guid.NewGuid();

            await _boardNotesRepository.CreateAsync(note);

            return RedirectToAction("Notes", new { id = note.BoardId.ToString() });
        }

        [HttpDelete("/board/{id}/remove-note/{noteId}")]
        public async Task<ActionResult> RemoveNote(string id, string noteId)
        {
            var noteGuid = Guid.Parse(id);
            var note = await _boardNotesRepository.GetBoardNoteAsync(noteGuid);

            if (note != null)
            {
                await _boardNotesRepository.DeleteAsync(noteGuid);
                return RedirectToAction("Notes", new { id = note.BoardId.ToString() });
            }
            else
            {
                ModelState.AddModelError("", "Not found");
                return new BadRequestResult();// BadRequestObjectResult(ModelState);
            }
        }
    }
}