using System.Collections.Generic;
using MyBooks.Shared.Domain;

namespace MyBooks.Shared.Commands
{
    public interface ICommandValidator
    {
        AppError[] Validate();
    }
}