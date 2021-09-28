using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Entity.Concrete;
using Entity.DTOs.User;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserUpdateValidator : AbstractValidator<UserForUpdateDto>
    {
        public UserUpdateValidator()
        {

            RuleFor(x => x.IdentityNumber).NotNull();
            RuleFor(x => x.IdentityNumber).Length(11);

            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Email).NotNull();

            RuleFor(x => x.Phone).NotNull();
            RuleFor(x => x.Phone).Length(10);
            RuleFor(x => x.Phone).Must(StartsWithFive).WithMessage("Telefon numarası 5 ile başlamalı.");

            RuleFor(x => x.FirstName).NotNull();
            RuleFor(x => x.FirstName).MinimumLength(2).MaximumLength(20);

            RuleFor(x => x.LastName).NotNull();
            RuleFor(x => x.LastName).MinimumLength(2).MaximumLength(40);

            RuleFor(x => x.VehiclePlateNumber).NotNull();

        }

        private bool StartsWithFive(string arg)
        {
            return arg.StartsWith("5");
        }


    }
}

