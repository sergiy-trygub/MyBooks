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
        
        public MyBook AddBook(Book book, IEnumerable<MyTag> tags)
        {
           
            return new MyBook(UserId, book, tags);
        }
    }
}
