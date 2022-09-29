using FluentValidation;
using FluentValidation.Results;

namespace Feed.Business.Models;

public class Author : Entity
{
    public string AvatarUrl { get; set; }
    public string Name { get; set; }
    public string Role { get; set; }

    public IEnumerable<Post>? Posts { get; set; }

    public ValidationResult Validate()
    {
        return new AuthorValidation().Validate(this);
    }
}

public class AuthorValidation : AbstractValidator<Author>
{

    public static string RequiredErrorMsg => "O campo {PropertyName} precisa ser fornecido";
    public static string MaxMinErrorMsg => "O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres";

    public AuthorValidation()
    {        

        RuleFor(f => f.Name)
            .NotEmpty()
            .WithMessage(RequiredErrorMsg)
            .Length(2, 100)
            .WithMessage(MaxMinErrorMsg);

        RuleFor(f => f.AvatarUrl)
            .NotEmpty()
            .WithMessage(RequiredErrorMsg)
            .Length(10, 100)
            .WithMessage(MaxMinErrorMsg);

        RuleFor(f => f.Role)
            .NotEmpty()
            .WithMessage(RequiredErrorMsg)
            .Length(2, 100)
            .WithMessage(MaxMinErrorMsg);
    }
}