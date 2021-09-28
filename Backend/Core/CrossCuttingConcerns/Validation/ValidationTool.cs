using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationException = FluentValidation.ValidationException;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator,object entity) // Validate methodunun referans tutucusu IValidator'dur.
        {
            var context = new ValidationContext<object>(entity); // object türünde parametreden gelen entity.
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors); //result valid değilse ilgili hata mesajını döndür.
            }

        }
    }
}
