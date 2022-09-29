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
    }
}