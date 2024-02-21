using CarBook.Application.Features.Mediator.Commands.CommentCommands;
using CarBook.Application.Features.RepositoryPattern;
using CarBook.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _repository;
        private readonly IMediator _mediator;

        public CommentsController(IGenericRepository<Comment> repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult CommentList() 
        {
            var values = _repository.GetAll();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentCommand comment)
        {
            await _mediator.Send(comment);
            return Ok("Comment başarıyla oluşturuldu");
        }

        [HttpDelete]
        public IActionResult RemoveComment(int id)
        {
            var value = _repository.GetById(id);
            _repository.Remove(value);
            return Ok("Comment başarıyla silindi");
        }

        [HttpPut]
        public IActionResult UpdateComment(Comment comment)
        {
            _repository.Update(comment);
            return Ok("Comment başarıyla güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var value = _repository.GetById(id);
            return Ok(value);
        }


        [HttpGet("GetCommentsByBlogId")]
        public IActionResult GetCommentsByBlogId(int id)
        {
            var values = _repository.GetCommentsByBlogId(id);
            return Ok(values);
        }
    }
}
