﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SWD_Laundry_Backend.Core.Models;

namespace SWD_Laundry_Backend.Core.Validator;

public class CustomerValidator : AbstractValidator<CustomerModel>
{
    public CustomerValidator()
    {
        RuleFor(x => x.ApplicationUserId).NotEmpty().WithMessage("ApllicationUserId is required.");
        RuleFor(x => x.BuildingId).NotEmpty().WithMessage("BuildingId is required.");
    }
}
