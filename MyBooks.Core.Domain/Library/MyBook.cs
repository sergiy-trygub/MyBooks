using System;
using System.Collections.Generic;
using MyBooks.Core.Domain.Books;

namespace MyBooks.Core.Domain.Library
{
    public class MyBook : IAggregateRoot
    {
        public MyBook(Guid userId, Book book, IEnumerable<MyTag> tags)
        {
            UserId = userId;
            Book = book;
            if (tags != null)
            {
                Tags = new List<MyTag>(tags);    
            }
            
            Created = DateTime.UtcNow;
        }

        public Guid UserId { get; }
        
        public Book Book { get; }
        
        public DateTime Created { get; }
        
        public IReadOnlyCollection<MyTag> Tags { get; }
        
        public MyReadingBook StartReading(DateTime startDate)
        {
            return new MyReadingBook(UserId, Book, startDate);
        }
    }
}