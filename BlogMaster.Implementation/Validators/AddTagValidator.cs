using BlogMaster.Application.DTO.Tags;
using BlogMaster.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMaster.Implementation.Validators
{
    public class AddTagValidator : AbstractValidator<AddTagDTO>
    {
        public AddTagValidator(BMContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required ");

            RuleFor(x => x.Title).Must(x => !context.Tags.Any(u => u.Title == x))
                                .WithMessage("Tag with this title already exists.");

        }
    }
}
