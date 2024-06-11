using System.ComponentModel.DataAnnotations;

namespace BlogMaster_Application.DTOs.LoginAuthorDTO {
    public class LoginAuthorDTO {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
