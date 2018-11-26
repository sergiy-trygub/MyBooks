using System;
using System.Collections.Generic;

namespace MyBooks.Core.App.Domain
{
    public class MyLibrary
    {
        public MyLibrary(Guid userId)
        {
            UserId = userId;
        }
        
        public Guid UserId { get; }
        
        public App.Domain.MyBook AddBook(Book book, IEnumerable<MyTag> tags)
        {
           
            return new App.Domain.MyBook(UserId, book, tags);
        }
    }
}
