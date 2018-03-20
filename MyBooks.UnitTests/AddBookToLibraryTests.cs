using System;
using System.Threading.Tasks;
using Moq;
using MyBooks.Core.App;
using MyBooks.Core.App.Commands;
using MyBooks.Core.App.Commands.AddBookToLibrary;
using MyBooks.Core.Domain.Authors;
using MyBooks.Core.Domain.Library;
using Xunit;

namespace MyBooks.UnitTests
{
    public class AddBookToLibraryTests
    {
        private readonly Mock<IAuthorRepository> _authorRepoMock = new Mock<IAuthorRepository>();
        private readonly Mock<IMyBookRepository> _bookRepoMock = new Mock<IMyBookRepository>();

        public AddBookToLibraryTests()
        {
            _authorRepoMock.Setup(m => m.FindAsync(It.IsAny<string>(), It.IsAny<string>()))
            .Returns<string, string>((fname, lname) =>
            {
                Author author = null;
                return Task.FromResult(author);
            });

            _bookRepoMock.Setup(m => m.SaveAsync(It.IsAny<MyBook>())).Returns(() => {
                return Task.FromResult(1);
            });
        }

        [Fact]
        public async Task Add_Book_ToLibrary_Test()
        {
            AddBookToLibraryCommand command = new AddBookToLibraryCommand(_authorRepoMock.Object, _bookRepoMock.Object);

            var parameters = new AddBookParameters
            {
                UserId = Guid.NewGuid(),
                Title = "test title",
                AuthorFirstName = "firstname",
                AuthorLastName = "lastname",
                Isbn = "test"
            };

            CommandResult<AddBookResult> result = await command.HandleAsync(parameters);
            Assert.True(result.Succeeded);
            Assert.IsType<AddBookResult>(result.Data);
            Assert.Equal("test", result.Data.ISBN);
        }
    }
}