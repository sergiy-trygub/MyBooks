using System;
using System.Threading.Tasks;
using MyBooks.Core.App.Repositories;
using MyBooks.Shared.Commands;
using Author = MyBooks.Core.App.Domain.Author;
using Book = MyBooks.Core.App.Domain.Book;
using IAuthorRepository = MyBooks.Core.App.Repositories.IAuthorRepository;
using IMyBookRepository = MyBooks.Core.App.Repositories.IMyBookRepository;
using MyLibrary = MyBooks.Core.App.Domain.MyLibrary;

namespace MyBooks.Core.App.Commands.AddBookToLibrary
{
    public class AddBookToLibraryCommand : CommandAsync<AddBookParameters, AddBookResult>
    {
        private readonly IAuthorRepository _authorRepo;
        private readonly IMyBookRepository _mybookRepo;
        private readonly IBookRepository _bookRepo;

        public AddBookToLibraryCommand(IAuthorRepository authorRepo, IMyBookRepository mybookRepo, IBookRepository bookRepo)
        {
            _authorRepo=authorRepo;
            _mybookRepo=mybookRepo;
            _bookRepo = bookRepo;
        }

        protected override async Task HandleCommandAsync(AddBookParameters input, CommandResult<AddBookResult> commandResult)
        {            
            // try to find book by isbn
            var book = await _bookRepo.FindAsync(input.Isbn);
            if (book != null)
            {
                if (!validateBookAttributes(book, input))
                {
                    commandResult.Fail();
                    return;
                }
            }
            else
            {
                // create new book
                book = Book.Create(input.Isbn, input.Title, input.Description, input.AuthorFirstName,
                    input.AuthorLastName);
            }
            
            var library = new MyLibrary(input.UserId);
            
            var mybook = library.AddBook(book, null);

            await _bookRepo.SaveAsync(book);
            
            await _mybookRepo.SaveAsync(mybook);
            
            commandResult.Success(new AddBookResult(input.Isbn));
        }

        private bool validateBookAttributes(Book book, AddBookParameters input)
        {
            return book.Title.Equals(input.Title, StringComparison.CurrentCultureIgnoreCase) &&
                   book.Author.FirstName.Equals(input.AuthorFirstName, StringComparison.CurrentCultureIgnoreCase) &&
                   book.Author.LastName.Equals(input.AuthorLastName, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
