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

        [HttpGet("get-authors/")]
        public async Task<ActionResult<IEnumerable<AuthorDTO>>> GetAll()
        {
            var author = await _authorRepository.GetAll();
            return Ok(author);
        }

        [HttpGet("{id: guid}")]
        public async Task<ActionResult<AuthorDTO>> Get(Guid id)
        {
            var author = await _authorRepository.GetById(id);
            return Ok(author);
        }

        [HttpPost]
        public async Task<ActionResult<AuthorDTO>> Add(AuthorDTO authorDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var author = await _authorService.Add(_mapper.Map<Author>(authorDTO));

            authorDTO.Id = author.Id;

            return Ok(authorDTO);
        }

        [HttpPut("{id: guid}")]
        public async Task<ActionResult<AuthorDTO>> Update(Guid id, AuthorDTO authorDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _authorService.Update(_mapper.Map<Author>(authorDTO));

            return Ok(authorDTO);
        }

        [HttpDelete]
        public async Task<ActionResult<AuthorDTO>> Remove(Guid id)
        {
            var authorDTO = _mapper.Map<AuthorDTO>(await _authorRepository.GetById(id));

            if (authorDTO == null)
                return NotFound();

            await _authorService.Remove(id);

            return Ok();
        }
    }
}
