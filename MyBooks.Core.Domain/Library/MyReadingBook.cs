using System;
using System.Collections.Generic;
using MyBooks.Core.Domain.Books;

namespace MyBooks.Core.Domain.Library
{
    public class MyReadingBook : MyBook
    {
        public MyReadingBook(Guid userId, Book book, IEnumerable<MyTag> tags) : base(userId, book, tags)
        {
        }

        public void SetReadingProgress(byte percentDone)
        {

        }
        
        public void FinishReading(DateTime finishedOn)
        {
            
        }

    }
}