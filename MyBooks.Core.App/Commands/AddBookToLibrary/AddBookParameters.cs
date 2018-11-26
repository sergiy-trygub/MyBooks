using System;
using System.Collections.Generic;
using MyBooks.Shared.Commands;
using MyBooks.Shared.Domain;

namespace MyBooks.Core.App.Commands.AddBookToLibrary
{
    public class AddBookParameters : ICommandValidator
    {
        public Guid UserId {get; set;}
        public string Isbn {get;set;}
        public string Title {get;set;}
        public string Description {get;set;}
        public string AuthorFirstName {get;set;}
        public string AuthorLastName {get;set;}


        public AppError[] Validate()
        {
            var result = new List<AppError>();

            if (string.IsNullOrEmpty(Isbn))
                result.Add(AppError.BookIsbnNotSet);

            if (string.IsNullOrEmpty(Isbn))
                result.Add(AppError.BookIsbnNotSet);

            return result.ToArray();
        }
    }
}
