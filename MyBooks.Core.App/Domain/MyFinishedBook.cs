using System;
using System.Collections.Generic;

namespace MyBooks.Core.App.Domain
{
    public class MyFinishedBook : App.Domain.MyBook
    {
        public MyFinishedBook(Guid userId, Book book, IEnumerable<MyTag> tags) : base(userId, book, tags)
        {
        }
        
        public void BeginReading(DateTime startedOn)
        {
            
        }
    }
}