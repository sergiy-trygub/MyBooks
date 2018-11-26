namespace MyBooks.Core.App.Domain
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
