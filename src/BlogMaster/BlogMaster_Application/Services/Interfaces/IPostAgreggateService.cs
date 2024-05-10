using BlogMaster_Domain.Agreggates;

namespace BlogMaster_Application.Services.Interfaces {
    public interface IPostAgreggateService {
        Task<PostAgreggate> GetByPostId(int id);
    }
}
