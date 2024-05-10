using BlogMaster_Application.DTOs.AuthorDTO;
using BlogMaster_Domain.Entities;

namespace BlogMaster_Application.Services.Interfaces {
    public interface IAuthorService {
        Task<Author> GetById(int id);
        Task Add(AuthorDTO authorDTO);
        Task Delete(int id);
        Task Update(AuthorDTO authorDTO);
    }
}
