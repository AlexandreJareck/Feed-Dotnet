using System.ComponentModel.DataAnnotations;

namespace Feed.Api.DTOs
{
    public class AuthorDTO
    {
        public const string ErrorMessage = "Campo {0} é obrigatório!";

        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = ErrorMessage)]
        public string AvatarUrl { get; set; }

        [Required(ErrorMessage = ErrorMessage)]
        [StringLength(64, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracateres", MinimumLength = 3)]
        public string Name { get; set; }
        public string Role { get; set; }

        public IEnumerable<PostDTO>? Posts { get; set; }
    }
}
