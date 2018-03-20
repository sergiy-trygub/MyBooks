using System.Linq;
using MyBooks.Core.Domain;
using MyBooks.Core.Domain.Authors;
using Xunit;

namespace MyBooks.UnitTests
{
    public class AuthorTests
    {
        [Fact]
        public void Throw_error_if_firstname_notset_test()
        {
            var exception = Assert.Throws<DomainException>(() =>
            {
                var author = Author.Create(null, null);
            });
            Assert.NotNull(exception);
            Assert.Equal(AppError.AuthorFirstNameNotSet, exception.Errors.FirstOrDefault(e => e.Code == AppError.AuthorFirstNameNotSet.Code));
            Assert.Equal(AppError.AuthorLastNameNotSet, exception.Errors.FirstOrDefault(e => e.Code == AppError.AuthorLastNameNotSet.Code));
        }

        [Fact]
        public void Create_author_test()
        {
            var author = Author.Create("firstname", "lastname");
            Assert.Equal("firstname", author.FirstName);
            Assert.Equal("lastname", author.LastName);
        }
    }
}