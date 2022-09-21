namespace Feed.Api.DTOs
{
    public class AuthorDTO
    {
        public string AvatarUrl { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }

        public IEnumerable<PostDTO> Posts { get; set; }
    }
}
