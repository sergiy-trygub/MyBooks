using System;
using System.Threading.Tasks;

namespace MyBooks.Core.App
{
    public interface ICommand<TInput, TOutput>
    {
        TOutput Handle(TInput input);
    }

    public interface ICommandAsync<TInput, TOutput>
    {
        Task<TOutput> HandleAsync(TInput input);
    }
}
