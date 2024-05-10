using BlogMaster_Application.DTOs.AuthorDTO;
using BlogMaster_Application.Services.Interfaces;
using BlogMaster_Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogMaster_API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetById([FromRoute] int id) {
            try {
                var author = await _authorService.GetById(id);
                return Ok(author);
            }
            catch{
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AuthorDTO authorDTO) {
            try {
                await _authorService.Add(authorDTO);
                return Ok();
            }
            catch {
                throw;
            }
        }

        [HttpPatch]
        public async Task<ActionResult> Patch([FromBody] AuthorDTO authorDTO) {
            try {
                await _authorService.Update(authorDTO);
                return Ok();
            }
            catch {
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id) {
            try {
                await _authorService.Delete(id);
                return Ok();
            }
            catch {
                throw;
            }
        }
    }
}
