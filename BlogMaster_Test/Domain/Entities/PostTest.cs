using BlogMaster_Domain.Entities;

namespace BlogMaster_Test.Domain.Entities {
    public class PostTest {

        [Fact]
        public void ValidatePropertyId() {
            var exception = Assert.Throws<Exception>(() => {
                var post = new Post(0, "title test", "description test", DateTime.Now, 1);
            });

            Assert.Equal("Informe um id válido", exception.Message);
            Assert.Equal(typeof(Exception), exception.GetType());
        }

        [Fact]
        public void ValidatePropertyTitle() {
            var exception = Assert.Throws<Exception>(() => {
                var post = new Post(1, "", "description test", DateTime.Now, 1);
            });

            Assert.Equal("Informe um título com até 120 caracateres", exception.Message);
            Assert.Equal(typeof(Exception), exception.GetType());
        }

        [Fact]
        public void ValidatePropertyDescription() {
            var exception = Assert.Throws<Exception>(() => {
                var post = new Post(1, "title test", "", DateTime.Now, 1);
            });

            Assert.Equal("Tamanho de post inválido", exception.Message);
            Assert.Equal(typeof(Exception), exception.GetType());
        }

        [Fact]
        public void ValidatePropertyPostDate() {
            var exception = Assert.Throws<Exception>(() => {
                var post = new Post(1, "title test", "description test", DateTime.MinValue, 1);
            });

            Assert.Equal("Informe uma data de postagem válida", exception.Message);
            Assert.Equal(typeof(Exception), exception.GetType());
        }

        [Fact]
        public void ValidatePropertAuthorId() {
            var exception = Assert.Throws<Exception>(() => {
                var post = new Post(1, "title test", "description test", DateTime.Now, 0);
            });

            Assert.Equal("Informe um author válido", exception.Message);
            Assert.Equal(typeof(Exception), exception.GetType());
        }
    }
}
