using System;
using MyBooks.Shared.Domain;

namespace MyBooks.Core.App.Domain
{
    public class MyReadingBook : App.Domain.MyBook
    {
        public MyReadingBook(Guid userId, Book book, DateTime startDate) : base(userId, book, null)
        {
            StartDate = startDate;
            PercentDone = 0;
        }

        public DateTime StartDate { get; }
        
        public byte PercentDone { get; private set; }
        
        public void SetReadingProgress(byte percentDone, DateTime progressDate)
        {
            new Validator()
                .AddErrorIfWrongValue(() => percentDone > 100, AppError.WrongReadingProgressValue)
                .ThrowIfErrors();

            PercentDone = percentDone;
        }

        public void FinishReading(DateTime finishedOn)
        {
            
        }

    }
}