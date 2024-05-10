using BlogMaster_Domain.Entities;

namespace BlogMaster_Test.Domain.Entities {
    public class AuthorTest {

        [Fact]
        public void ValidatePropertyId() {
            var exception = Assert.Throws<Exception>(() => {
                var author = new Author(0, "name test", "emailtest", "123456", "036104888999", new DateTime(2001, 04, 07));
            });

            Assert.Equal("Informe um id válido", exception.Message);
            Assert.Equal(typeof(Exception), exception.GetType());
        }

        [Fact]
        public void ValidatePropertyName() {
            var exception = Assert.Throws<Exception>(() => {
                var author = new Author(1, "", "emailtest", "123456", "036104888999", new DateTime(2001, 04, 07));
            });

            Assert.Equal("Informe um nome válido", exception.Message);
            Assert.Equal(typeof(Exception), exception.GetType());
        }

        [Fact]
        public void ValidatePropertyEmail() {
            var exception = Assert.Throws<Exception>(() => {
                var author = new Author(1, "nome test", "emailtest", "123456", "036104888999", new DateTime(2001, 04, 07));
            });

            Assert.Equal("Informe um email válido", exception.Message);
            Assert.Equal(typeof(Exception), exception.GetType());
        }

        [Fact]
        public void ValidatePropertyPassword() {
            var exception = Assert.Throws<Exception>(() => {
                var author = new Author(1, "nome test", "emailtest@gmail.com", "", "036104888999", new DateTime(2001, 04, 07));
            });

            Assert.Equal("Informe uma senha de até 30 caracteres", exception.Message);
            Assert.Equal(typeof(Exception), exception.GetType());
        }

        [Fact]
        public void ValidatePropertyCPF() {
            var exception = Assert.Throws<Exception>(() => {
                var author = new Author(1, "name test", "emailtest@gmail.com", "123456", "036104888999999", new DateTime(2001, 04, 07));
            });

            Assert.Equal("Informe um CPF válido(Apenas números)", exception.Message);
            Assert.Equal(typeof(Exception), exception.GetType());
        }

        [Fact]
        public void ValidatePropertyDateOfBirth() {
            var exception = Assert.Throws<Exception>(() => {
                var author = new Author(1, "name test", "emailtest@gmail.com", "123456", "03610488899", DateTime.MinValue);
            });

            Assert.Equal("Informe uma data de nascimento válida", exception.Message);
            Assert.Equal(typeof(Exception), exception.GetType());
        }
    }
}
