using System;
using System.Collections.Generic;
using System.Linq;

namespace MyBooks.Core.Domain.Authors
{
    public class Author
    {
        public Author(AuthorId id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public AuthorId Id { get; }
        
        public string FirstName { get; }
        
        public string LastName { get; }

        public static Author Create(string firstName, string lastName)
        {
            new Validator()
                .AddErrorIfWrongValue(() => string.IsNullOrEmpty(firstName), AppError.AuthorFirstNameNotSet)
                .AddErrorIfWrongValue(() => string.IsNullOrEmpty(lastName), AppError.AuthorLastNameNotSet)
                .ThrowIfErrors();
            
            var id = new AuthorId(Guid.NewGuid());
            return new Author(id, firstName, lastName);
        }

        public static Author GetOrCreate(
            string firstName, 
            string lastName, 
            Func<Author> findAuthor)
        {
            if (findAuthor == null)
            {
                throw new InvalidOperationException();
            }
            
            Author author = findAuthor();

            if (author == null)
            {
                author = Create(firstName, lastName);
            }

            return author;
        }
    }
}