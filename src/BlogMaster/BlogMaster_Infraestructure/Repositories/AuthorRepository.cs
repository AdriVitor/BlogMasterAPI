using BlogMaster_Domain.Entities;
using BlogMaster_Infraestructure.AppDbContext;
using BlogMaster_Infraestructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogMaster_Infraestructure.Repositories {
    public class AuthorRepository : IAuthorRepository {
        private readonly Context _context;
        public AuthorRepository(Context context)
        {
            _context = context;
        }

        public async Task Add(Author author) {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Author author) {
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
        }

        public async Task<Author> GetById(int id) {
            var author = await _context.Authors.FirstOrDefaultAsync(a=>a.Id == id);
            return author;
        }

        public async Task Update(Author author) {
            _context.Authors.Update(author);
            await _context.SaveChangesAsync();
        }

        public async Task<List<int>> GetAuthorIdByName(string name) {
            var authorList = await _context
                            .Authors
                            .Where(a => a.Name == name)
                            .Select(a=>a.Id)
                            .ToListAsync();

            return authorList;
        }

        public async Task<bool> ValidateLoginAuthor(string email, string password) {
            var login = await _context
                            .Authors
                            .FirstOrDefaultAsync(a=> a.Email.ToLower() == email.ToLower() && a.Password == password);

            if(login is null) {
                return false;
            }

            return true;
        }
    }
}
