using BlogMaster_Application.DTOs.LoginAuthorDTO;
using BlogMaster_Application.DTOs.AuthorDTO;
using BlogMaster_Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlogMaster_API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase {
        private readonly IAuthenticateService _authenticateService;

        public AuthenticateController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }

        [HttpPost]
        public async Task<ActionResult<string>> AuthenticateAuthor([FromBody] LoginAuthorDTO authorDTO) {
            try {
                var token = await _authenticateService.AuthenticateAuthor(authorDTO.Email, authorDTO.Password);
                return Ok(token);
            }
            catch {
                throw;
            }
        }
    }
}
