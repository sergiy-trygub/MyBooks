using System;

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
            var id = new AuthorId(Guid.NewGuid());
            return new Author(id, firstName, lastName);
        }
    }
}