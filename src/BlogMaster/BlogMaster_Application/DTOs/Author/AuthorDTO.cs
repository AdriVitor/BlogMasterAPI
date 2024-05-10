using BlogMaster_Domain.Entities;

namespace BlogMaster_Application.DTOs.AuthorDTO {
    public class AuthorDTO {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CPF { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Author ConvertToAuthor() {
            var author = new Author(Id, Name, Email, Password, CPF, DateOfBirth);

            return author;
        }
    }
}
