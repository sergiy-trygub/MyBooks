using MyBooks.Core.App;
using MyBooks.Core.Domain.Authors;
using MyBooks.Core.Domain.Library;
using System;
using System.Threading.Tasks;

namespace MyBooks.Core.App.AddBookToLibrary
{
    public class AddBookToLibraryCommand : ICommandAsync<AddBookParameters, AddBookResult>
    {
        private readonly IAuthorRepository _authorRepo;
        private readonly IMyBookRepository _mybookRepo;

        public AddBookToLibraryCommand(IAuthorRepository authorRepo, IMyBookRepository mybookRepo)
        {
            _authorRepo=authorRepo;
            _mybookRepo=mybookRepo;
        }

        public async Task<AddBookResult> HandleAsync(AddBookParameters input)
        {
            var library = new MyLibrary(input.UserId);

            var author = await _authorRepo.FindAsync(input.AuthorFirstName, input.AuthorLastName);

            if (author == null)
            {
                author = Author.Create(input.AuthorFirstName, input.AuthorLastName);
            }

            var book = library.AddBook(input.Isbn, input.Title, input.Description, author, null);

            await _mybookRepo.SaveAsync(book);

            return new AddBookResult();
        }
    }
}
