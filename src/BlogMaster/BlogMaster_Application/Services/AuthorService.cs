using BlogMaster_Application.DTOs.AuthorDTO;
using BlogMaster_Application.Services.Interfaces;
using BlogMaster_Domain.Entities;
using BlogMaster_Infraestructure.Repositories.Interfaces;

namespace BlogMaster_Application.Services {
    public class AuthorService : IAuthorService {
        private readonly IAuthorRepository _authorRepository;
        private readonly ICacheRepository _cacheRepository;
        private readonly string cacheKey = "author:";
        private string idCacheKey;
        public AuthorService(IAuthorRepository authorRepository, ICacheRepository cacheRepository)
        {
            _authorRepository = authorRepository;
            _cacheRepository = cacheRepository;
        }

        #region Public Methods
        public async Task Add(AuthorDTO authorDTO) {
            var author = authorDTO.ConvertToAuthor();

            await _authorRepository.Add(author);
        }

        public async Task Delete(int id) {
            var author = await GetById(id);

            await _authorRepository.Delete(author);
        }

        public async Task<Author> GetById(int id) {
            Author? author;
            idCacheKey = id.ToString();

            var authorCache = _cacheRepository.Get<AuthorDTO>(cacheKey + idCacheKey);
            if (authorCache is null)
            {
                author = await _authorRepository.GetById(id);
                if(author is null)
                {
                    throw new Exception("Não foi localizado nenhum autor");
                }

                _cacheRepository.Set(cacheKey + idCacheKey, author);
                
                return author;
            }

            author = authorCache.ConvertToAuthor();

            return author;
        }

        public async Task Update(AuthorDTO authorDTO) {
            var author = authorDTO.ConvertToAuthor();

            await _authorRepository.Update(author);
            idCacheKey = author.Id.ToString();
            _cacheRepository.Set(cacheKey + idCacheKey, author);
        }

        #endregion
    }
}
