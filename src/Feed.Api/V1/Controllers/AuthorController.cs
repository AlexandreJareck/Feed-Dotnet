using AutoMapper;
using Feed.Api.Controllers;
using Feed.Api.DTOs;
using Feed.Api.Extensions;
using Feed.Business.Interfaces;
using Feed.Business.Interfaces.Repositories;
using Feed.Business.Interfaces.Services;
using Feed.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Feed.Api.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}")]
    public class AuthorController : MainController
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public AuthorController(IAuthorRepository authorRepository,
                                IAuthorService authorService,
                                IMapper mapper,
                                INotifier notifier) : base(notifier)
        {
            _authorRepository = authorRepository;
            _authorService = authorService;
            _mapper = mapper;
        }

        [ClaimsAuthorize("Author", "Teste")]
        [HttpGet("get-authors/")]
        public async Task<ActionResult<IEnumerable<AuthorDTO>>> GetAll()
        {
            var author = await _authorRepository.GetAll();
            return Ok(author);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AuthorDTO>> Get(Guid id)
        {
            var author = await _authorRepository.GetById(id);
            return Ok(author);
        }

        [HttpPost]
        public async Task<ActionResult<AuthorDTO>> Add(AuthorDTO authorDTO)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var author = await _authorService.Add(_mapper.Map<Author>(authorDTO));

            authorDTO.Id = author.Id;

            return CustomResponse(authorDTO);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<AuthorDTO>> Update(Guid id, AuthorDTO authorDTO)
        {
            if (id != authorDTO.Id)
            {
                NotifyError("Id Inválido!");
                return CustomResponse(authorDTO);
            }

            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

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

            return CustomResponse(authorDTO);
        }
    }
}
