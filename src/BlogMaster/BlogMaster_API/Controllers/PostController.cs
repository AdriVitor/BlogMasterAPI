using BlogMaster_Application.DTOs.PostDTO;
using BlogMaster_Application.Services.Interfaces;
using BlogMaster_Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BlogMaster_API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetById([FromRoute] int id) {
            try {
                var author = await _postService.GetById(id);
                return Ok(author);
            }
            catch {
                throw;
            }
        }

        [HttpGet("search/pagination")]
        public async Task<ActionResult<IEnumerable<Post>>> GetPostsPagination(
            [FromQuery][Required(ErrorMessage = "O QueryParam page é obrigatório.")] int page, 
            [FromQuery][Required(ErrorMessage = "O QueryParam quantityItems é obrigatório.")] int quantityItems) {
            try {
                var postListPagination = await _postService.GetPostsPagination(page, quantityItems);
                return Ok(postListPagination);
            }
            catch {
                throw;
            }
        }

        [HttpGet("search/advanced/pagination")]
        public async Task<ActionResult<IEnumerable<Post>>> GetPostsAdvancedSearchPagination(
            [FromQuery][Required(ErrorMessage = "O QueryParam page é obrigatório.")] int page,
            [FromQuery][Required(ErrorMessage = "O QueryParam quantityItems é obrigatório.")] int quantityItems,
            [FromQuery][Required(ErrorMessage = "O QueryParam quantityItems é obrigatório.")] string parameter) {
            try {
                var postListAvancedSearchPagination = await _postService.GetPostsAdvancedSearchPagination(page, quantityItems, parameter);
                return Ok(postListAvancedSearchPagination);
            }
            catch {
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PostDTO postDTO) {
            try {
                await _postService.Add(postDTO);
                return Ok();
            }
            catch {
                throw;
            }
        }

        [HttpPatch]
        public async Task<ActionResult> Patch([FromBody] PostDTO postDTO) {
            try {
                await _postService.Update(postDTO);
                return Ok();
            }
            catch {
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id) {
            try {
                await _postService.Delete(id);
                return Ok();
            }
            catch {
                throw;
            }
        }
    }
}
