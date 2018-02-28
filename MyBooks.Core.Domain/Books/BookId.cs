namespace MyBooks.Core.Domain.Books
{
    public class BookId
    {
        public BookId(string isbn)
        {
            ISBN = isbn;
        }

        public string ISBN { get; }
    }
}
