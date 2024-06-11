using BlogMaster_Application.DTOs.CommentDTO;
using BlogMaster_Application.Services.Interfaces;
using BlogMaster_Domain.ValueObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BlogMaster_API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentController : ControllerBase {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Comment>>> GetByPostId(
            [FromQuery][Required(ErrorMessage = "O QueryParam postId é obrigatório.")] int postId) {
            try {
                var commentList = await _commentService.GetByPostId(postId);
                return Ok(commentList);
            }
            catch {
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CommentDTO commentDTO) {
            try {
                await _commentService.Add(commentDTO);
                return Ok();
            }
            catch {
                throw;
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] CommentDTO commentDTO) {
            try {
                await _commentService.Delete(commentDTO);
                return Ok();
            }
            catch {
                throw;
            }
        }
    }
}
