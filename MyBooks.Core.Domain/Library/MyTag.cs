namespace MyBooks.Core.Domain.Library
{
    public class MyTag : ValueObject
    {
        public MyTag(string value)
        {
            Value = value;
        }

        public string Value { get; }
    }
}