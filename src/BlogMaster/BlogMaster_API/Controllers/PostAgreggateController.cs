using BlogMaster_Application.Services.Interfaces;
using BlogMaster_Domain.Agreggates;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BlogMaster_API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PostAgreggateController : ControllerBase {
        private readonly IPostAgreggateService _postAgreggateService;

        public PostAgreggateController(IPostAgreggateService postAgreggateService)
        {
            _postAgreggateService = postAgreggateService;
        }

        [HttpGet]
        public async Task<ActionResult<PostAgreggate>> GetById(
            [FromQuery][Required(ErrorMessage = "O QueryParam postId é obrigatório.")] int postId) {
            try {
                var postAgreggate = await _postAgreggateService.GetByPostId(postId);
                return Ok(postAgreggate);
            }
            catch {
                throw;
            }
        }
    }
}
