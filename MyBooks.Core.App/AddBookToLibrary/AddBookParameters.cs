using System;

namespace MyBooks.Core.App.AddBookToLibrary
{
    public class AddBookParameters
    {
        public Guid UserId {get; set;}
        public string Isbn {get;set;}
        public string Title {get;set;}
        public string Description {get;set;}
        public string AuthorFirstName {get;set;}
        public string AuthorLastName {get;set;}
    }
}
