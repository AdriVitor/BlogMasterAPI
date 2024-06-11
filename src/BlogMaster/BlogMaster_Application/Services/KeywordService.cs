using BlogMaster_Application.DTOs.KeywordDTO;
using BlogMaster_Application.Services.Interfaces;
using BlogMaster_Domain.ValueObjects;
using BlogMaster_Infraestructure.Repositories.Interfaces;

namespace BlogMaster_Application.Services {
    public class KeywordService : IKeywordService {
        private readonly IKeywordRepository _keywordRepository;
        public KeywordService(IKeywordRepository keywordRepository) {
            _keywordRepository = keywordRepository;
        }

        #region Public Methods
        public async Task Add(int postId, List<string> newKeywords) {
            var keywordListActually = await _keywordRepository.GetAllByPostId(postId);

            if(keywordListActually.Count == 10 || (keywordListActually.Count + newKeywords.Count > 10)) {
                throw new Exception("O limite de palavras-chave é de 10 pra cada post");
            }

            foreach (var newKeyword in newKeywords) {
                var keyword = new Keyword(postId, newKeyword);

                ValidateKeywordsDuplicates(keywordListActually, keyword);

                await _keywordRepository.Add(keyword);
            }
        }

        public async Task Delete(KeywordDTO keywordDTO) {
            var keyword = await _keywordRepository.Get(keywordDTO.ConvertToKeyword());
            if(keyword is null)
            {
                throw new Exception("Não foi possível deletar a palavra-chave");
            }

            await _keywordRepository.Delete(keyword);
        }

        public async Task<List<Keyword>> GetAllByPostId(int postId) {
            var keywordList = await _keywordRepository.GetAllByPostId(postId);

            return keywordList;
        }

        #endregion

        #region Private Methods
        private void ValidateKeywordsDuplicates(List<Keyword> keywordListActually, Keyword keyword) {
            if (keywordListActually.Exists(k=>k.Word == keyword.Word)) {
                throw new Exception("Não é possível adicionar a mesma palavra-chave identicas no mesmo post");
            }
        }

        #endregion
    }
}
