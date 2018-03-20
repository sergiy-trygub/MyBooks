using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MyBooks.Core.Domain;

namespace MyBooks.Core.App.Commands
{
    public interface ICommand<TInput, TOutput>
    {
        CommandResult<TOutput> Handle(TInput input);
    }

    public abstract class CommandAsync<TInput, TOutput> where TInput: IValidatableObject
    {
        protected abstract Task HandleCommandAsync(TInput input, CommandResult<TOutput> commandResult);

        public async Task<CommandResult<TOutput>> HandleAsync(TInput input)
        {
            CommandResult<TOutput> result = new CommandResult<TOutput>();

            try
            {
                await HandleCommandAsync(input, result);
            }
            catch (DomainException domainException)
            {
                result.AddError(domainException.Errors.ToArray());
            }
            catch (Exception e)
            {
                result.AddError(new AppError("general_error", e.Message));
            }

            return result;
        }
    }
        
}
