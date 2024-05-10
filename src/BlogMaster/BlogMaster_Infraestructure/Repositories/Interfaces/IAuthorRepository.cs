using BlogMaster_Domain.Entities;

namespace BlogMaster_Infraestructure.Repositories.Interfaces {
    public interface IAuthorRepository {
        Task<Author> GetById(int id);
        Task Add(Author author);
        Task Delete(Author author);
        Task Update(Author author);
        Task<List<int>> GetAuthorIdByName(string name);
        Task<bool> ValidateLoginAuthor(string email, string password);
    }
}
