using AutoMapper;
using Business.Service;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Models.Entities.DTOs;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentController : Controller
{
    private readonly ICommentService _commentService;
    private readonly IMapper _mapper;

    public CommentController(ICommentService commentService, IMapper mapper)
    {
        _commentService = commentService;
        _mapper = mapper;
    }
    
    // Get comments by predefined coffee id, use mapper to map to CreateCommentDto
    [HttpGet("GetCommentByPredefinedCoffeeId/{id}")]
    public ActionResult GetCommentByPredefinedCoffeeId(Guid id)
    {
        var comments = _commentService.GetCommentByPredefinedCoffeeId(id);
        return Ok(comments);
    }
    
    [HttpGet("GetCommentByUserId/{id}")]
    public ActionResult GetCommentByUserId(Guid id)
    {
        var comments = _commentService.GetCommentByUserId(id);
        var mappedComments = _mapper.Map<CreateCommentDto>(comments);
        return Ok(mappedComments);
    }
    
    [HttpGet("{id}")]
    public ActionResult GetComment(Guid id)
    {
        var comment = _commentService.GetComment(id);
        var mappedComment = _mapper.Map<CreateCommentDto>(comment);
        return Ok(mappedComment);
    }
    
    [HttpPost]
    public ActionResult CreateComment([FromBody] CreateCommentDto createCommentDto)
    {
        var comment = new Comment();
        _mapper.Map(createCommentDto, comment);
        var createdComment = _commentService.CreateComment(comment);
        return CreatedAtAction(nameof(GetComment), new {id = createdComment.Id}, createdComment);
    }
    
    [HttpDelete("{id}")]
    public ActionResult DeleteComment(Guid id)
    {
        _commentService.DeleteComment(id);
        return NoContent();
    }
}