using Feed.Business.Models;

namespace Feed.Business.Tests
{
    public class AuthorTest
    {
        [Fact(DisplayName = "Validation quantity errors in model Author")]
        [Trait("Category", "Author")]
        public void Author_ValidateQuantitytityErrors_HeMustValid()
        {
            var author = new Author
            {
                AvatarUrl = "",
                Name = "",
                Role = ""
            };

            var result = author.Validate();

            Assert.False(result.IsValid);
            Assert.Equal(6, result.Errors.Count);
        }

        [Fact(DisplayName = "Validation new model Author")]
        [Trait("Category", "Author")]
        public void Author_NewAuthor_HeMustValid()
        {
            var author = new Author
            {
                AvatarUrl = "https://avatars.githubusercontent.com/u/49285794?s=400&u=ea4ddbb8ff30286480a713882ff8c8064c54f852&v=4",
                Name = "Alexandre",
                Role = "Teste"
            };

            var result = author.Validate();

            Assert.True(result.IsValid);
        }
    }
}