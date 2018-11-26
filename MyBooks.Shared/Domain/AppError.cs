namespace MyBooks.Shared.Domain
{
    public class AppError
    {
        public AppError(string code, string message)
        {
            Code = code;
            Message = message;
        }

        public string Code { get; }

        public string Message { get; }

        public static readonly AppError BookIsbnNotSet = new AppError("error_book_isbn_notset", "Book ISBN not set");
        public static readonly AppError BookTitleNotSet = new AppError("error_book_title_notset", "Book title not set");

        public static readonly AppError BookAuthorNotSet =
            new AppError("error_book_author_notset", "Book author not set");

        public static readonly AppError AuthorFirstNameNotSet =
            new AppError("error_author_firstname_notset", "Author first name not set");

        public static readonly AppError AuthorLastNameNotSet =
            new AppError("error_author_lastname_notset", "Author last name not set");

        public static readonly AppError WrongReadingProgressValue =
            new AppError("error_reading_progress_value", "Progress value must be less or equal 100");
    }
}