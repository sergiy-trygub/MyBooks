using System;
using MyBooks.Shared.Commands;
using MyBooks.Shared.Domain;

namespace MyBooks.Core.App.Commands.StartReadingBook
{
    public sealed class StartReadingBookParameters : ICommandValidator
    {
        public string Isbn { get; set; }
        
        public DateTime StartDate { get; set; }
        
        public AppError[] Validate()
        {
            throw new NotImplementedException();
        }
    }
}