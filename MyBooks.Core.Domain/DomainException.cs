using System;
using System.Collections.Generic;

namespace MyBooks.Core.Domain
{
    public class DomainException : Exception
    {
        public DomainException(string errorCode, string errorMessage)
        {
            Errors = new[] {new AppError(errorCode, errorMessage)};
        }

        public DomainException(params AppError[] errors)
        {
            Errors = errors;
        }
        
        public IEnumerable<AppError> Errors { get; }
    }
}