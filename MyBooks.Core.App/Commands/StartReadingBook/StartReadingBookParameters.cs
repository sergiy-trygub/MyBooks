using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyBooks.Core.App.Commands.StartReadingBook
{
    public sealed class StartReadingBookParameters : IValidatableObject
    {
        public string Isbn { get; set; }
        
        public DateTime StartDate { get; set; }
        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new System.NotImplementedException();
        }
    }
}