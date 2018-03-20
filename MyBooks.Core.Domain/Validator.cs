using System;
using System.Collections.Generic;
using System.Linq;

namespace MyBooks.Core.Domain
{
    public class Validator
    {
        private readonly List<AppError> _errors = new List<AppError>();
        
        public Validator CheckValue(Func<AppError> checkValue)
        {
            var error = checkValue();
            if (error != null)
            {
                _errors.Add(error);
            }

            return this;
        }

        public Validator AddErrorIfWrongValue(Func<bool> checkValue, string errorCode, string errorMessage)
        {
            var error = checkValue();
            if (error)
            {
                _errors.Add(new AppError(errorCode, errorMessage));
            }

            return this;
        }

        public Validator AddErrorIfWrongValue(Func<bool> checkValue, AppError apperror)
        {
            var error = checkValue();
            if (error)
            {
                _errors.Add(apperror);
            }

            return this;
        }

        public void ThrowIfErrors()
        {
            if (_errors.Any())
            {
                throw new DomainException(_errors.ToArray());
            }
        }
    }
}