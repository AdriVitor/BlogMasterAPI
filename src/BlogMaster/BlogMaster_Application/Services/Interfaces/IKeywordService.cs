using BlogMaster_Application.DTOs.KeywordDTO;
using BlogMaster_Domain.ValueObjects;

namespace BlogMaster_Application.Services.Interfaces {
    public interface IKeywordService {
        Task Add(int postId, List<string> newKeywords);
        Task Delete(KeywordDTO keywordDTO);
        Task Update(KeywordDTO keywordDTO);
        Task<List<Keyword>> GetAllByPostId(int postId);
    }
}
