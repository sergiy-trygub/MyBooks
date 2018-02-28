using System;
using System.Collections.Generic;
using MyBooks.Core.Domain.Books;

namespace MyBooks.Core.Domain.Library
{
    public class MyFinishedBook : MyBook
    {
        public MyFinishedBook(Guid userId, Book book, IEnumerable<MyTag> tags) : base(userId, book, tags)
        {
        }
        
        public void BeginReading(DateTime startedOn)
        {
            
        }
    }
}