using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyBooks.Core.App.Commands.AddBookToLibrary
{
    public class AddBookParameters : IValidatableObject
    {
        public Guid UserId {get; set;}
        public string Isbn {get;set;}
        public string Title {get;set;}
        public string Description {get;set;}
        public string AuthorFirstName {get;set;}
        public string AuthorLastName {get;set;}
        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}
