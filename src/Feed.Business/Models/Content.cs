using FluentValidation;

namespace Feed.Business.Models;

public class Content : Entity
{
    public Guid PostId { get; set; }
    public string Type { get; set; }
    public string Comment { get; set; }

    public Post Post { get; set; }
}

public class ContentValidation : AbstractValidator<Content>
{
    public ContentValidation()
    {
        RuleFor(f => f.Comment)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(3, 500)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
    }
}
