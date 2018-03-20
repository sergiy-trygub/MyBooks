using System;
using MyBooks.Core.Domain.Authors;

namespace MyBooks.Core.Domain.Books
{
    public class Book : Entity
    {
        public Book(BookId id, string title, string description, AuthorId authorId, DateTime? publishDate = null)
        {
            new Validator()
                .AddErrorIfWrongValue(() => string.IsNullOrEmpty(id.ISBN), AppError.BookIsbnNotSet)
                .AddErrorIfWrongValue(() => string.IsNullOrEmpty(title), AppError.BookTitleNotSet)
                .AddErrorIfWrongValue(() => authorId == null, AppError.BookAuthorNotSet)
                .ThrowIfErrors();

            Title = title;
            Description = description;
            AuthorId = authorId;
            Id = id;
            PublishDate = publishDate;
        }

        public BookId Id { get; }
        
        public string Title { get; }
        
        public string Description { get; }
        
        public AuthorId AuthorId { get; }

        public DateTime? PublishDate {get;}

        public static Book GetOrCreate(string isbn, string title, string description, Author author,
            DateTime? publishDate = null, Func<Book> findBook = null)
        {
            var book = findBook?.Invoke();

            if (book == null)
            {
                new Validator()
                    .AddErrorIfWrongValue(() => author == null, AppError.BookAuthorNotSet)
                    .ThrowIfErrors();
                
                book = new Book(new BookId(isbn), title, description, author.Id, publishDate );
            }

            return book;
        }
    }
}
