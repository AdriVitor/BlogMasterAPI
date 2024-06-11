using BlogMaster_Domain.Entities.Abstracts;
using BlogMaster_Domain.Validations;
using BlogMaster_Domain.ValueObjects;

namespace BlogMaster_Domain.Entities {
    public class Post : Base {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime PostDate { get; private set; }
        public int AuthorId { get; private set; }

        public Post(int id, string title, string description, DateTime postDate, int authorId)
        {
            ValidateProperties(id, title, description, postDate, authorId);

            Id = id;
            Title = title;
            Description = description;
            PostDate = postDate;
            AuthorId = authorId;
        }

        public void ValidateProperties(int id, string title, string description, DateTime postDate, int authorId) {
            DomainExceptionValidation.When(string.IsNullOrEmpty(title) || title.Length > 120, "Informe um título com até 120 caracateres");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description) || description.Length > 250, "Tamanho de post inválido");
            DomainExceptionValidation.When(postDate == DateTime.MinValue || postDate == DateTime.MaxValue, "Informe uma data de postagem válida");
            DomainExceptionValidation.When(authorId <= 0, "Informe um author válido");
        }
    }
}
