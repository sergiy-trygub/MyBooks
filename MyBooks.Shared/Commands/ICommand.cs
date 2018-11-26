using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MyBooks.Shared.Domain;

namespace MyBooks.Shared.Commands
{
    public interface ICommand<TInput, TOutput>
    {
        CommandResult<TOutput> Handle(TInput input);
    }

    public abstract class CommandAsync<TInput, TOutput> where TInput: ICommandValidator
    {
        protected abstract Task HandleCommandAsync(TInput input, CommandResult<TOutput> commandResult);

        public async Task<CommandResult<TOutput>> HandleAsync(TInput input)
        {
            CommandResult<TOutput> result = new CommandResult<TOutput>();

            try
            {
                var validatationErrors = input.Validate();
                if (validatationErrors.Any())
                {
                    throw new DomainException(validatationErrors);
                }

                await HandleCommandAsync(input, result);
            }
            catch (DomainException domainException)
            {
                result.Fail(domainException.Errors.ToArray());
            }
            catch (Exception e)
            {
                result.Fail(new AppError("general_error", e.Message));
            }

            return result;
        }
    }
        
}
