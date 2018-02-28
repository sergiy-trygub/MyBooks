using System;
using System.Collections.Generic;
using MyBooks.Core.Domain.Authors;
using MyBooks.Core.Domain.Books;

namespace MyBooks.Core.Domain.Library
{
    public class MyLibrary
    {
        public MyLibrary(Guid userId)
        {
            UserId = userId;
        }
        
        public Guid UserId { get; }
        
        public MyBook AddBook(string isbn, string title, string description, Author author, IEnumerable<MyTag> tags)
        {
            BookId bookId = new BookId(isbn); // validation ???

            var book = new Book(bookId, title, description, author.Id);
            
            return new MyBook(UserId, book, tags);
        }
    }
}
