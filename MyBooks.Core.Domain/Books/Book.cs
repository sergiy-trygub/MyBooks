using System;
using MyBooks.Core.Domain.Authors;

namespace MyBooks.Core.Domain.Books
{
    public class Book : Entity
    {
        public Book(BookId id, string title, string description, AuthorId authorId, DateTime? publishDate = null)
        {
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
    }
}
