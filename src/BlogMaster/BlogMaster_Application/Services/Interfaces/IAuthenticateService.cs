namespace BlogMaster_Application.Services.Interfaces {
    public interface IAuthenticateService {
        Task<string> AuthenticateAuthor(string email, string password);
    }
}
