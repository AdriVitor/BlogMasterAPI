using BlogMaster_Application.DTOs.AuthorDTO;
using BlogMaster_Application.Services.Interfaces;
using BlogMaster_Domain.Entities;
using BlogMaster_Infraestructure.Repositories.Interfaces;

namespace BlogMaster_Application.Services {
    public class AuthorService : IAuthorService {
        private readonly IAuthorRepository _authorRepository;
        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task Add(AuthorDTO authorDTO) {
            var author = authorDTO.ConvertToAuthor();

            await _authorRepository.Add(author);
        }

        public async Task Delete(int id) {
            var author = await GetById(id);

            await _authorRepository.Delete(author);
        }

        public async Task<Author> GetById(int id) {
            var author = await _authorRepository.GetById(id);
            if(author is null) {
                return null;
            }

            return author;
        }

        public async Task Update(AuthorDTO authorDTO) {
            var author = authorDTO.ConvertToAuthor();

            await _authorRepository.Update(author);
        }
    }
}
