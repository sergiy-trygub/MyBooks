using System;
using System.Threading.Tasks;
using Moq;
using MyBooks.Core.App.Commands.StartReadingBook;
using MyBooks.Core.Domain.Authors;
using MyBooks.Core.Domain.Books;
using MyBooks.Core.Domain.Library;
using Xunit;

namespace MyBooks.UnitTests
{
    public class StartReadingBookTests
    {
        private readonly Mock<IMyBookRepository> _bookRepoMock = new Mock<IMyBookRepository>();

        public StartReadingBookTests()
        {
            _bookRepoMock.Setup(m => m.SaveAsync(It.IsAny<MyBook>())).Returns(() => {
                return Task.FromResult(1);
            });

            _bookRepoMock.Setup(m => m.FindAsync(It.IsAny<string>())).Returns(() =>
            {
                var book = new Book(new BookId("test"), "test title", "test description", new AuthorId(Guid.NewGuid()));
                return Task.FromResult(new MyBook(Guid.NewGuid(), book, null));
            });
        }
        
        [Fact]
        public async Task Start_reading_book_test()
        {
            var command = new StartReadingBookCommand(_bookRepoMock.Object);
            var parameters = new StartReadingBookParameters
            {
                Isbn = "test",
                StartDate = DateTime.UtcNow
            };
            var result = await command.HandleAsync(parameters);
            Assert.True(result.Succeeded);
        }
    }
}