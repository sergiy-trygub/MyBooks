using System;
using MyBooks.Shared.Domain;

namespace MyBooks.Core.App.Domain
{
    public class Book : Entity
    {
        public Book(BookId id, string title, string description, Author author, DateTime? publishDate = null)
        {
            new Validator()
                .AddErrorIfWrongValue(() => string.IsNullOrEmpty(id.ISBN), AppError.BookIsbnNotSet)
                .AddErrorIfWrongValue(() => string.IsNullOrEmpty(title), AppError.BookTitleNotSet)
                .AddErrorIfWrongValue(() => author == null, AppError.BookAuthorNotSet)
                .ThrowIfErrors();

            Title = title;
            Description = description;
            Author = author;
            Id = id;
            PublishDate = publishDate;
        }

        public BookId Id { get; }
        
        public string Title { get; }
        
        public string Description { get; }
        
        public Author Author { get; }

        public DateTime? PublishDate {get;}

        public static Book Create(string isbn, string title, string description, string authorFirstname, 
            string authorLastname, DateTime? publishDate = null)
        {
                new Validator()
                    .AddErrorIfWrongValue(() => authorFirstname == null || authorLastname == null, AppError.BookAuthorNotSet)
                    .ThrowIfErrors();

            var book = new Book(
                new BookId(isbn), 
                title, 
                description, 
                new Author(authorFirstname, authorLastname), 
                publishDate);
            
            return book;
        }

        public static Book Empty => new Book();
    }
}
