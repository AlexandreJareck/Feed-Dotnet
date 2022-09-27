using AutoMapper;
using Feed.Api.Controllers;
using Feed.Api.DTOs;
using Feed.Business.Interfaces;
using Feed.Business.Interfaces.Repositories;
using Feed.Business.Interfaces.Services;
using Feed.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Feed.Api.V1.Controllers;

[Authorize]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/posts")]
public class PostController : MainController
{
    private readonly IContentRepository _contentRepository;
    private readonly IContentService _contentService;

    private readonly IPostRepository _postRepository;
    private readonly IPostService _postService;

    private readonly IMapper _mapper;

    public PostController(IContentRepository contentRepository,
                          IContentService contentService,
                          IPostRepository postRepository,
                          IPostService postService,
                          IMapper mapper,
                          INotifier notifier) : base(notifier) 
    {
        _contentRepository = contentRepository;
        _contentService = contentService;
        _postRepository = postRepository; 
        _postService = postService;
        _mapper = mapper;
    }

    [HttpGet("get-posts/")]
    public async Task<ActionResult<IEnumerable<PostDTO>>> GetAll()
    {
        var postsDTO = _mapper.Map<IEnumerable<PostDTO>>(await _postRepository.GetAll());            

        return CustomResponse(postsDTO);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<PostDTO>> Get(Guid id)
    {
        var postDTO = _mapper.Map<PostDTO>(await _postRepository.GetById(id));

        return CustomResponse(postDTO);
    }

    [HttpPost]
    public async Task<ActionResult<PostDTO>> Add(PostDTO postDTO)
    {
        if (!ModelState.IsValid)
            return CustomResponse(ModelState);

        var post = await _postService.Add(_mapper.Map<Post>(postDTO));

        if (post != null)
            postDTO.Id = post.Id;

        return CustomResponse(postDTO);
    }

    [HttpPut] 
    public async Task<ActionResult<PostDTO>> Update(Guid id, PostDTO postDTO)
    {
        if(id != postDTO.Id)
        {
            NotifyError("Id Inválido!");
            return CustomResponse(postDTO);
        }

        if (!ModelState.IsValid)
            return CustomResponse(ModelState);

        await _postService.Update(_mapper.Map<Post>(postDTO));        

        return CustomResponse(postDTO);
    }

    [HttpDelete]
    public async Task<ActionResult<PostDTO>> Remove(Guid id)
    {
        var postDTO = _mapper.Map<Post>(await _postRepository.GetById(id));

        if (postDTO == null)
            return NotFound();

        return CustomResponse(postDTO);
    }
}
