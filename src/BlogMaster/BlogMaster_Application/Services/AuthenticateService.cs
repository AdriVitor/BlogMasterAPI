using BlogMaster_Application.Services.Interfaces;
using BlogMaster_Infraestructure.Repositories.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlogMaster_Application.Services {
    public class AuthenticateService : IAuthenticateService {
        private const string Secret = "A8B5U3Q6Z7T4D9F5G1A6S8F1S21FS5F1SD5F1S51FS231SFDF4SDF12SD";
        private readonly IAuthorRepository _authorRepository;

        public AuthenticateService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        #region Public Methods

        public async Task<string> AuthenticateAuthor(string email, string password) {
            var validateLogin = await _authorRepository.ValidateLoginAuthor(email, password);
            if(validateLogin == false) {
                throw new Exception("Email ou senha incorretos");
            }

            var token = GenerateToken(email);
            var tokenValidated = ValidateToken(token);

            if(tokenValidated == false) {
                throw new Exception("Problema ao validar o token");
            }

            return token;
        }

        #endregion

        #region Private Methods
        private string GenerateToken(string email) {
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Secret);

            var tokenDescriptor = new SecurityTokenDescriptor() {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Email, email)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private bool ValidateToken(string token) {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Secret);

            try {
                tokenHandler.ValidateToken(token, new TokenValidationParameters {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                return true;
            }
            catch {
                return false;
            }
        }

        #endregion
    }
}
