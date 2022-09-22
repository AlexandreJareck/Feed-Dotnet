using Feed.Api.DTOs;
using Feed.Business.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Feed.Api.Controllers
{
    [Route("api/authors")]
    public class AuthorController : MainController
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDTO>>> Get()
        {
            var author = await _authorRepository.GetAll();
            return Ok(author);
        }
    }
}
