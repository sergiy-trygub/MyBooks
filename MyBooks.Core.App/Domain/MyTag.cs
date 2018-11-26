using MyBooks.Shared.Domain;

namespace MyBooks.Core.App.Domain
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