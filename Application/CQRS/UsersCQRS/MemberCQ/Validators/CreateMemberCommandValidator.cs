﻿using Application.CQRS.GenericsCQRS.Generic.Validator;
using Application.CQRS.GenericsCQRS.User.Commands;
using Application.CQRS.GenericsCQRS.User.Validators;
using Domain.Entity.User;

namespace Application.CQRS.UsersCQRS.MemberCQ.Validators
{
    public class CreateMemberCommandValidator(ValidatorHelper helper)
        : CreateUserCommandValidator<Member, CreateUserDTO>(helper);
}
