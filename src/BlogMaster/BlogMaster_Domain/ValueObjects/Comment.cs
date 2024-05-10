using BlogMaster_Domain.Entities;
using BlogMaster_Domain.Validations;

namespace BlogMaster_Domain.ValueObjects {
    public class Comment {
        public int AuthorId { get; private set; }
        public int PostId { get; private set; }
        public Post Post { get; private set; }
        public string Description { get; private set; }
        public DateTime DateOfPosting { get; private set; }

        public Comment(int authorId, int postId, string description, DateTime dateOfPosting)
        {
            ValidateProperties(authorId, postId, description, dateOfPosting);
            AuthorId = authorId;
            PostId = postId;
            Description = description;
            DateOfPosting = dateOfPosting;
        }

        public void ValidateProperties(int authorId, int postId, string description, DateTime dateOfPosting) {
            DomainExceptionValidation.When(authorId <= 0, "Informe um author válido");
            DomainExceptionValidation.When(postId <= 0, "Informe um post válido");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description) || description.Length > 250, "Tamanho de post inválido");
            DomainExceptionValidation.When(dateOfPosting == DateTime.MinValue || dateOfPosting == DateTime.MaxValue, "Informe uma data de postagem válida");            
        }
    }
}
