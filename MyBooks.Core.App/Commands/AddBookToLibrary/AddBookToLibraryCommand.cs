using System;
using System.Threading.Tasks;
using MyBooks.Core.Domain.Authors;
using MyBooks.Core.Domain.Books;
using MyBooks.Core.Domain.Library;

namespace MyBooks.Core.App.Commands.AddBookToLibrary
{
    public class AddBookToLibraryCommand : CommandAsync<AddBookParameters, AddBookResult>
    {
        private readonly IAuthorRepository _authorRepo;
        private readonly IMyBookRepository _mybookRepo;

        public AddBookToLibraryCommand(IAuthorRepository authorRepo, IMyBookRepository mybookRepo)
        {
            _authorRepo=authorRepo;
            _mybookRepo=mybookRepo;
        }

        protected override async Task HandleCommandAsync(AddBookParameters input, CommandResult<AddBookResult> commandResult)
        {            
            var library = new MyLibrary(input.UserId);

            var author = Author.GetOrCreate(
                input.AuthorFirstName, 
                input.AuthorLastName,
                () => Task.Run(() => _authorRepo.FindAsync(input.AuthorFirstName, input.AuthorLastName)).Result);

            var book = Book.GetOrCreate(
                input.Isbn, 
                input.Title, 
                input.Description, 
                author, 
                (DateTime?)null,
                () => Task.Run(() => _mybookRepo.FindAsync(input.Isbn)).Result?.Book);
            
            var mybook = library.AddBook(book, null);

            await _mybookRepo.SaveAsync(mybook);
            
            commandResult.Success(new AddBookResult(input.Isbn));
        }
    }
}
