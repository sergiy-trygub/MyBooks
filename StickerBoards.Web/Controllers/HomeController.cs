using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StickerBoards.Web.Infrastructure;
using StickerBoards.Web.Models;
using StickerBoards.Web.ViewModels;

namespace StickerBoards.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBoardsRepository _boardsRepository;

        public HomeController(IBoardsRepository boardsRepository)
        {
            _boardsRepository = boardsRepository;
        }

        public async Task<IActionResult> Index()
        {
            var boards = await _boardsRepository.GetBoardsAsync();

            var viewModel = new BoardsViewModel
            {
                Boards = boards
            };

            return View(viewModel);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
