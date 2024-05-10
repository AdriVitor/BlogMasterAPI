using BlogMaster_Domain.Entities;
using BlogMaster_Domain.Validations;

namespace BlogMaster_Domain.ValueObjects {
    public class Keyword {
        public int PostId { get; private set; }
        //public Post Post { get; private set; }
        public string Word { get; private set; }

        public Keyword(int postId, string word)
        {
            ValidateProperties(postId, word);
            PostId = postId;
            Word = word;
        }

        public void ValidateProperties(int postId, string word) {
            DomainExceptionValidation.When(postId <= 0, "Informe um post válido");
            DomainExceptionValidation.When(string.IsNullOrEmpty(word) || word.Length > 40, "Informe um título com tamanho válido");
        }
    }
}
