using FluentValidation;

namespace Feed.Business.Models;

public class Author : Entity
{
    public string AvatarUrl { get; set; }
    public string Name { get; set; }
    public string Role { get; set; }

    public IEnumerable<Post> Posts { get; set; }
}

public class AuthorValidation : AbstractValidator<Author>
{
    public AuthorValidation()
    {
        RuleFor(f => f.Name)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
    }
}