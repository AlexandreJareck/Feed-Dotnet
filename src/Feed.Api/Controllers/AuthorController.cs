using AutoMapper;
using Feed.Api.DTOs;
using Feed.Business.Interfaces.Repositories;
using Feed.Business.Interfaces.Services;
using Feed.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace Feed.Api.Controllers
{
    [Route("api/authors")]
    public class AuthorController : MainController
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public AuthorController(IAuthorRepository authorRepository, IAuthorService authorService, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _authorService = authorService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDTO>>> Get()
        {
            var author = await _authorRepository.GetAll();
            return Ok(author);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<AuthorDTO>>> Add(AuthorDTO authorDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var author = await _authorService.Add(_mapper.Map<Author>(authorDTO));

            authorDTO.Id = author.Id;

            return Ok(authorDTO);
        }
    }
}
