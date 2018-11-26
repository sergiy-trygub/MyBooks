using System.Threading.Tasks;
using MyBooks.Shared.Commands;
using IMyBookRepository = MyBooks.Core.App.Repositories.IMyBookRepository;

namespace MyBooks.Core.App.Commands.StartReadingBook
{
    public class StartReadingBookCommand : CommandAsync<StartReadingBookParameters, string>
    {
        private readonly IMyBookRepository _myBookRepository;

        public StartReadingBookCommand(IMyBookRepository myBookRepository)
        {
            _myBookRepository = myBookRepository;
        }

        protected override async Task HandleCommandAsync(StartReadingBookParameters input, CommandResult<string> commandResult)
        {
            var myBook = await _myBookRepository.FindAsync(input.Isbn);

            if (myBook == null)
            {
                commandResult.AddError("error_book_notfound", "Book not found");
                return;
            }

            var startedBook = myBook.StartReading(input.StartDate);
            
            await _myBookRepository.SaveAsync(startedBook);
            
            commandResult.Success(input.Isbn);
        }
    }
}