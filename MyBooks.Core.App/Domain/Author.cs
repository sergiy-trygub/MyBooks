using System;
using MyBooks.Shared.Domain;

namespace MyBooks.Core.App.Domain
{
    public class Author : ValueObject
    {
        public Author(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; }

        public string LastName { get; }

        public static Author Create(string firstName, string lastName)
        {
            new Validator()
                .AddErrorIfWrongValue(() => string.IsNullOrEmpty(firstName), AppError.AuthorFirstNameNotSet)
                .AddErrorIfWrongValue(() => string.IsNullOrEmpty(lastName), AppError.AuthorLastNameNotSet)
                .ThrowIfErrors();

            return new Author(firstName, lastName);
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