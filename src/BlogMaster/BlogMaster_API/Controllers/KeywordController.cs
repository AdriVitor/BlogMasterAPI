using BlogMaster_Application.DTOs.KeywordDTO;
using BlogMaster_Application.Services.Interfaces;
using BlogMaster_Domain.ValueObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BlogMaster_API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class KeywordController : ControllerBase {
        private readonly IKeywordService _keywordService;

        public KeywordController(IKeywordService keywordService)
        {
            _keywordService = keywordService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Keyword>>> GetByPostId(
            [FromQuery][Required(ErrorMessage = "O QueryParam postId é obrigatório.")] int postId) {
            try {
                var keywordList = await _keywordService.GetAllByPostId(postId);
                return Ok(keywordList);
            }
            catch {
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(
            [FromQuery][Required(ErrorMessage = "O QueryParam postId é obrigatório.")] int postId,
            [FromBody] List<string> newKeywords) {
            try {
                await _keywordService.Add(postId, newKeywords);
                return Ok();
            }
            catch {
                throw;
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] KeywordDTO keywordDTO) {
            try {
                await _keywordService.Delete(keywordDTO);
                return Ok();
            }
            catch {
                throw;
            }
        }
    }
}
