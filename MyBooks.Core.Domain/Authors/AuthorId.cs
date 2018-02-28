using System;

namespace MyBooks.Core.Domain.Authors
{
    public class AuthorId
    {
        public AuthorId(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }

        public bool IsNew()
        {
            return Id == Guid.Empty;
        }
    }
}