﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using Shared.Business.DTOs;

namespace Shared.Business.Validators
{
    public class TaskValidator : AbstractValidator<TaskDTO>
    {
        public TaskValidator()
        {
            RuleFor(task => task.TaskName).NotEmpty();
            RuleFor(task => task.Number).NotEmpty().GreaterThan(0);
            RuleFor(task => task.Amount).GreaterThan(0);
            RuleFor(task => task.Date).NotEmpty();
            RuleFor(task => task.StartDate.Value).SetValidator(new DateLaterThanNow());
            RuleFor(task => task.EndDate.Value).GreaterThan(task => task.StartDate.Value).When(task => task.StartDate.HasValue);
        }
    }
}