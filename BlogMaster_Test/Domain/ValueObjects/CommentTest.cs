using BlogMaster_Domain.ValueObjects;

namespace BlogMaster_Test.Domain.ValueObjects {
    public class CommentTest {

        [Fact]
        public void ValidatePropertyAuthorId() {
            var exception = Assert.Throws<Exception>(() => {
                var comment = new Comment(0, 1, "comment test", DateTime.Now);
            });

            Assert.Equal("Informe um author válido", exception.Message);
            Assert.Equal(typeof(Exception), exception.GetType());
        }

        [Fact]
        public void ValidatePropertyPostId() {
            var exception = Assert.Throws<Exception>(() => {
                var comment = new Comment(1, 0, "comment test", DateTime.Now);
            });

            Assert.Equal("Informe um post válido", exception.Message);
            Assert.Equal(typeof(Exception), exception.GetType());
        }

        [Fact]
        public void ValidatePropertyDescription() {
            var exception = Assert.Throws<Exception>(() => {
                var comment = new Comment(1, 1, "", DateTime.Now);
            });

            Assert.Equal("Tamanho de post inválido", exception.Message);
            Assert.Equal(typeof(Exception), exception.GetType());
        }

        [Fact]
        public void ValidatePropertyDateOfPosting() {
            var exception = Assert.Throws<Exception>(() => {
                var comment = new Comment(1, 1, "comment test", DateTime.MaxValue);
            });

            Assert.Equal("Informe uma data de postagem válida", exception.Message);
            Assert.Equal(typeof(Exception), exception.GetType());
        }
    }
}
