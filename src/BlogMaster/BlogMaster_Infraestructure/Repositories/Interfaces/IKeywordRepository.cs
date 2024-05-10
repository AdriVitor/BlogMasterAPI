using BlogMaster_Domain.ValueObjects;

namespace BlogMaster_Infraestructure.Repositories.Interfaces {
    public interface IKeywordRepository {
        Task Add(Keyword keyword);
        Task Delete(Keyword keyword);
        Task Update(Keyword keyword);
        Task<Keyword> Get(Keyword keyword);
        Task<List<Keyword>> GetAllByPostId(int postId);
        Task<List<int>> GetPostIdByKeyword(string word);
    }
}
