namespace MyBooks.Core.App.Commands.AddBookToLibrary
{
    public class AddBookResult
    {
        public AddBookResult(string isbn)
        {
            ISBN = isbn;
        }

        public string ISBN { get; }
    }
}
